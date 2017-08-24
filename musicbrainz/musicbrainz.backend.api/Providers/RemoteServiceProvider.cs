using System;
using System.Collections.Generic;
using MusicBrainz.Data;

namespace musicbrainz.backend.api.Providers
{
    public interface IRemoteServiceProvider
    {
        Release SearchReleases(Guid artistId);
    }

    public class RemoteServiceProvider : IRemoteServiceProvider
    {

        public Release SearchReleases(Guid artistId)
        {
            try
            {
                //call third party
                return MusicBrainz.Search.Release(arid: artistId.ToString());
            }
            catch (Exception ex)
            {
                //log exception

                //return generic response
                return new Release()
                {
                    Count = 0,
                    Offset = 0,
                    Data = new List<ReleaseData>()
                };
            }
        }
    }
}