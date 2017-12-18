using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudSchool.Models;
using Microsoft.AspNet.Identity;

namespace CloudSchool.Controllers
{
    public class MailRecipientsController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: MailRecipients
        public async Task<ActionResult> Index()
        {
            var model = new MailRecipientsViewModel();

            // Get a list of all the recipients:
            var recipients = await db.MailRecipients.ToListAsync();
            foreach (var item in recipients)
            {
                // Put the relevant data into the ViewModel:
                var newRecipient = new SelectRecipientEditorViewModel()
                {
                    MailRecipientId = item.MailRecipientId,
                    FullName = item.FullName,
                    Company = item.Company,
                    Email = item.Email,
                    LastMailedDate = item.getLastEmailDate().HasValue ? item.getLastEmailDate().Value.ToShortDateString() : "",
                    Selected = true
                };

                // Add to the list contained by the "wrapper" ViewModel:
                model.MailRecipients.Add(newRecipient);
            }
            // Pass to the view and return:
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public ActionResult SendMail(MailRecipientsViewModel recipients)
        {
            //// Retrieve the ids of the recipients selected:
            //var selectedIds = recipients.getSelectedRecipientIds();

            //// Grab the recipient records:
            //var selectedMailRecipients = this.LoadRecipientsFromIds(selectedIds);

            //// Build the message container for each:
            //var messageContainers = this.createRecipientMailMessages(selectedMailRecipients);

            //// Send the mail:
            //var sender = new MailSender();
            //var sent = sender.SendMail(messageContainers);

            //// Save a record of each mail sent:
            //this.SaveSentMail(sent);

            //// Reload the index form:
            //return RedirectToAction("Index");
            // Mail-sending code will happen here . . .
            System.Threading.Thread.Sleep(2000);
            return RedirectToAction("Index");
        }
        IEnumerable<MailRecipient> LoadRecipientsFromIds(IEnumerable<int> selectedIds)
        {
            var selectedMailRecipients = from r in db.MailRecipients
                                         where selectedIds.Contains(r.MailRecipientId)
                                         select r;
            return selectedMailRecipients;
        }


        IEnumerable<Message> createRecipientMailMessages(
            IEnumerable<MailRecipient> selectedMailRecipients)
        {
            var messageContainers = new List<Message>();
            var currentUser = context.Users.Find(User.Identity.GetUserId());
            foreach (var recipient in selectedMailRecipients)
            {
                var msg = new Message()
                {
                    Recipient = recipient,
                    User = currentUser,
                    Subject = string.Format("Welcome, {0}", recipient.FullName),
                    MessageBody = this.getMessageText(recipient, currentUser)
                };
                messageContainers.Add(msg);
            }
            return messageContainers;
        }


        void SaveSentMail(IEnumerable<SentMail> sentMessages)
        {
            foreach (var sent in sentMessages)
            {
                //db.SentMails.Add(sent);
                db.SaveChanges();
            }
        }


        string getMessageText(MailRecipient recipient, ApplicationUser user)
        {
            return ""
            + string.Format("Dear {0}, ", recipient.FullName) + Environment.NewLine
            + "Thank you for your interest in our latest product. "
            + "Please feel free to contact me for more information!"
            + Environment.NewLine
            + Environment.NewLine
            + "Sincerely, "
            + Environment.NewLine
            + user.UserName;//string.Format("{0} {1}", user.FirstName, user.LastName);
        }

        // GET: MailRecipients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailRecipient mailRecipient = await db.MailRecipients.FindAsync(id);
            if (mailRecipient == null)
            {
                return HttpNotFound();
            }
            return View(mailRecipient);
        }

        // GET: MailRecipients/Create
        [Authorize(Roles ="SchoolAdmin, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MailRecipients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SchoolAdmin, Admin")]
        public async Task<ActionResult> Create([Bind(Include = "LastName,FirstName,Email,Company")] MailRecipient mailRecipient)
        {
            if (ModelState.IsValid)
            {
                db.MailRecipients.Add(mailRecipient);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mailRecipient);
        }

        // GET: MailRecipients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailRecipient mailRecipient = await db.MailRecipients.FindAsync(id);
            if (mailRecipient == null)
            {
                return HttpNotFound();
            }
            return View(mailRecipient);
        }

        // POST: MailRecipients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MailRecipientId,LastName,FirstName,Email,Company")] MailRecipient mailRecipient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailRecipient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mailRecipient);
        }

        // GET: MailRecipients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailRecipient mailRecipient = await db.MailRecipients.FindAsync(id);
            if (mailRecipient == null)
            {
                return HttpNotFound();
            }
            return View(mailRecipient);
        }

        // POST: MailRecipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MailRecipient mailRecipient = await db.MailRecipients.FindAsync(id);
            db.MailRecipients.Remove(mailRecipient);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
