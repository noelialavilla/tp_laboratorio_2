using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();

            this.cmbOperador.Items.Add("");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        /// <summary>
        /// obtiene los valores ingresados por el usuario, utiliza el metodo operar() para realizar la operación
        /// correspondiente y luego muestra el resultado en el lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string primerOperando = this.txtNumero1.Text;
            string segundoOperando = this.txtNumero2.Text;
            StringBuilder historial = new StringBuilder();
            char operador;
            if (this.cmbOperador.SelectedItem == null)
            {
                operador = '+';
            }
            else
            {
                operador = Convert.ToChar(this.cmbOperador.SelectedItem.ToString());
            }
            this.lblResultado.Text = (Operar(primerOperando, segundoOperando, operador)).ToString();
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = true;
            historial.AppendLine($"{primerOperando} {operador} {segundoOperando} = {this.lblResultado.Text} ");
            this.lstOperaciones.Items.Add(historial.ToString());

        }

        /// <summary>
        /// utiliza el metodo operar() de la clase Calculadora para realizar la operacion solicitada
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns> double resultado de la operacion solicitada </returns>
        private static double Operar(string numero1, string numero2, char operador)
        {
            Operando primerOperando = new Operando(numero1);
            Operando segundoOperando = new Operando(numero2);

            return Calculadora.Operar(primerOperando, segundoOperando, operador);
        }

        /// <summary>
        /// realiza llamado al método Limpiar()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// resetea a valor por defecto los campos txtNumero1, cmbOperator y txtNumero2
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = String.Empty;
            this.cmbOperador.SelectedIndex = 0;
            this.txtNumero2.Text = String.Empty;
            this.lblResultado.Text = "Resultado";

        }

        /// <summary>
        /// Convierte el resultado de la operación en un numero binario y lo muestra en lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
            this.lstOperaciones.Items.Add(this.lblResultado.Text);
        }

        /// <summary>
        /// Convierte el resultado de la operación previamente convertido a binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.BinarioDecimal(this.lblResultado.Text);
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
            this.lstOperaciones.Items.Add(this.lblResultado.Text);
        }


        /// <summary>
        /// cierra el formulario utilizando formClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// cierra el formulario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
