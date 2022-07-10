using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroCliente.Models;

namespace CadastroCliente.Controllers
{
    public class ClienteController : Controller
    {
        private CadastroClienteContext db = new CadastroClienteContext();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteModel clienteModel = db.Cliente.Find(id);
            if (clienteModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Cliente,CPF,Nome,RG,Data_Expedicao,Orgao_Expedicao,UF,Data_Nascimento,Sexo,Estado_Civil")] ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                clienteModel.Id_Cliente = 0;
                db.Cliente.Add(clienteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clienteModel);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteModel clienteModel = db.Cliente.Find(id);
            if (clienteModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Cliente,CPF,Nome,RG,Data_Expedicao,Orgao_Expedicao,UF,Data_Nascimento,Sexo,Estado_Civil")] ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteModel clienteModel = db.Cliente.Find(id);
            if (clienteModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteModel clienteModel = db.Cliente.Find(id);
            db.Cliente.Remove(clienteModel);
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
