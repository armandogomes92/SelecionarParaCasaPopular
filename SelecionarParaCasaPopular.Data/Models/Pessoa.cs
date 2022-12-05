using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SelecionarParaCasaPopular.Data.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public bool TitularDoCadastro { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public double RendaIndividual  { get; set; }
        [Required]
        public bool Dependente { get; set; }
        [Required, ForeignKey(nameof(Familia))]
        public int FamiliaId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Familia Familia { get; set;}

        public class Configuration : IEntityTypeConfiguration<Pessoa>
        {
            public void Configure(EntityTypeBuilder<Pessoa> builder)
            {
                builder.HasOne(x => x.Familia)
                    .WithMany(x => x.Membros)
                    .HasForeignKey(x => x.FamiliaId);
            }
        }
    }
}
