using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

using Pinecone.DataAccess;
using Pinecone.Models;

namespace Pinecone.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: User/List
        public ActionResult List()
        {
            //InitUserData();

            return View(_db.Users.ToList());
        }

        private void InitUserData()
        {
            const string filePath = "D:\\Work\\_me\\pinecone\\doc\\100组序列.txt";
            var reader = new StreamReader(filePath);
            string line = "";
            while (line != null)
            {
                line = reader.ReadLine();
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }

                var user = new User
                {
                    Sn = line,
                    MemberVisitCount = 0,
                    ChannelVisitCount = 0
                };
                _db.Users.Add(user);
                _db.SaveChanges();
            }
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
