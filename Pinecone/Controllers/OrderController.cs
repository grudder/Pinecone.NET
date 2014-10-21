using System;
using System.Linq;
using System.Web.Mvc;

using Pinecone.DataAccess;
using Pinecone.Models;

namespace Pinecone.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Order/Create
        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Order/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReveiverName,Mobile,Address,Remark")] Order order)
        {
            if (ModelState.IsValid)
            {
                var user = (User)Session["user"];

                order.User = _db.Users.Single(u => u.Id == user.Id);
                order.CreateTime = DateTime.Now;
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Share1", "Home");
            }

            return View(order);
        }

        // GET: Order/List
        public ActionResult List()
        {
            return View(_db.Orders.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}