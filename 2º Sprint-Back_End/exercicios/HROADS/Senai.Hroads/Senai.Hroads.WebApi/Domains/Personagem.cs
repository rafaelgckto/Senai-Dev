using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.Hroads.WebApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Nome { get; set; }
        public int? IdClasse { get; set; }
        public decimal? Vida { get; set; }
        public decimal? Mana { get; set; }
        public DateTime? DtAtualizacao { get; set; }
        public DateTime? DtCricao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
