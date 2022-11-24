using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class ConexionCD
    {
        private SqlConnection conn; 

        // Metodo para abrir la conecion a la BD
        public SqlConnection OpenConnection()
        {   
            conn = new SqlConnection("Data Source=PC01\\SQLEXPRESSTEST;Initial Catalog=GesotecDB;Persist Security Info=True; User ID=admingst; Password=admin123");
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }

        // Metodo para cerrar la conecion con la BD
        public SqlConnection CloseConnection()
        {
            conn = new SqlConnection("Data Source=PC01\\SQLEXPRESSTEST;Initial Catalog=GesotecDB;Persist Security Info=True; User ID=admingst; Password=admin123");
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;

        }

    }
}
