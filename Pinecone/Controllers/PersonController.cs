using System.Web.Mvc;

namespace Pinecone.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person/List
        public ActionResult List()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Create", "Order");
            }

            return View();
        }

        // GET: Person/Channel1
        public ActionResult Channel1()
        {
            return View();
        }

        // GET: Person/Detail
        public ActionResult Detail(string imgUrl)
        {
            imgUrl = imgUrl.Replace("s.jpg", "b.jpg");
            ViewBag.ImgUrl = imgUrl;

            return View();
        }
    }
}
