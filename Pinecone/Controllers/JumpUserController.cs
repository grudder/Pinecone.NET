using System;
using System.Linq;
using System.Web.Mvc;

using Pinecone.DataAccess;
using Pinecone.Models;

namespace Pinecone.Controllers
{
    public class JumpUserController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: User/List
        public ActionResult List()
        {
            return View(_db.JumpUsers.ToList());
        }

        // GET: JumpUser/Visit
        public ActionResult Visit(string member)
        {
            JumpUser jumpUser = _db.JumpUsers.SingleOrDefault(u => u.Sn == member);
            if (jumpUser != null && jumpUser.Id > 0)
            {
                // 记录访问日志
                var jvl = new JumpVisitLog
                {
                    JumpUser = jumpUser,
                    VisitType = "member",
                    VisitTime = DateTime.Now
                };
                _db.JumpVisitLogs.Add(jvl);

                // 成员访问次数加1
                jumpUser.MemberVisitCount++;
                _db.SaveChanges();

                ViewBag.Member = member;
            }

            return View();
        }

        // GET: JumpUser/Link1
        public ActionResult Link1(string member)
        {
            JumpUser jumpUser = _db.JumpUsers.SingleOrDefault(u => u.Sn == member);
            if (jumpUser != null && jumpUser.Id > 0)
            {
                // 记录访问日志
                var jvl = new JumpVisitLog
                {
                    JumpUser = jumpUser,
                    VisitType = "link1",
                    VisitTime = DateTime.Now
                };
                _db.JumpVisitLogs.Add(jvl);

                // 链接1访问次数加1
                jumpUser.Link1VisitCount++;
                _db.SaveChanges();
            }

            return Redirect("http://wd.koudai.com/item.html?itemID=293750930");
        }

        // GET: JumpUser/Link2
        public ActionResult Link2(string member)
        {
            JumpUser jumpUser = _db.JumpUsers.SingleOrDefault(u => u.Sn == member);
            if (jumpUser != null && jumpUser.Id > 0)
            {
                // 记录访问日志
                var jvl = new JumpVisitLog
                {
                    JumpUser = jumpUser,
                    VisitType = "link2",
                    VisitTime = DateTime.Now
                };
                _db.JumpVisitLogs.Add(jvl);

                // 链接2访问次数加1
                jumpUser.Link2VisitCount++;
                _db.SaveChanges();
            }

            return Redirect("http://wd.koudai.com/item.html?itemID=280276733");
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
