using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicbrainz.infrastructure.Models
{
    [Table("Artist")]
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Uid { get; set; }
        public string CountryCodeIso2 { get; set; }
        public string Aliases { get; set; }
        [NotMapped]
        public string[] AliasesAsList => !string.IsNullOrWhiteSpace(Aliases) ? Aliases.Split(',') : null;
    }
}
