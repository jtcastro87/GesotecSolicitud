using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioCN
    {
        private  QuerysCD querysCD;
        private DataSet ds;
        List<string> lista;

        // Obtenemos los Departamentos
        public List<string> GetDepartment()
        {
            lista = new List<string>();
            querysCD = new QuerysCD();
            ds = querysCD.GetDepartments();

            foreach(DataRow data in ds.Tables[0].Rows )
            {
                lista.Add(data["departmentName"].ToString());
            }        

            return lista;
        }

        // Obtiene las Areas
        public List<String> GetAreas(int param1)
        {
            lista = new List<string>();
            querysCD = new QuerysCD();
            ds = querysCD.GetAreas(param1);
            foreach (DataRow data in ds.Tables[0].Rows)
            {
                lista.Add(data["areaName"].ToString());
            }

            return lista;
        }

        // Obtiene las prioridades
        public List<string> GetPriorities()
        {
            lista = new List<string>();
            querysCD = new QuerysCD();
            ds = querysCD.GetPriorities();

            foreach (DataRow data in ds.Tables[0].Rows)
            {
                lista.Add(data["priorityName"].ToString());
            }

            return lista;
        }

        // Obtiene las Categorias
        public List<string> GetCategories()
        {
            lista = new List<string>();
            querysCD = new QuerysCD();
            ds = querysCD.GetCategories();

            foreach (DataRow data in ds.Tables[0].Rows)
            {
                lista.Add(data["categoryName"].ToString());
            }

            return lista;
        }

        // Envia solicitud
        public void SetRequests(string nombre,string area,string extension,int categoria,string comentario,int prioridad)
        {
            querysCD = new QuerysCD();
            querysCD.SetRequests(nombre, area, extension, categoria, comentario, prioridad);
        }

    }
}
