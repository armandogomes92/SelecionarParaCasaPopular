using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SelecionarParaCasaPopular.Data.Models
{
    [Table("Familia")]
    public class Familia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Pontos { get; set; }
        public virtual ICollection<Pessoa> Membros { get; set; }

        public class Configuration : IEntityTypeConfiguration<Familia>
        {
            public void Configure(EntityTypeBuilder<Familia> builder)
            {
                builder.HasMany(x => x.Membros)
                     .WithOne(x => x.Familia);
            }
        }
    }
}
