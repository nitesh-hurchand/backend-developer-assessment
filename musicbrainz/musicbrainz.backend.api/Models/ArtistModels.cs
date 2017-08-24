using System.Collections.Generic;

namespace musicbrainz.backend.api.Models
{
    public class ArtistModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string[] Alias { get; set; }
    }

    public class SearchArtistResponse
    {
        public IList<ArtistModel> Results { get; set; }
        public int NumberOfSearchResults { get; set; }
        public string Page { get; set; }
        public string PageSize { get; set; }
        public string NumberOfPages { get; set; }
    }

    public class OtherArtistModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ReleaseModel
    {
        public string ReleaseId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public string NumberOfTracks { get; set; }
        public IList<OtherArtistModel> OtherArtists { get; set; }
    }

    public class SearchReleaseResponse
    {
        public IList<ReleaseModel> Results { get; set; }
    }
}