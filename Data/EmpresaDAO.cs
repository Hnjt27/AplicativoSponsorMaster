using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AplicativoSponsor.Models;
using MySql.Data.MySqlClient;

namespace AplicativoSponsor.Data
{
    public class EmpresaDAO
    {
        public List<Empresa> SearchAll()
        {
            List<Empresa> retornalist = new List<Empresa>();

            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "SELECT * from tb_empresa";

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
    }
}