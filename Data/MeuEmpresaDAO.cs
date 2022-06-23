using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AplicativoSponsor.Models;
using MySql.Data.MySqlClient;
namespace AplicativoSponsor.Data
{
    public class MeuEmpresaDAO
    {
        public List<Empresa> SearchAll()
        {
            List<Empresa> retornalist = new List<Empresa>();

            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "SELECT * from tb_empresa where id_empresa = '2'";

                MySqlCommand command = new MySqlCommand(mysqlquery, conecta.conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Empresa empresa = new Empresa();
                        empresa.Id_empresa = reader.GetInt32(0);
                        empresa.NomeResp = reader.GetString(1);
                        empresa.CpfResp = reader.GetString(2);
                        empresa.CNPJ = reader.GetString(3);
                        empresa.Telefone = reader.GetString(4);
                        empresa.RazaoSocial = reader.GetString(5);
                        empresa.Descricao_Empresa = reader.GetString(6);
                        empresa.Rua = reader.GetString(7);
                        empresa.Numero = reader.GetString(8);
                        empresa.Bairro = reader.GetString(9);
                        empresa.Cidade = reader.GetString(10);
                        empresa.Estado = reader.GetString(11);
                        empresa.Pais = reader.GetString(12);
                        empresa.CEP = reader.GetString(13);


                        retornalist.Add(empresa);

                    }


                }
            }
            return retornalist;
        }

        public Empresa SearchOne(int id)
        {


            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "SELECT * from tb_empresa WHERE id_empresa = @id ";

                //associa o @id com o parametro id_empresa

                MySqlCommand command = new MySqlCommand(mysqlquery, conecta.conn);

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader reader = command.ExecuteReader();

                Empresa empresa = new Empresa();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        empresa.Id_empresa = reader.GetInt32(0);
                        empresa.NomeResp = reader.GetString(1);
                        empresa.CpfResp = reader.GetString(2);
                        empresa.CNPJ = reader.GetString(3);
                        empresa.Telefone = reader.GetString(4);
                        empresa.RazaoSocial = reader.GetString(5);
                        empresa.Descricao_Empresa = reader.GetString(6);
                        empresa.Rua = reader.GetString(7);
                        empresa.Numero = reader.GetString(8);
                        empresa.Bairro = reader.GetString(9);
                        empresa.Cidade = reader.GetString(10);
                        empresa.Estado = reader.GetString(11);
                        empresa.Pais = reader.GetString(12);
                        empresa.CEP = reader.GetString(13);


                    }


                }

                return empresa;

            }


        }
        internal int Delete(int id)
        {
            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "DELETE FROM tb_empresa WHERE id_empresa = @Id_empresa";



                MySqlCommand command = new MySqlCommand(mysqlquery, conecta.conn);

                command.Parameters.Add("@Id_empresa", MySqlDbType.Int32).Value = id;




                int deletedID = command.ExecuteNonQuery();


                Empresa empresa = new Empresa();

                return deletedID;



            }
        }
        public int uptate(Empresa empresacreate)
        {

            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "UPDATE tb_empresa set nome_responsavel = @NomeResp, cpf_responsavel  = @CpfResp, cnpj = @CNPJ, telefone = @Telefone, " +
                    "razao_social = @RazaoSocial, descricao_empresa = @Descricao_Empresa, rua = @Rua, numero = @Numero, bairro = @Bairro ,cidade = @Cidade, estado = @Estado, pais = @Pais, cep = @CEP WHERE Id_empresa = @Id_empresa";




                MySqlCommand command = new MySqlCommand(mysqlquery, conecta.conn);

                command.Parameters.Add("@Id_empresa", MySqlDbType.Int32).Value = empresacreate.Id_empresa;
                command.Parameters.Add("@NomeResp", MySqlDbType.VarChar, 150).Value = empresacreate.NomeResp;
                command.Parameters.Add("@CpfResp", MySqlDbType.VarChar, 20).Value = empresacreate.CpfResp;
                command.Parameters.Add("@CNPJ", MySqlDbType.VarChar, 20).Value = empresacreate.CNPJ;
                command.Parameters.Add("@Telefone", MySqlDbType.VarChar, 20).Value = empresacreate.Telefone;
                command.Parameters.Add("@RazaoSocial", MySqlDbType.VarChar, 100).Value = empresacreate.RazaoSocial;
                command.Parameters.Add("@Descricao_Empresa", MySqlDbType.VarChar, 300).Value = empresacreate.Descricao_Empresa;
                command.Parameters.Add("@Rua", MySqlDbType.VarChar, 150).Value = empresacreate.Rua;
                command.Parameters.Add("@Numero", MySqlDbType.VarChar, 7).Value = empresacreate.Numero;
                command.Parameters.Add("@Bairro", MySqlDbType.VarChar, 45).Value = empresacreate.Bairro;
                command.Parameters.Add("@Cidade", MySqlDbType.VarChar, 45).Value = empresacreate.Cidade;
                command.Parameters.Add("@Estado", MySqlDbType.VarChar, 45).Value = empresacreate.Estado;
                command.Parameters.Add("@Pais", MySqlDbType.VarChar, 45).Value = empresacreate.Pais;
                command.Parameters.Add("@CEP", MySqlDbType.VarChar, 10).Value = empresacreate.CEP;




                int newID = command.ExecuteNonQuery();


                Empresa empresa = new Empresa();

                return newID;



            }

        }
    }
}