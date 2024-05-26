using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.EscolaridadeDAO
{
    public class EscolaridadeDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public EscolaridadeDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SelecionaEscolaridade> ObterEscolaridade()
        {
            List<SelecionaEscolaridade> escolaridade = new List<SelecionaEscolaridade>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_EDUCATION, NAME_EDUCATION FROM DB_ALMOXARIFADO..TB_HR_EDUCATION";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_education = Convert.ToInt32(reader["ID_EDUCATION"]);
                    string name_education = Convert.ToString(reader["NAME_EDUCATION"]);

                    SelecionaEscolaridade esc = new SelecionaEscolaridade(id_education, name_education);
                    escolaridade.Add(esc);
                }

                reader.Close();
            }

            return escolaridade;
        }
    }
}
