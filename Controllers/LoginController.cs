using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using AplicativoSponsor.Models;
using System.ComponentModel.DataAnnotations;


namespace AplicativoSponsor.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        MySqlDataReader dr;
        string StrQuery;

        [HttpPost]
        public ActionResult Logar(Login usuario) 
        {
            if (ModelState.IsValid)
            {

                using (Conexao conexao = new Conexao())
                {
                    StrQuery = "SELECT * FROM tb_usuario WHERE email = @Email AND senha = @Senha;";
                    using (MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn))
                    {
                        comando.Parameters.AddWithValue("@Email", usuario.Email);
                        comando.Parameters.AddWithValue("@Senha", usuario.Senha);

                        dr = comando.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Session["id_logado"] = dr["id_empresa"];
                            }
                            return RedirectToAction("Index","Home");
                        } else {

                            ViewBag.ErroLogin = "Usuário ou Senha Inválidos";
                            return RedirectToAction("Login","Login");                            

                        }
                        
                    }

                }

            }

            return View(usuario);

        }
    }
}