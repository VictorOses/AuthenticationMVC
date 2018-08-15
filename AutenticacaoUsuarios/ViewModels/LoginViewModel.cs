using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutenticacaoUsuarios.ViewModels
{
    public class LoginViewModel
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(50, ErrorMessage = "Seu login deve ter até 50 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]
        [MaxLength(6, ErrorMessage = "Sua senha deve ter no minímo 6 caracteres")]
        public string Senha { get; set; }
    }
}