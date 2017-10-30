using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace TP_1_Laboratorio_II
{
    public partial class Form1 : Form
    {
        Numero numero1;
        Numero numero2;
        double resultado;
        
        /// <summary>
        /// Inicializa los componentes gráficos.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Limpia los textBox de numero1 y numero2 y el label del Resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = "";
            this.lblResultado.Text = "Resultado: ";
        }
        /// <summary>
        /// Instancia los objetos Numero para operar y realiza la operacion requerida 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            numero1 = new Numero(this.txtNumero1.Text);
            numero2 = new Numero(this.txtNumero2.Text);
            
            resultado = Calculadora.Operar(numero1, numero2, this.cmbOperacion.Text);
            this.lblResultado.Text = "Resultado: " + resultado.ToString();
        }
    }
}
