using System;
using System.Linq;
using System.Web.Mvc;

using Pinecone.DataAccess;
using Pinecone.Models;

namespace Pinecone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Index(string member, string channel, string channel1)
        {
            User memberUser = _db.Users.SingleOrDefault(u => u.Sn == member);
            if (memberUser != null && memberUser.Id > 0)
            {
                // 记录访问日志
                var visitLog = new VisitLog
                {
                    User = memberUser,
                    VisitType = "member",
                    VisitTime = DateTime.Now
                };
                _db.VisitLogs.Add(visitLog);

                // 成员访问次数加1
                memberUser.MemberVisitCount++;
                _db.SaveChanges();
            }
            else
            {
                member = "";
            }
            ViewBag.Member = member;
            // 将用户信息记入Session
            Session["user"] = memberUser;

            User channelUser = _db.Users.SingleOrDefault(u => u.Sn == channel);
            if (channelUser != null && channelUser.Id > 0)
            {
                // 渠道记录访问日志
                var visitLog = new VisitLog
                {
                    User = channelUser,
                    VisitType = "channel",
                    VisitTime = DateTime.Now
                };
                _db.VisitLogs.Add(visitLog);

                // 渠道访问次数加1
                channelUser.ChannelVisitCount++;
                _db.SaveChanges();
            }
            else
            {
                channel = "";
            }
            ViewBag.Channel = channel;

            User channel1User = _db.Users.SingleOrDefault(u => u.Sn == channel1);
            if (channel1User != null && channel1User.Id > 0)
            {
                // 渠道记录访问日志
                var visitLog = new VisitLog
                {
                    User = channel1User,
                    VisitType = "channel1",
                    VisitTime = DateTime.Now
                };
                _db.VisitLogs.Add(visitLog);

                // 渠道访问次数加1
                channel1User.Channel1VisitCount++;
                _db.SaveChanges();
            }
            else
            {
                channel1 = "";
            }
            Session["Channel1"] = channel1;

            return View();
        }

        // GET: Home/Production
        public ActionResult Production()
        {
            return View();
        }

        // GET: Home/Share
        public ActionResult Share()
        {
            return View();
        }

        // GET: Home/Share1
        public ActionResult Share1()
        {
            return View();
        }
    }
}
