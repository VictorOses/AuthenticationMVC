using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutenticacaoUsuarios.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(100, ErrorMessage = "O nome deve ter até 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(50, ErrorMessage = "Seu login deve ter até 50 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]
        [MaxLength(6, ErrorMessage = "Sua senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [MaxLength(6, ErrorMessage = "Sua senha deve ter pelo menos 6 caracteres")]
        [Compare(nameof(Senha), ErrorMessage = "A senha não corresponde ao que já foi informado")]
        public string ConfirmacaoSenha { get; set; }
    }
}