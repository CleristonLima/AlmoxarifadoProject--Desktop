using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.EstadoDAO
{
    public class EstadoDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public EstadoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SelecionaEstado> ObterEstado()
        {
            List<SelecionaEstado> estado = new List<SelecionaEstado>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_UF, CODE_UF, DESC_UF FROM DB_ALMOXARIFADO..TB_UF";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_uf = Convert.ToInt32(reader["ID_UF"]);
                    string code_uf = Convert.ToString(reader["CODE_UF"]);
                    string desc_uf = Convert.ToString(reader["DESC_UF"]);

                    SelecionaEstado est = new SelecionaEstado(id_uf, code_uf, desc_uf);
                    estado.Add(est);
                }

                reader.Close();
            }

            return estado;
        }
    }
}
