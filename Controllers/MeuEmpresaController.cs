using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicativoSponsor.Models;
using AplicativoSponsor.Data;


namespace AplicativoSponsor.Controllers
{
    public class MeuEmpresaController : Controller
    {
        public ActionResult MeuEmpresa()
        {
            List<Empresa> empresa = new List<Empresa>();

            MeuEmpresaDAO empresadao = new MeuEmpresaDAO();

            empresa = empresadao.SearchAll();

            return View("MeuEmpresa", empresa);
        }

        public ActionResult DetailsM(int id)
        {


            MeuEmpresaDAO empresadao = new MeuEmpresaDAO();

            Empresa empresa = empresadao.SearchOne(id);

            return View("DetailsM", empresa);
        }

        public ActionResult Create()
        {
            return View("FormEmpresa");
        }

        public ActionResult Edit(int id)
        {
            MeuEmpresaDAO empresadao = new MeuEmpresaDAO();

            Empresa empresa = empresadao.SearchOne(id);
            return View("FormEmpresa", empresa);
        }

        public ActionResult ProcessCreate(Empresa empresa)
        {

            MeuEmpresaDAO empresaDAO = new MeuEmpresaDAO();

            empresaDAO.uptate(empresa);

            return View("DetailsM", empresa);
        }

        public ActionResult Delete(int id)
        {

            MeuEmpresaDAO empresaDAO = new MeuEmpresaDAO();
            empresaDAO.Delete(id);

            List<Empresa> empresa = empresaDAO.SearchAll();

            return View("MeuEmpresa", empresa);
        }
    }
}