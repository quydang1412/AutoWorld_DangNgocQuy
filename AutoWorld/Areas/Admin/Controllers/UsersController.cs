using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoWorld.Common;
using AutoWorld.Models;
using AutoWorld.Models.ViewModels;

namespace AutoWorld.Areas.Admin.Controllers
{
    //[Authorize(Roles = "admin")]
    //[CustomActionFilter]
    //[ExceptionHandlerFilter]
    //public class UsersController : Controller
    //{
    //    private AutoWorlDbContext db = new AutoWorlDbContext();

    //    // GET: Admin/Users
    //    public ActionResult Index()
    //    {
    //        var users = db.Users.Include(u => u.Accounts);
    //        return View(users.ToList());
    //    }

    //    // GET: Admin/Users/Details/5
    //    public ActionResult Details(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Users users = db.Users.Find(id);
    //        if (users == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(users);
    //    }

    //    // GET: Admin/Users/Create
    //    public ActionResult Create()
    //    {
    //        ViewBag.AccountId = new SelectList(db.Accounts, "Id", "LoginName");
    //        return View();
    //    }

    //    // POST: Admin/Users/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "Id,DisplayName,Roles,AccountId")] Users users)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Users.Add(users);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        ViewBag.AccountId = new SelectList(db.Accounts, "Id", "LoginName", users.AccountId);
    //        return View(users);
    //    }

    //    // GET: Admin/Users/Edit/5
    //    public ActionResult Edit(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Users users = db.Users.Find(id);
    //        if (users == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        ViewBag.AccountId = new SelectList(db.Accounts, "Id", "LoginName", users.AccountId);
    //        return View(users);
    //    }

    //    // POST: Admin/Users/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "Id,DisplayName,Roles,AccountId")] Users users)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(users).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        ViewBag.AccountId = new SelectList(db.Accounts, "Id", "LoginName", users.AccountId);
    //        return View(users);
    //    }

    //    // GET: Admin/Users/Delete/5
    //    public ActionResult Delete(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Users users = db.Users.Find(id);
    //        if (users == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(users);
    //    }

    //    // POST: Admin/Users/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(long id)
    //    {
    //        Users users = db.Users.Find(id);
    //        db.Users.Remove(users);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}

    [Authorize(Roles = "admin")]
    [CustomActionFilter]
    [ExceptionHandlerFilter]
    public class UsersController : Controller
    {
        private AutoWorlDbContext db = new AutoWorlDbContext();

        // GET: Admin/Users
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.Accounts);
            return View(await users.ToListAsync());
        }

        // GET: Admin/Users/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserAccountView viewModel)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users();
                viewModel.CopyToUser(ref user);
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);

            return View(viewModel);
        }

        // GET: Admin/Users/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            UserAccountView viewModel = new UserAccountView(user);
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);
            return View(viewModel);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserAccountView viewModel)
        {
            if (ModelState.IsValid)
            {
                Users user = await db.Users.FindAsync(viewModel.Id);
                viewModel.CopyToUser(ref user); // TODO: prevent update username and password
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);

            return View(viewModel);
        }

        // GET: Admin/Users/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Users user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
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
