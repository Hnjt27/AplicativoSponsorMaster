using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicativoSponsor.Models;
using AplicativoSponsor.Data;

namespace AplicativoSponsor.Controllers
{
    public class FeedEventoController : Controller
    {
        // GET: FeedEvento
        public ActionResult FeedEvento()
        {
            List<Evento> evento = new List<Evento>();

            EventoDAO eventodao = new EventoDAO();

            evento = eventodao.SearchAll();

            return View("FeedEvento", evento);
        }

        public ActionResult Details(int id)
        {

            EventoDAO eventodao = new EventoDAO();

            Evento evento = eventodao.SearchOne(id);

            return View("Details", evento);
        }

        //public ActionResult Create()
        //{
        //    return View("FormEvento");
        //}

        //public ActionResult ProcessCreate(Evento evento)
        //{
        //    //salva no db
        //    EventoDAO eventoDAO = new EventoDAO();

        //    eventoDAO.Create(evento);

        //    return View("Details", evento);
        //}
    } 
}