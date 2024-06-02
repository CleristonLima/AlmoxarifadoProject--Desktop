using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.SexoDAO
{
    public class BancoDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public BancoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SelecionaBanco> ObterBanco()
        {
            List<SelecionaBanco> bank = new List<SelecionaBanco>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_BANK, DESC_BANK FROM DB_ALMOXARIFADO..TB_HR_BANK";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_bank = Convert.ToInt32(reader["ID_BANK"]);
                    string desc_bank = Convert.ToString(reader["DESC_BANK"]);

                    SelecionaBanco banco = new SelecionaBanco(id_bank, desc_bank);
                    bank.Add(banco);
                }

                reader.Close();
            }

            return bank;
        }
    }
}
