using SimpleNotes.Core.Repository.Interface;
using SimpleNotes.Models;
using SimpleNotes.Providers.Implementation;
using System.Drawing;
using System.IO;
using System.Web.Mvc;

namespace SimpleNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteRepository _noteRepositoty;
        private readonly AuthProvider _authProvider;
        public HomeController(INoteRepository noteRepository, AuthProvider authProvider)
        {
            _authProvider = authProvider;
            _noteRepositoty = noteRepository;
        }

        [HttpGet]
        [Authorize]
        public ActionResult MyIndex()
        {
            var model = new MyListViewSearchModel(_noteRepositoty, _authProvider.SearchUser(User.Identity.Name));
            ViewBag.Title = "Список файлов";
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new ListViewSearchModel(_noteRepositoty, "");
            ViewBag.Title = "Список файлов";
            return View("Index", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(string search)
        {
            var viewModel = new ListViewSearchModel(_noteRepositoty, search);
            return PartialView("List", viewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(AddModel model)
        {
            if (model.File != null)
            {
                string pathFile = "/Files/" + User.Identity.Name + "/";
                string pathIco = "/Files/Ico/" + User.Identity.Name + "/";
                if (!Directory.Exists(Server.MapPath(pathFile)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathFile));
                }
                if (!Directory.Exists(Server.MapPath(pathIco)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathIco));
                }
                string filename = Path.GetFileName(model.File.FileName);
                model.File.SaveAs(Server.MapPath(pathFile + filename));
                int author = _authProvider.SearchUser(User.Identity.Name);
                string path = pathFile + filename;
                Icon extractedIcon = Icon.ExtractAssociatedIcon(Server.MapPath(pathFile + filename));
                string icostr = filename;
                string v = Path.GetExtension(filename);
                icostr = icostr.Replace(v, "") + ".jpg";
                Bitmap bitmap = extractedIcon.ToBitmap();
                bitmap.Save(Server.MapPath(pathIco + icostr));
                icostr = "/Files/Ico/" + User.Identity.Name + "/" + icostr;
                _noteRepositoty.Add(model.Name, author, icostr, path, model.Published, model.Text, model.Tag);
            }
            return RedirectToAction("MyIndex");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var Note = _noteRepositoty.GetNote(id);
            EditModel edit = new EditModel
            {
                Text = Note.Text,
                Published = Note.Published
            };
            return View(edit);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, EditModel edit)
        {
            _noteRepositoty.Update(id, edit.Text, edit.Published);
            return RedirectToAction("MyIndex");

        }
    }
}