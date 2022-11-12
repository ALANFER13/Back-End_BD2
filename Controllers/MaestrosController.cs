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
    public class MaestrosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                return View(dbMaestros.Alumnos.ToList());
            }
        }
        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                Maestros maestro = dbMaestros.Maestros.Find(id);
                if (maestro == null)
                {
                    return HttpNotFound();
                }
                return View(maestro);
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Maestros mae)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                dbMaestros.Maestros.Add(mae);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                return View(dbMaestros.Maestros.Where(x => x.Matricula == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(Alumnos alum)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                dbMaestros.Entry(alum).State = EntityState.Modified;
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                return View(dbMaestros.Maestros.Where(x => x.Matricula == id).
                    FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Delete(Maestros mae, int? id)
        {
            using (AlumnoDbContext dbMaestros = new AlumnoDbContext())
            {
                Maestros maes = dbMaestros.Maestros.Where(x => x.Matricula == id).
                    FirstOrDefault();
                dbMaestros.Maestros.Remove(maes);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}