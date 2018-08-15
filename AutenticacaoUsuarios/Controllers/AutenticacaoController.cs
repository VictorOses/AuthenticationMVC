using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticacaoUsuarios.Models;
using AutenticacaoUsuarios.ViewModels;
using AutenticacaoUsuarios.Utils;
using System.Security.Claims;

namespace AutenticacaoUsuarios.Controllers
{
    public class AutenticacaoController : Controller
    {
        private UsuariosContext db = new UsuariosContext();

        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            if(db.usuarios.Count(u => u.Login == viewmodel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Esse login já está sendo utilizado");
                return View(viewmodel);
            }

            Usuario novoUsuario = new Usuario
            {
                Nome = viewmodel.Nome,
                Login = viewmodel.Login,
                Senha = Hash.GerarHash(viewmodel.Senha)
             };

            db.usuarios.Add(novoUsuario);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var usuario = db.usuarios.FirstOrDefault(u => u.Login == viewmodel.Login);

            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Login incorreto");
                return View(viewmodel);
            }

            if(usuario.Senha != Hash.GerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewmodel);
            }

            //DEFINIR IDENTIDADE DO USUARIO
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login)
            }, "ApplicationCookie");

            //FAZER O LOGIN NO OWIN   
            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno) || Url.IsLocalUrl(viewmodel.UrlRetorno))
                return Redirect(viewmodel.UrlRetorno);
            else
                return RedirectToAction("Index", "Painel");
        }

    }
}