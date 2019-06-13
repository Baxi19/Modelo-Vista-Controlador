using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ErpTEC.AccesoDatos;
using ErpTEC.Entidad;
using Npgsql;

namespace ErpTEC.Modelo
{
    public class ModeloCliente
    {
        public bool ExisteError { get; private set; } = false;
        public string MensajeError { get; private set; } = "";

        public void Crear(Cliente cliente)
        {
            Conexion conex = new Conexion();
            try
            {
                String sql = "INSERT INTO cliente("
                        + "cedula" + ","
                        + "nombre " + ","
                        + "direccion" + ")"
                        + " VALUES ('" + cliente.Cedula + "',"
                        + "'" + cliente.Nombre + "',"
                        + "'" + cliente.Direccion + "');";
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sql, conex.Conn);
                npgsqlCommand.ExecuteNonQuery();
                conex.Conn.Close();

            }
            catch (NpgsqlException e)
            {
                ExisteError=true;
                MensajeError=e.Message;
            }
        }

        public List<Cliente> Obtener()
        {
            Conexion conex = new Conexion();
            DataTable resultado = new DataTable();
            List<Cliente> lista = new List<Cliente>();
            try {
                //ejecutar los procesimientos
                //EXEC ObtenerSaldoCuenta 1 'A2';
                String sql = "SELECT * FROM cliente ORDER BY id ASC;";
                NpgsqlDataAdapter oNpgsqlDataAdapter = new NpgsqlDataAdapter(sql, conex.Conn);
                oNpgsqlDataAdapter.Fill(resultado);
                
                foreach (DataRow item in resultado.Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        Id = (int) item["id"],
                        Cedula = (string) item["cedula"],
                        Nombre = (string) item["nombre"],
                        Direccion = (string) item["direccion"]
                    };
                    lista.Add(cliente);
                }
                conex.Conn.Close();

            }
            catch (NpgsqlException e)
            {
                ExisteError = true;
                MensajeError = e.Message;
            }
            return lista;
        }

        public void Actulizar(Cliente cliente)
        {
            Conexion conex = new Conexion();

            try
            {
                String sql = "UPDATE cliente SET "
                        + " cedula ='" + cliente.Cedula + "',"
                        + " nombre ='" + cliente.Nombre + "',"
                        + " direccion='" + cliente.Direccion + "' "
                         + " WHERE id=" + cliente.Id + " ;";
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sql, conex.Conn);
                npgsqlCommand.ExecuteNonQuery();
                conex.Conn.Close();

            }
            catch (NpgsqlException e)
            {
                ExisteError = true;
                MensajeError = e.Message;
            }
        }
    //post, get , delete, put

        public void Eliminar(Cliente cliente)
        {
            Conexion conex = new Conexion();

            try
            {
                String sql = "DELETE FROM cliente"
                         + " WHERE id=" + cliente.Id + " ;";
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sql, conex.Conn);
                npgsqlCommand.ExecuteNonQuery();
                conex.Conn.Close();

            }
            catch (NpgsqlException e)
            {
                ExisteError = true;
                MensajeError = e.Message;
            }
        }

    }
}
