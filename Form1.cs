using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datagri
{
    public partial class Form1 : Form
    {
        int codigo = 1;
        public Form1()
        {
            InitializeComponent();
        }
        void limpiar() 
        {
            txtcod.Text = codigo.ToString();
            txtnom.Text = "";
            txtcita.Text = "";
            txttel.Text = "";
            txtfecha.Text = "";
           
        }
        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnom.Text) || string.IsNullOrWhiteSpace(txtcita.Text) ||
              string.IsNullOrWhiteSpace(txttel.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, complete todos los campos.", "Mensaje");
                return;  
            }

            object[] agregardato = 
                    { 
                    codigo.ToString(),
                    txtnom.Text,
                    txtcita.Text, 
                    txttel.Text, 
                    txtfecha.Text,
                    
                    };
                    dataGridView1.Rows.Add(agregardato);
           
            MessageBox.Show("Cita registrada.","Mensaje");
            codigo++;
            txtcod.Text = codigo.ToString();
            limpiar();
        }
        //A3E4D7
        //FFFFFF
        private void Form1_Load(object sender, EventArgs e)
        {
          
            txtcod.Text = codigo.ToString();
           
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E1BEE7");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                int fil = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(fil);
                MessageBox.Show("Cita eliminada.", "Mensaje");
            }
            limpiar();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                int indice = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[indice].Cells[0].Value = txtcod.Text;
                dataGridView1.Rows[indice].Cells[1].Value = txtnom.Text;
                dataGridView1.Rows[indice].Cells[2].Value = txtcita.Text;
                dataGridView1.Rows[indice].Cells[3].Value = txttel.Text;
                dataGridView1.Rows[indice].Cells[4].Value = txtfecha.Text;
              
                MessageBox.Show("Cita modificada.", "Mensaje");
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                int fila = dataGridView1.CurrentCell.RowIndex;
                txtcod.Text = dataGridView1[0, fila].Value.ToString();
                txtnom.Text = dataGridView1[1, fila].Value.ToString();
                txtcita.Text = dataGridView1[2, fila].Value.ToString();
                txttel.Text = dataGridView1[3, fila].Value.ToString();
                txtfecha.Text = dataGridView1[4, fila].Value.ToString();
                
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 225))
            {
                // Mostrar un mensaje de error indicando que solo se permiten números en el campo.
                MessageBox.Show("Por favor llene el campo con solo numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }

        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                // Mostrar un mensaje de error indicando que solo se permiten números en el campo.
                MessageBox.Show("Por favor llene el campo con solo letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }
    }
}
