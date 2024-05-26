using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.SexoDAO
{
    public class SexoDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public SexoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SelecionaSexo> ObterSexo()
        {
            List<SelecionaSexo> sexo = new List<SelecionaSexo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_SEX_EMPLO, CODE_SEX_EMPLO, DESC_SEX_EMPLO FROM DB_ALMOXARIFADO..TB_SEX_EMPLO";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_sex_emplo = Convert.ToInt32(reader["ID_SEX_EMPLO"]);
                    string code_sex_emplo = Convert.ToString(reader["CODE_SEX_EMPLO"]);
                    string desc_sex_emplo = Convert.ToString(reader["DESC_SEX_EMPLO"]);

                    SelecionaSexo sex = new SelecionaSexo(id_sex_emplo, code_sex_emplo, desc_sex_emplo);
                    sexo.Add(sex);
                }

                reader.Close();
            }

            return sexo;
        }
    }
}
