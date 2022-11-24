using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class QuerysCD
    {
        private ConexionCD connCD;
        private DataSet ds;
        private SqlDataAdapter adaptador;
        private SqlCommand comando;

        // Obtiene los departamentos
        public DataSet GetDepartments()
        {
            connCD = new ConexionCD();
            string cmd = "HR.SP_GetDepartments";
            ds = new DataSet();
            adaptador = new SqlDataAdapter(cmd, connCD.OpenConnection());
            adaptador.Fill(ds);
            return ds;
        }

        // Obtiene las areas dependiendo del departamento
        public DataSet GetAreas(int param1)
        {
            connCD = new ConexionCD();
            string cmd = string.Format("HR.SP_GetAreas {0}",param1);
            ds = new DataSet();
            adaptador = new SqlDataAdapter(cmd, connCD.OpenConnection());
            adaptador.Fill(ds);
            return ds;
        }

        // Obtiene las prioridaes
        public DataSet GetPriorities()
        {
            connCD = new ConexionCD();
            string cmd = "Production.SP_GetPriorities";
            ds = new DataSet();
            adaptador = new SqlDataAdapter(cmd, connCD.OpenConnection());
            adaptador.Fill(ds);
            return ds;
        }

        // Obtiene las Categorias
        public DataSet GetCategories()
        {
            connCD = new ConexionCD();
            string cmd = "Production.SP_GetCategories";
            ds = new DataSet();
            adaptador = new SqlDataAdapter(cmd, connCD.OpenConnection());
            adaptador.Fill(ds);
            return ds;
        }

        // Envia solictitud
        public void SetRequests(string emp,string area,string extension,int categoria, string comentario,int prioridad)
        {
            connCD = new ConexionCD();
            comando = new SqlCommand();
            comando.Connection = connCD.OpenConnection();
            comando.CommandText = "Production.SP_createRequests";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empName", emp);
            comando.Parameters.AddWithValue("@areaName", area);
            comando.Parameters.AddWithValue("@extention", extension);
            comando.Parameters.AddWithValue("@CategoryId", categoria);
            comando.Parameters.AddWithValue("@detail", comentario);
            comando.Parameters.AddWithValue("@priorityRequests", prioridad);
            comando.ExecuteNonQuery();
            connCD.CloseConnection();
        }
    }
}
