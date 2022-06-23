using AplicativoSponsor.Models;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AplicativoSponsor.Controllers
{
    public class CadastroEmpresaController : Controller
    {

        int ultimoId;


        public ActionResult Cadastro_Empresa()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CadastrarEmpresa(Empresa emp, Usuario us, HttpPostedFileBase fileCapa)
        {

            using (Conexao conexao = new Conexao())
            {
                var StrQuery = "INSERT INTO tb_empresa(nome_responsavel, cpf_responsavel, cnpj, telefone," +
                    "razao_social, descricao_empresa, rua, numero, bairro, cidade, estado, pais, cep) " +
                   "values (@nome_responsavel, @cpf_responsavel,  @cnpj, @telefone, @razao_social, " +
                   "@descricao_emp, @rua, @numero, @bairro, @cidade , @estado, @pais, @cep)";

                MySqlCommand comando = new MySqlCommand(StrQuery, conexao.conn);

                comando.Parameters.AddWithValue("@nome_responsavel", emp.NomeResp);
                comando.Parameters.AddWithValue("@cpf_responsavel", emp.CpfResp);
                comando.Parameters.AddWithValue("@cnpj", emp.CNPJ);
                comando.Parameters.AddWithValue("@telefone", emp.Telefone);
                comando.Parameters.AddWithValue("@razao_social", emp.RazaoSocial);
                comando.Parameters.AddWithValue("@descricao_emp", emp.Descricao_Empresa);
                comando.Parameters.AddWithValue("@rua", emp.Rua);
                comando.Parameters.AddWithValue("@numero", emp.Numero);
                comando.Parameters.AddWithValue("@bairro", emp.Bairro);
                comando.Parameters.AddWithValue("@cidade", emp.Cidade);
                comando.Parameters.AddWithValue("@estado", emp.Estado);
                comando.Parameters.AddWithValue("@pais", emp.Pais);
                comando.Parameters.AddWithValue("@cep", emp.CEP);
                comando.ExecuteNonQuery();

                try
                {
                    if (comando.LastInsertedId != 0)
                        comando.Parameters.Add(new MySqlParameter("ultimoId", comando.LastInsertedId));
                    ultimoId = Convert.ToInt32(comando.Parameters["@ultimoId"].Value);

                    var StrQuery2 = "INSERT INTO tb_usuario(categoria_usuario, email, senha, id_empresa) " +
                    "values (@categoria, @email, @senha, @id_empresa)";

                    MySqlCommand comando2 = new MySqlCommand(StrQuery2, conexao.conn);
                    comando2.Parameters.AddWithValue("@categoria", us.Categoria);
                    comando2.Parameters.AddWithValue("@email", us.EmailCad);
                    comando2.Parameters.AddWithValue("@senha", us.SenhaCad);
                    comando2.Parameters.AddWithValue("@id_empresa", ultimoId);

                    //salvar imagem 
                    string IdEvent = Convert.ToString(ultimoId);
                    string ImageFileName = IdEvent + ".png";
                    string FolderPath = Path.Combine(Server.MapPath("/Capa_Empresa/"), ImageFileName);
                    fileCapa.SaveAs(FolderPath);

                    comando2.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    ViewBag.CadastroEmp = "Erro ao cadastrar empresa!";
                    return RedirectToAction("Cadastro_Empresa", "CadastroEmpresa");
                    throw;
                }
            }

            return RedirectToAction("Login", "Login");
        }


    }
}
