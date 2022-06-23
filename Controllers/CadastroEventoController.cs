using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicativoSponsor.Models;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace AplicativoSponsor.Controllers
{
    public class CadastroEventoController : Controller
    {

        public ActionResult Cadastro_Evento()
        {
            if(Session["id_logado"] == null || Session["id_logado"].ToString() == "") {

                ViewBag.msg = "Usuário não está cadastrado!";
                return RedirectToAction("Login", "Login");
            
            } else
            {

                return View();

            }

        }
        public ActionResult CadastrarEvento(Evento evt, HttpPostedFileBase fileCapa)
        {
            if (ModelState.IsValid)
            {
                using (Conexao conexao = new Conexao())
                {
                    var StrQuery = "INSERT INTO tb_evento (nome_evento, categoria_evento, local_evento, data_inicio, data_final, hora_inicio, hora_final, publico_estimado, descricao_evento, id_empresa) " +
                    "values (@nome_evento, @categoria_evento, @local_evento, @data_inicio, @data_final, @hora_inicio, @hora_final, @publico_estimado, @descricao_evento, @id_empresa);";

                    MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn);
                    comando.Parameters.AddWithValue("@nome_evento", evt.Nome_evento);
                    comando.Parameters.AddWithValue("@categoria_evento", evt.Categoria_evento);
                    comando.Parameters.AddWithValue("@local_evento", evt.Local_evento);
                    comando.Parameters.AddWithValue("@data_inicio", evt.Data_inicio);
                    comando.Parameters.AddWithValue("@data_final", evt.Data_final);
                    comando.Parameters.AddWithValue("@hora_inicio", evt.Hora_inicio);
                    comando.Parameters.AddWithValue("@hora_final", evt.Hora_final);
                    comando.Parameters.AddWithValue("@publico_estimado", evt.Publico_estimado);
                    comando.Parameters.AddWithValue("@descricao_evento", evt.Descricao_evento);
                    comando.Parameters.AddWithValue("@id_empresa", Session["id_logado"]);


                    if (Session["categoria"].ToString() == "Organizador")
                    {

                        //realiza o insert
                        comando.ExecuteNonQuery();
                        Session["msg"] = "Evento cadastrado com sucesso.";
                        
                        //puxa o id (chave primaria do evento) e armazena na variável
                        comando.Parameters.Add(new MySqlParameter("ultimoId", comando.LastInsertedId));
                        int ultimoId = Convert.ToInt32(comando.Parameters["@ultimoId"].Value);

                        //salvar imagem 
                        string IdEvent = Convert.ToString(ultimoId);
                        string ImageFileName = IdEvent + ".png";
                        string FolderPath = Path.Combine(Server.MapPath("/Capa_Evento/"), ImageFileName);

                        fileCapa.SaveAs(FolderPath);

                        //retorna para a tela de cadastro
                        return RedirectToAction("Cadastro_Evento", "CadastroEvento");

                    } else {

                        Session["msg"] = "Usuário não autorizado a cadastrar um evento.";
                        return View("Cadastro_Evento");

                    }
                        //Caso não cadastre
                        Session["msg"] = "Erro ao cadastrar evento!";
                        return RedirectToAction("Cadastro_Evento", "CadastroEvento");

                    

                }
            }

            return View("Cadastro_Evento");

        }
    }
}