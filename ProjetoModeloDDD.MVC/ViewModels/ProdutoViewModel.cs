using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Necessario preencher este campo")]
        [MaxLength(250,ErrorMessage = "Deve ter apenas {0} caracteres")]
        [MinLength(2,ErrorMessage = "Deve ter pelo menos {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0", "99999999999")]
        [Required(ErrorMessage = "Necessario preencher este campo")]
        public decimal Valor { get; set; }

        [DisplayName("Disponível?")]
        public bool Disponivel { get; set; }


        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}