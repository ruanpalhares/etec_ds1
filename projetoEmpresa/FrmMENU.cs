using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoEmpresa
{
    public partial class frmMENU : Form
    {
        public frmMENU()
        {
            InitializeComponent();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // se formularios abertos do tipo <nomeForm> maior que zero
            if (Application.OpenForms.OfType<FrmDep>().Count() > 0)

                // deixa o formulario ja aberto em primeiro plano
                Application.OpenForms.OfType<FrmDep>().First().Focus();
            else
            {
                var frmDep = new FrmDep(); // Define quem o pai desta janela
                frmDep.MdiParent = this;
                frmDep.Show();
            }
        }
        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FrmFuncionario>().Count() > 0)

                Application.OpenForms.OfType<FrmFuncionario>().First().Focus();
            else
            {
                var frmFunc = new FrmFuncionario(); // Define quem o pai desta janela
                frmFunc.MdiParent = this;
                frmFunc.Show();
            }
        }
    }
}
