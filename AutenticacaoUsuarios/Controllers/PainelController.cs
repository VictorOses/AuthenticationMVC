using System.Web.Mvc;

namespace AutenticacaoUsuarios.Controllers
{
    public class PainelController : Controller
    {
        // GET: Painel
        [Authorize] // FAZ COM QUE O PAINEL ADMINISTRATIVO SEJA ACESSADO APENAS POR USUÁRIOS LOGADOS
        public ActionResult Index()
        {
            return View();
        }
    }
}