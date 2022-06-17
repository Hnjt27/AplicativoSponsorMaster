using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicativoSponsor.Models
{
    public class Evento
    {
        private int id_evento;

        private string nome_evento;

        private string categoria_evento;

        private string local_evento;

        private string data_inicio;

        private string data_final;

        private string hora_inicio;

        private string hora_final;

        private string publico_estimado;

        private string descricao_evento;

        private int? id_empresa;

        //Modelos para cadastro de evento
        public int Id_evento { get => id_evento; set => id_evento = value; }

        //[Required(ErrorMessage = "Campo 'Nome do Evento' é obrigatório")]
        public string Nome_evento { get => nome_evento; set => nome_evento = value; }

        //[Required(ErrorMessage = "Campo 'Categoria do Evento' é obrigatório")]
        public string Categoria_evento { get => categoria_evento; set => categoria_evento = value; }

        //[Required(ErrorMessage = "Campo 'Local do Evento' é obrigatório")]
        public string Local_evento { get => local_evento; set => local_evento = value; }

        //[Required(ErrorMessage = "Campo 'Data Inicial' é obrigatório")]
        public string Data_inicio { get => data_inicio; set => data_inicio = value; }

        //[Required(ErrorMessage = "Campo 'Data Final' é obrigatório")]
        public string Data_final { get => data_final; set => data_final = value; }

        //[Required(ErrorMessage = "Campo 'Hora Inicial' é obrigatório")]
        public string Hora_inicio { get => hora_inicio; set => hora_inicio = value; }

        //[Required(ErrorMessage = "Campo 'Hora Final' é obrigatório")]
        public string Hora_final { get => hora_final; set => hora_final = value; }

        //[Required(ErrorMessage = "Campo 'Publico Estimado' é obrigatório")]
        public string Publico_estimado { get => publico_estimado; set => publico_estimado = value; }

        //[Required(ErrorMessage = "Campo 'Descricao do Evento' é obrigatório")]
        public string Descricao_evento { get => descricao_evento; set => descricao_evento = value; }


        public int? Id_empresa { get => id_empresa; set => id_empresa = value; }
    }
}