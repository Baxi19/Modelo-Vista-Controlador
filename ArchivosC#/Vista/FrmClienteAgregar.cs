using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpTEC.Vista
{
    public partial class FrmClienteAgregar : Form
    {
        public Boolean aceptar = false;
        public Boolean actualizar = false;

        public FrmClienteAgregar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar = true;

            this.Hide();
        }
    }
}
