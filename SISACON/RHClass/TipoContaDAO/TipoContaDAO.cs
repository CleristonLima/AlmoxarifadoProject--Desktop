using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.SexoDAO
{
    public class TipoContaDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public TipoContaDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SelecionaTipoConta> ObterTipoConta()
        {
            List<SelecionaTipoConta> Tipoconta = new List<SelecionaTipoConta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_TYPE_COUNT, CODE_TYPE_COUNT, NAME_TYPE_COUNT FROM DB_ALMOXARIFADO..TB_HR_TYPE_COUNT_SALARY";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_type_count = Convert.ToInt32(reader["ID_TYPE_COUNT"]);
                    string code_type_count = Convert.ToString(reader["CODE_TYPE_COUNT"]);
                    string name_type_count = Convert.ToString(reader["NAME_TYPE_COUNT"]);

                    SelecionaTipoConta conta = new SelecionaTipoConta(id_type_count, code_type_count, name_type_count);
                    Tipoconta.Add(conta);
                }

                reader.Close();
            }

            return Tipoconta;
        }
    }
}
