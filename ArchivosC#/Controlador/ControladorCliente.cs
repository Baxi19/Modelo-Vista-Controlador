using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpTEC.Entidad;
using ErpTEC.Modelo;

namespace ErpTEC.Controlador
{
    public class ControladorCliente
    {
        public bool ExisteError { get; set; } = false;
        public string MensajeError { get; set; } = "";

        public void Crear(Cliente cliente)
        {
            ModeloCliente oModeloCliente = new ModeloCliente();
            oModeloCliente.Crear(cliente);
            if (oModeloCliente.ExisteError)
            {
                ExisteError = true;
                MensajeError = oModeloCliente.MensajeError;
            }
        }

        public List<Cliente> Obtener()
        {
            ModeloCliente oModeloCliente = new ModeloCliente();
            List<Cliente> listaCliente = oModeloCliente.Obtener();
            if (oModeloCliente.ExisteError)
            {
                ExisteError = true;
                MensajeError = oModeloCliente.MensajeError;
            }
            return listaCliente;
        }

        public void Actulizar(Cliente cliente)
        {
            ModeloCliente oModeloCliente = new ModeloCliente();
            oModeloCliente.Actulizar(cliente);
            if (oModeloCliente.ExisteError)
            {
                ExisteError = true;
                MensajeError = oModeloCliente.MensajeError;
            }
        }

        public void Eliminar(Cliente cliente)
        {
            ModeloCliente oModeloCliente = new ModeloCliente();
            oModeloCliente.Eliminar(cliente);
            if (oModeloCliente.ExisteError)
            {
                ExisteError = true;
                MensajeError = oModeloCliente.MensajeError;
            }
        }
    }
}
