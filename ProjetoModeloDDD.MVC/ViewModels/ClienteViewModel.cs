using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Nome")]
        [MaxLength(150,ErrorMessage = "Maximo de {0} caracteres")]
        [MinLength(2,ErrorMessage = "Minimo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Nome")]
        [MaxLength(150, ErrorMessage = "Maximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo de {0} caracteres")]
        public string Sobrenome { get; set; }


        [Required(ErrorMessage = "Preencha o Campo Nome")]
        [MaxLength(100, ErrorMessage = "Maximo de {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um email valido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}