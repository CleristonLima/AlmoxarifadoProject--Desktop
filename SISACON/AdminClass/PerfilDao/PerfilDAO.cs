using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.AdminClass.PerfilDao
{
    public class PerfilDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public PerfilDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Perfis> ObterTodos()
        {
            List<Perfis> perfis = new List<Perfis>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_PROFILE, NAME_PROFILE, CODE_PROFILE FROM DB_ALMOXARIFADO..TB_AD_PROFILE";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_profile = Convert.ToInt32(reader["ID_PROFILE"]);
                    string name_profile = Convert.ToString(reader["NAME_PROFILE"]);
                    string code_profile = Convert.ToString(reader["CODE_PROFILE"]);

                    Perfis perfil = new Perfis(id_profile, name_profile, code_profile);
                    perfis.Add(perfil);
                }

                reader.Close();
            }

            return perfis;
        }
    }
}
