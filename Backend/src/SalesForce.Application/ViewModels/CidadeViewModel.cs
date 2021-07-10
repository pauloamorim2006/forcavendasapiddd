using System;
using System.ComponentModel.DataAnnotations;

namespace SalesForce.Application.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Código IBGE")]
        public int CodigoIbge { get; set; }
        [Display(Name = "Cidade")]
        public string Descricao { get; set; }
        [Display(Name = "UF")]
        public string Uf { get; set; }
    }
}
