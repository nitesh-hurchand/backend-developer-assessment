using System.Data.Entity;
using musicbrainz.infrastructure.Models;

namespace musicbrainz.infrastructure
{
    public interface IMusicBrainzDbContext
    {
        DbSet<Artist> Artists { get; set; }
    }

    public class MusicBrainzDbContext : DbContext, IMusicBrainzDbContext
    {
        public DbSet<Artist> Artists { get; set; }
    }
}
