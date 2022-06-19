using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicativoSponsor.Models;
using AplicativoSponsor.Controllers;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;


namespace AplicativoSponsor.Data
{
  
    public class MeuEventoDAO
    {

        [HttpPost]
        public List<Evento> SearchAll()
        {
            List<Evento> retornalist = new List<Evento>();

            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "SELECT * from tb_evento";

                MySqlCommand command = new MySqlCommand(mysqlquery, conecta.conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       
                      
                        Evento evento = new Evento();
                        evento.Id_evento = reader.GetInt32(0);
                        evento.Nome_evento = reader.GetString(1);
                        evento.Categoria_evento = reader.GetString(2);
                        evento.Local_evento = reader.GetString(3);
                        evento.Data_inicio = reader.GetString(4);
                        evento.Data_final = reader.GetString(5);
                        evento.Hora_inicio = reader.GetString(6);
                        evento.Hora_final = reader.GetString(7);
                        evento.Publico_estimado = reader.GetString(8);
                        evento.Descricao_evento = reader.GetString(9);
                        evento.Id_empresa = reader.GetInt32(10);

                        retornalist.Add(evento);

                    }
                    


                }
               



            }

            return retornalist;
        }

        internal int Delete(int id)
        {
            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "DELETE FROM tb_evento WHERE id_evento = @Id_evento";



                MySqlCommand command = new MySqlCommand(mysqlquery, conecta.conn);

                command.Parameters.Add("@Id_evento", MySqlDbType.Int32).Value = id;




                int deletedID = command.ExecuteNonQuery();


                Evento evento = new Evento();

                return deletedID;



            }
        }

        public Evento SearchOne(int id)
        {


            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "SELECT * from tb_evento WHERE id_evento = @id ";

                //associa o @id com o parametro id_evento

                MySqlCommand command = new MySqlCommand(mysqlquery, conecta.conn);

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                MySqlDataReader reader = command.ExecuteReader();

                Evento evento = new Evento();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       
                        evento.Id_evento = reader.GetInt32(0);
                        evento.Nome_evento = reader.GetString(1);
                        evento.Categoria_evento = reader.GetString(2);
                        evento.Local_evento = reader.GetString(3);
                        evento.Data_inicio = reader.GetString(4);
                        evento.Data_final = reader.GetString(5);
                        evento.Hora_inicio = reader.GetString(6);
                        evento.Hora_final = reader.GetString(7);
                        evento.Publico_estimado = reader.GetString(8);
                        evento.Descricao_evento = reader.GetString(9);
                        evento.Id_empresa = reader.GetInt32(10);



                    }


                }

                return evento;

            }


        }

        //atualização para create / insert e delete no form
        public int uptate(Evento eventocreate)
        {

            using (Conexao conecta = new Conexao())
            {
                string mysqlquery = "UPDATE tb_evento set Nome_evento = @nome_evento, Categoria_evento  = @categoria_evento, Local_evento = @local_evento, Data_inicio = @data_inicio, " +
                    "Data_final = @data_final, Hora_inicio = @hora_inicio, Hora_final = @hora_final, Publico_estimado = @publico_estimado, Descricao_evento = @descricao_evento,Id_empresa = @id_empresa WHERE id_evento = @Id_evento";



                MySqlCommand command = new MySqlCommand(mysqlquery, conecta.conn);

                command.Parameters.Add("@Id_evento", MySqlDbType.Int32).Value = eventocreate.Id_evento;
                command.Parameters.Add("@nome_evento", MySqlDbType.VarChar, 45).Value = eventocreate.Nome_evento;
                command.Parameters.Add("@categoria_evento", MySqlDbType.VarChar, 45).Value = eventocreate.Categoria_evento;
                command.Parameters.Add("@local_evento", MySqlDbType.VarChar, 45).Value = eventocreate.Local_evento;
                command.Parameters.Add("@data_inicio", MySqlDbType.VarChar, 15).Value = eventocreate.Data_inicio;
                command.Parameters.Add("@data_final", MySqlDbType.VarChar, 15).Value = eventocreate.Data_final;
                command.Parameters.Add("@hora_inicio", MySqlDbType.VarChar, 15).Value = eventocreate.Hora_inicio;
                command.Parameters.Add("@hora_final", MySqlDbType.VarChar, 15).Value = eventocreate.Hora_final;
                command.Parameters.Add("@publico_estimado", MySqlDbType.VarChar, 15).Value = eventocreate.Publico_estimado;
                command.Parameters.Add("@descricao_evento", MySqlDbType.VarChar, 300).Value = eventocreate.Descricao_evento;
                command.Parameters.Add("@id_empresa", MySqlDbType.Int32).Value = eventocreate.Id_empresa;



                int newID = command.ExecuteNonQuery();


                Evento evento = new Evento();

                return newID;



            }

        }
    }
}