using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_WF
{
    public partial class Form1 : Form
    {
        private Numero numero1;
        private Numero numero2;
        private double resultado;
        private string operador;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculadora";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            this.numero1 = new Numero(this.txtNumero1.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            this.numero2 = new Numero(this.txtNumero2.Text);
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculadora c = new Calculadora();
            this.operador = c.validarOperador(this.cmbOperacion.Text);
            //this.operador = this.cmbOperacion.Text;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.resultado = Calculadora.operar(this.numero1, this.numero2, this.operador);
            this.lblResultado.Text = this.resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = "";
            this.lblResultado.Text = "";
        }
    }
}
