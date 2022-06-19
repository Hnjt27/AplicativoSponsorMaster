using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicativoSponsor.Models;
using AplicativoSponsor.Data;

namespace AplicativoSponsor.Controllers
{
    public class MeuEventoController : Controller
    {

        // GET: MeuEvento
        public ActionResult MeuEvento()
        {
            List<Evento> evento = new List<Evento>();

            EventoDAO eventodao = new EventoDAO();

            evento = eventodao.SearchAll();

            return View("MeuEvento", evento);
        }

        public ActionResult Details(int id)
        {

            EventoDAO eventodao = new EventoDAO();

            Evento evento = eventodao.SearchOne(id);

            return View("Details", evento);
        }

        //atualização para create/insert e delete
        public ActionResult Create()
        {
            return View("FormEvento");
        }

        public ActionResult Edit(int id)
        {
            EventoDAO eventodao = new EventoDAO();

            Evento evento = eventodao.SearchOne(id);
            return View("FormEvento", evento);
        }

        public ActionResult ProcessCreate(Evento evento)
        {

            EventoDAO eventoDAO = new EventoDAO();

            eventoDAO.uptate(evento);

            return View("Details", evento);
        }

        public ActionResult Delete(int id)
        {

            EventoDAO eventoDAO = new EventoDAO();
            eventoDAO.Delete(id);

            List<Evento> evento = eventoDAO.SearchAll();

            return View("MeuEvento", evento);
        }
    }
}