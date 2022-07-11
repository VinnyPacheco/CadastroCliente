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
    public class EnderecoClienteController : Controller
    {
        private CadastroClienteContext db = new CadastroClienteContext();

        // GET: EnderecoCliente
        public ActionResult Index()
        {
            var enderecoCliente = db.EnderecoCliente.Include(e => e.Clientes);
            return View(enderecoCliente.ToList());
        }

        // GET: EnderecoCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoClienteModel enderecoClienteModel = db.EnderecoCliente.Find(id);
            if (enderecoClienteModel == null)
            {
                return HttpNotFound();
            }
            return View(enderecoClienteModel);
        }

        // GET: EnderecoCliente/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "CPF");
            return View();
        }

        // POST: EnderecoCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_EndCli,Id_Cliente,Clientes,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF")] EnderecoClienteModel enderecoClienteModel)
        {
            if (ModelState.IsValid)
            {
                enderecoClienteModel.Id_EndCli = 1;
                enderecoClienteModel.Id_Cliente = 1;
                enderecoClienteModel.Clientes.Id_Cliente = 1;
                db.EnderecoCliente.Add(enderecoClienteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "CPF", enderecoClienteModel.Id_Cliente);
            return View(enderecoClienteModel);
        }

        // GET: EnderecoCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoClienteModel enderecoClienteModel = db.EnderecoCliente.Find(id);
            if (enderecoClienteModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "CPF", enderecoClienteModel.Id_Cliente);
            return View(enderecoClienteModel);
        }

        // POST: EnderecoCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_EndCli,Id_Cliente,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF")] EnderecoClienteModel enderecoClienteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enderecoClienteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "CPF", enderecoClienteModel.Id_Cliente);
            return View(enderecoClienteModel);
        }

        // GET: EnderecoCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoClienteModel enderecoClienteModel = db.EnderecoCliente.Find(id);
            if (enderecoClienteModel == null)
            {
                return HttpNotFound();
            }
            return View(enderecoClienteModel);
        }

        // POST: EnderecoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnderecoClienteModel enderecoClienteModel = db.EnderecoCliente.Find(id);
            db.EnderecoCliente.Remove(enderecoClienteModel);
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
