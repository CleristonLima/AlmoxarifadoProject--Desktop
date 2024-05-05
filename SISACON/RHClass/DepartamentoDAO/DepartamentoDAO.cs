using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.DepartamentoDAO
{
    public class DepartamentoDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public DepartamentoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Departamento> ObterDepartamento()
        {
            List<Departamento> departamento = new List<Departamento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_DEPARTMENT, NAME_DEPARTMENT, CODE_DEPARTMENT, STATUS_DEPARTMENT  FROM DB_ALMOXARIFADO..TB_HR_DEPARTMENTS";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_departament = Convert.ToInt32(reader["ID_DEPARTMENT"]);
                    string name_department = Convert.ToString(reader["NAME_DEPARTMENT"]);
                    string code_department = Convert.ToString(reader["CODE_DEPARTMENT"]);
                    int status_department = Convert.ToInt32(reader["STATUS_DEPARTMENT"]);

                    Departamento dep = new Departamento(id_departament, name_department, code_department, status_department);
                    departamento.Add(dep);
                }

                reader.Close();
            }

            return departamento;
        }
    }
}
