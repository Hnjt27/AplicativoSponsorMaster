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

            return View();

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

                    try
                    {
                        //Cadastra evento na tabela tb_evento caso usuário esteja logado
                        if (Session["id_logado"] != null) { comando.ExecuteNonQuery(); }
                        else { return RedirectToAction("Login", "Login"); }

                        //puxa o id (chave primaria do evento) e armazena na variável
                        comando.Parameters.Add(new MySqlParameter("ultimoId", comando.LastInsertedId));
                        int ultimoId = Convert.ToInt32(comando.Parameters["@ultimoId"].Value);

                        //salvar imagem 
                        if (fileCapa.ContentLength > 0)
                        {

                            string IdEvent = Convert.ToString(ultimoId);
                            string ImageFileName = IdEvent + ".png";
                            string FolderPath = Path.Combine(Server.MapPath("~/Capa_Evento/"), ImageFileName);

                            fileCapa.SaveAs(FolderPath);

                        }

                    }
                    catch (Exception)
                    {
                        ViewBag.CadastroEvt = "Erro ao cadastrar evento!";
                        return RedirectToAction("Cadastro_Evento", "CadastroEvento");
                        throw;
                    }
                    ViewBag.CadastroEvt = "Evento cadastrado com sucesso!";
                    return RedirectToAction("Cadastro_Evento", "CadastroEvento");

                }
            }

            return View("Cadastro_Evento");

        }
    }
}