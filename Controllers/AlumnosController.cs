using Back_End_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Back_End_BD.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using (AlumnoDbContext dbAlumno = new AlumnoDbContext())
            {
                return View(dbAlumno.Alumnos.ToList());
            }
        }
        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbAlumno = new AlumnoDbContext())
            {
                Alumnos alumno = dbAlumno.Alumnos.Find(id);
                if (alumno == null)
                {
                    return HttpNotFound();
                }
                return View(alumno);
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Alumnos alum)
        {
            using (AlumnoDbContext dbAlumno = new AlumnoDbContext())
            {
                dbAlumno.Alumnos.Add(alum);
                dbAlumno.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(Alumnos alum)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Entry(alum).State = EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Alumnos.Where(x => x.Id == id).
                    FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Delete(Alumnos alum, int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                Alumnos al = dbAlumnos.Alumnos.Where(x => x.Id == id).
                    FirstOrDefault();
                dbAlumnos.Alumnos.Remove(al);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}