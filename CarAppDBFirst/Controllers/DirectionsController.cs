﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarAppDBFirst;

namespace CarAppDBFirst.Controllers
{
    public class DirectionsController : Controller
    {
        private CarsContext db = new CarsContext();

        // GET: Directions
        public ActionResult Index()
        {
            var directions = db.Directions.Include(d => d.Point).Include(d => d.Point1);
            return View(directions.ToList());
        }

        // GET: Directions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = db.Directions.Find(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            return View(direction);
        }

        // GET: Directions/Create
        public ActionResult Create()
        {
            ViewBag.DepartureId = new SelectList(db.Points, "PointId", "Name");
            ViewBag.DestinationId = new SelectList(db.Points, "PointId", "Name");
            return View();
        }

        // POST: Directions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectionId,Name,DepartureId,DestinationId,Distance")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                db.Directions.Add(direction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartureId = new SelectList(db.Points, "PointId", "Name", direction.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Points, "PointId", "Name", direction.DestinationId);
            return View(direction);
        }

        // GET: Directions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = db.Directions.Find(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartureId = new SelectList(db.Points, "PointId", "Name", direction.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Points, "PointId", "Name", direction.DestinationId);
            return View(direction);
        }

        // POST: Directions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectionId,Name,DepartureId,DestinationId,Distance")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartureId = new SelectList(db.Points, "PointId", "Name", direction.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Points, "PointId", "Name", direction.DestinationId);
            return View(direction);
        }

        // GET: Directions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direction direction = db.Directions.Find(id);
            if (direction == null)
            {
                return HttpNotFound();
            }
            return View(direction);
        }

        // POST: Directions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direction direction = db.Directions.Find(id);
            db.Directions.Remove(direction);
            db.SaveChanges();
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
