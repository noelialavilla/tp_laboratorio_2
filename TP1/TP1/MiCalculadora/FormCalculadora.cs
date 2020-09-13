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
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// obtiene los valores ingresados por el usuario, utiliza el metodo operar() para realizar la operación
        /// correspondiente y luego muestra el resultado en el lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            string primerOperando = this.txtNumero1.Text;
            string segundoOperando = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;
            this.lblResultado.Text = (Operar(primerOperando, segundoOperando, operador)).ToString();
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// utiliza el metodo operar() de la clase Calculadora para realizar la operacion solicitada
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns> double resultado de la operacion solicitada </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero primerOperando = new Numero(numero1);
            Numero segundoOperando = new Numero(numero2);

            return Calculadora.Operar(primerOperando, segundoOperando, operador);
        }

        /// <summary>
        /// realiza llamado al método Limpiar()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
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
            this.cmbOperador.Text = "+";
            this.txtNumero2.Text = String.Empty;
            this.lblResultado.Text = String.Empty;
            
        }

        /// <summary>
        /// cierra el formulario mediante el metodo Dispose()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
