using System;
using System.Windows.Forms;
using ErpTEC.Controlador;
using ErpTEC.Entidad;

namespace ErpTEC.Vista
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void CargaDatos()
        {
            ControladorCliente oControladorCliente = new ControladorCliente();
            dtgClientes.DataSource=oControladorCliente.Obtener();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClienteAgregar oFrmClienteAgregar=new FrmClienteAgregar();
            oFrmClienteAgregar.ShowDialog();
            ControladorCliente oControladorCliente=new ControladorCliente();
            Cliente oCliente=new Cliente();
            oCliente.Cedula = oFrmClienteAgregar.txtCedula.Text;
            oCliente.Cedula = oFrmClienteAgregar.txtDireccion.Text;
            oCliente.Cedula = oFrmClienteAgregar.txtNombre.Text;
            if (oFrmClienteAgregar.aceptar) { 
                oControladorCliente.Crear(oCliente);
                if (!oControladorCliente.ExisteError)
                {
                    MessageBox.Show("Mensaje","Todo calidad!", MessageBoxButtons.OK);
                }
                else {
                    MessageBox.Show("Mensaje", "Calavera, hay algo mal!", MessageBoxButtons.OK);
                }

            }
            oFrmClienteAgregar.Close();
            this.CargaDatos();
        }
    }
}
