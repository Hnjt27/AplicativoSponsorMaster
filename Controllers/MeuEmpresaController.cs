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

            EmpresaDAO empresadao = new EmpresaDAO();

            empresa = empresadao.SearchAll();

            return View("MeuEmpresa", empresa);
        }

        public ActionResult DetailsM(int id)
        {


            EmpresaDAO empresadao = new EmpresaDAO();

            Empresa empresa = empresadao.SearchOne(id);

            return View("DetailsM", empresa);
        }

        public ActionResult Create()
        {
            return View("FormEmpresa");
        }

        public ActionResult Edit(int id)
        {
            EmpresaDAO empresadao = new EmpresaDAO();

            Empresa empresa = empresadao.SearchOne(id);
            return View("FormEmpresa", empresa);
        }

        public ActionResult ProcessCreate(Empresa empresa)
        {

            EmpresaDAO empresaDAO = new EmpresaDAO();

            empresaDAO.uptate(empresa);

            return View("DetailsM", empresa);
        }

        public ActionResult Delete(int id)
        {

            EmpresaDAO empresaDAO = new EmpresaDAO();
            empresaDAO.Delete(id);

            List<Empresa> empresa = empresaDAO.SearchAll();

            return View("MeuEmpresa", empresa);
        }
    }
}