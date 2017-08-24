using System;
using System.Collections.Generic;
using System.Linq;
using musicbrainz.backend.api.Models;

namespace musicbrainz.backend.api.Providers
{
    public interface IRemoteServiceProvider
    {
        IEnumerable<ReleaseModel> SearchReleases(Guid artistId);
    }

    public class RemoteServiceProvider : IRemoteServiceProvider
    {

        public IEnumerable<ReleaseModel> SearchReleases(Guid artistId)
        {
            try
            {
                var result = new List<ReleaseModel>();
                //call third party
                var artistReleaseRemote = MusicBrainz.Search.Release(arid: artistId.ToString());

                if (artistReleaseRemote.Data.Count <= 0)
                {
                    return result;
                }

                result.AddRange(artistReleaseRemote.Data.Select(item => new ReleaseModel()
                {
                    ReleaseId = item.Id,
                    Title = item.Title,
                    Status = item.Status,
                    Label = item.Labelinfolist.Any() 
                    ? item.Labelinfolist.First().Label.Name : null,
                    NumberOfTracks = item.Mediumlist.Trackcount.ToString(),
                    OtherArtists = item.Artistcredit
                    .Where(x => x.Artist.Id != artistId.ToString())
                    .Select(x => new OtherArtistModel() {Id = x.Artist.Id, Name = x.Artist.Name}).ToList()
                }));
                return result;
            }
            catch (Exception ex)
            {
                //log exception

                //return generic response
                return new List<ReleaseModel>();
            }
        }
    }
}