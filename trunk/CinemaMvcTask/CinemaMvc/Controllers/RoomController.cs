using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaCommon.Entities;
using CinemaCommon.Context;

namespace CinemaMvc.Controllers
{
    public class RoomController : Controller
    {
        private CinemaContext db = new CinemaContext();

        //
        // GET: /Room/

        public ActionResult Index()
        {
            var rooms = db.Rooms
                          .Include(r => r.Cinema)
                          .Include(r => r.Movie)
                          .OrderBy(r => r.Cinema.Name)
                          .ThenBy(r => r.Name);
            return View(rooms.ToList());
        }

        [HttpPost]
        public HttpStatusCodeResult AddRemovePersons(int id, int count)
        {
            var room = db.Rooms.Find(id);
            if (room != null)
            {
                room.ReservedSeats = room.ReservedSeats + count;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

        //
        // GET: /Room/Details/5

        public ActionResult Details(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // GET: /Room/Create

        public ActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "Name");
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            return View();
        }

        //
        // POST: /Room/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "Name", room.CinemaId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", room.MovieId);
            return View(room);
        }

        //
        // GET: /Room/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "Name", room.CinemaId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", room.MovieId);
            return View(room);
        }

        //
        // POST: /Room/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "Name", room.CinemaId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", room.MovieId);
            return View(room);
        }

        //
        // GET: /Room/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // POST: /Room/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddPersons(int id, int count)
        {
            var room = db.Rooms.Find(id);
            if (room.ReservedSeats + count <= room.MaxSeats)
            {
                room.ReservedSeats = room.ReservedSeats + count;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemovePersons(int id, int count)
        {
            var room = db.Rooms.Find(id);
            if (room.ReservedSeats - count >= 0)
            {
                room.ReservedSeats = room.ReservedSeats - count;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}