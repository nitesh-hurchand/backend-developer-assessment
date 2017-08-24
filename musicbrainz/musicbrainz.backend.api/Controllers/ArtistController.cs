using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using musicbrainz.backend.api.Models;
using musicbrainz.backend.api.Providers;
using musicbrainz.infrastructure;

namespace musicbrainz.backend.api.Controllers
{
    public class ArtistController : ApiController
    {
        private readonly IMusicBrainzDbContext _dbContext;
        private readonly IRemoteServiceProvider _remoteServiceProvider;
        public ArtistController(IMusicBrainzDbContext dbContext,
            IRemoteServiceProvider remoteServiceProvider)
        {
            _dbContext = dbContext;
            _remoteServiceProvider = remoteServiceProvider;
        }

        [Route("artist/search/{searchCriteria}/{pageNumber:int?}/{pageSize:int?}")]
        public SearchArtistResponse Get(string searchCriteria, int pageNumber = 0, int pageSize = 30)
        {
            var response = new SearchArtistResponse()
            {
                NumberOfPages = "0",
                NumberOfSearchResults = 0,
                Page = pageNumber.ToString(),
                PageSize = pageSize.ToString(),
                Results = new List<ArtistModel>()
            };

            if (string.IsNullOrWhiteSpace(searchCriteria))
            {
                return response;
            }

            var resultsCount = _dbContext.Artists.Where(x => x.Name.Contains(searchCriteria))
                    .OrderBy(x => x.Name);

            var resultsPaged = _dbContext.Artists.Where(x => x.Name.Contains(searchCriteria))
                .OrderBy(x => x.Name)
                .Skip(pageNumber * pageSize)
                .Take(pageSize);

            response.NumberOfSearchResults = resultsCount.Count();
            response.NumberOfPages = Math.Ceiling((decimal)response.NumberOfSearchResults / pageSize)
                .ToString(CultureInfo.InvariantCulture);
            foreach (var item in resultsPaged)
            {
                response.Results.Add(new ArtistModel()
                {
                    Name = item.Name,
                    Country = item.CountryCodeIso2,
                    Alias = item.AliasesAsList
                });
            }

            return response;
        }

        [Route("artist/{artistId:guid}/releases")]
        public SearchReleaseResponse Get(Guid artistId)
        {
            var response = new SearchReleaseResponse()
            {
                Results = new List<ReleaseModel>()
            };

            var artistFromDb = _dbContext.Artists.FirstOrDefault(x => x.Uid == artistId);

            if (artistFromDb == null)
            {
                return response;
            }

            //var artistFromRemote = MusicBrainz.Search.Artist(arid: artistFromDb.Uid.ToString());
            var artistReleaseRemote = _remoteServiceProvider.SearchReleases(artistFromDb.Uid);

            if (artistReleaseRemote.Data.Count <= 0)
            {
                return response;
            }

            foreach (var item in artistReleaseRemote.Data)
            {
                response.Results.Add(new ReleaseModel()
                {
                    ReleaseId = item.Id,
                    Title = item.Title,
                    Status = item.Status,
                    Label = item.Labelinfolist.Any() ? item.Labelinfolist.First().Label.Name : null,
                    NumberOfTracks = item.Mediumlist.Trackcount.ToString(),
                    OtherArtists = item.Artistcredit
                    .Where(x => x.Artist.Id != artistFromDb.Uid.ToString())
                    .Select(x => new OtherArtistModel() { Id = x.Artist.Id, Name = x.Artist.Name })
                    .ToList()
                });
            }
            return response;
        }
    }
}
