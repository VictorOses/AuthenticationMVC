using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AutenticacaoUsuarios.Models;
using AutenticacaoUsuarios.ViewModels;
using AutenticacaoUsuarios.Utils;

namespace AutenticacaoUsuarios.Controllers
{
    public class PerfilController : Controller
    {
        private UsuariosContext db = new UsuariosContext();

        // GET: Perfil
        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //CAPTURA O USUARIO QUE ESTÁ LOGADO
            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;

            var usuario = db.usuarios.FirstOrDefault(u => u.Login == login);

            if (Hash.GerarHash(viewmodel.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                return View();
            }

            usuario.Senha = Hash.GerarHash(viewmodel.NovaSenha);
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Painel");
        }
    }
}