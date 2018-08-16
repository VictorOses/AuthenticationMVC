using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutenticacaoUsuarios.ViewModels
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "Informe sua senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        [MinLength(6, ErrorMessage = "A senha deve conter no minímo 6 caracteres.")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Informe sua nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        [MinLength(6, ErrorMessage = "A senha deve conter no minímo 6 caracteres.")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme sua nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [MinLength(6, ErrorMessage = "A senha deve conter no minímo 6 caracteres.")]
        [Compare(nameof(NovaSenha), ErrorMessage = "A senha e a confirmação não são iguais")]
        public string ConfirmacaoSenha { get; set; }
    }
}