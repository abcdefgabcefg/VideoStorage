using System.Data;
using System.Linq;
using System.Web.Mvc;
using VideoStorage.DAL;

namespace VideoStorage.Controllers
{
    public class VideosController : Controller
    {
        private VideoContex db = new VideoContex();

        // GET: Videos
        public ActionResult Index(int? id)
        {
            ViewBag.IDs = from video in db.Videos
                          select video.ID;
            ViewBag.Count = db.Videos.Count();
            return View(db.Videos.Find(id));
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
