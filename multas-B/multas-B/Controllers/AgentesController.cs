using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using multas_B.Models;

namespace multas_B.Controllers
{
    public class AgentesController : Controller
    {
        //cria uma variavel que representa a base de dados
        private MultasBd db = new MultasBd();

        // GET: Agentes
        public ActionResult Index()
        {
            //db.Agentes.ToList()--> em sql SELECT * FROM Agentes
            //enviar para a view uma lista com todos os agentes, da bd
            return View(db.Agentes.ToList());
            //return View();
        }

        // GET: Agentes/Details/5
        public ActionResult Details(int? id)
        {
            //se se escrevesse int? é possivel não fornecer o valor para o ID e não ha erro 
            //resumidamente o id? pode ser null
            //proteção para o caso de nao ter sido fornecido um ID valido
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //procura na BD, o Agente cujo ID foi fornecido
            Agentes agentes = db.Agentes.Find(id);
            //proteçao para o caso de não ter sido encontrado o agente que corresponde ao ID fornecido
            //por exemplo se so tivermos 5 agentes e nos derem um ID 100
            if (agentes == null)
            {
                return HttpNotFound();
            }
            //entrega áView aos dados do Agente encontrado
            return View(agentes);
        }

        // GET: Agentes/Create
        public ActionResult Create()
        {
            //representa a View para se inserir um novo Agente
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //anotador para HTTP Post
        [HttpPost]
        //anotador para proteção por roubo de identidade
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            //escrever os dados de um novo Agente na BD
            //ModelState.IsValid--> confronta os dados fornecidos da View com as exigencias do Modelo (expressoes regulares, required, etc.)
            if (ModelState.IsValid)
            {
                //adiciona o novo agente a BD
                db.Agentes.Add(agentes);
                //guarda as alterações --- faz 'Commit' as alterações
                db.SaveChanges();
                // se tudo correr bem redireciona para a pagina de Index
                return RedirectToAction("Index");
            }
            //se houver um erro reapresenta os dados do agente na View
            return View(agentes);
        }

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                //neste caso ja existe um agente apenas quero EDITAR os seus dados
                db.Entry(agentes).State = EntityState.Modified;
                //efetuar Commit
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentes);
        }

        // GET: Agentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agentes agentes = db.Agentes.Find(id);
            //remove os agentes da BD
            db.Agentes.Remove(agentes);
            //commit
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
