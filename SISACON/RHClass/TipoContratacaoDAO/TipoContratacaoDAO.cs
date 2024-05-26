using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.TipoContratacaoDAO
{
    public class TipoContratacaoDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public TipoContratacaoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SelecionaTipoContratacao> ObterTipoContratacao()
        {
            List<SelecionaTipoContratacao> tipoContratacao = new List<SelecionaTipoContratacao>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_TYPE_HIRING, DESC_HIRING FROM DB_ALMOXARIFADO..TB_HR_TYPE_HIRING";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_type_hiring = Convert.ToInt32(reader["ID_TYPE_HIRING"]);
                    string desc_hiring = Convert.ToString(reader["DESC_HIRING"]);

                    SelecionaTipoContratacao tipoContra = new SelecionaTipoContratacao(id_type_hiring, desc_hiring);
                    tipoContratacao.Add(tipoContra);
                }

                reader.Close();
            }

            return tipoContratacao;
        }
    }
}
