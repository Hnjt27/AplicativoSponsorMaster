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

                MeuEventoDAO meueventodao = new MeuEventoDAO();

                evento = meueventodao.SearchAll();

                return View("MeuEvento", evento);
        
            
          


            
        }

        public ActionResult Details(int id)
        {

            MeuEventoDAO meueventodao = new MeuEventoDAO();

            Evento evento = meueventodao.SearchOne(id);

            return View("Details", evento);
        }

        //atualização para create/insert e delete
        public ActionResult Create()
        {
            return View("FormEvento");
        }

        public ActionResult Edit(int id)
        {
            MeuEventoDAO meueventodao = new MeuEventoDAO();

            Evento evento = meueventodao.SearchOne(id);
            return View("FormEvento", evento);
        }

        public ActionResult ProcessCreate(Evento evento)
        {

            MeuEventoDAO meueventodao = new MeuEventoDAO();

            meueventodao.uptate(evento);

            return View("Details", evento);
        }

        public ActionResult Delete(int id)
        {

            MeuEventoDAO meueventodao = new MeuEventoDAO();
            meueventodao.Delete(id);

            List<Evento> evento = meueventodao.SearchAll();

            return View("MeuEvento", evento);
        }
    }
}