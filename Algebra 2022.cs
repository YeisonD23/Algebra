using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Algebra
{
    public partial class Form1 : Form
    {

        Operaciones Op = new Operaciones();
        Form2 frm2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        #region Métodos
        private void button1_Click(object sender, EventArgs e)
        {
            Op.LlenarA(txtFilas, txtColumnas);
            Op.MostrarA(dataGMatriz);
        }

        private void btnMatrizB_Click(object sender, EventArgs e)
        {
            Op.LlenarB(txtFilas2, txtColumnas2);
            Op.MostrarB(dataGMatrizB);
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            Op.Sumar(datagMatrizR);
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            Op.Restar(datagMatrizR);
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            Op.Multiplicar(datagMatrizR);
        }

        private void btnEscalar_Click(object sender, EventArgs e)
        {
            Op.Escalar(txtEscalar);
            Op.MostrarEscalar(datagMatrizR);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Op.Transpuesta(datagMatrizR);
        }

        private void btnOpuesta_Click(object sender, EventArgs e)
        {
            Op.Opuesta(datagMatrizR);
        }
        private void button4_Click(object sender, EventArgs e)
        {          
            
            dataGMatriz.Columns.Clear();
            dataGMatrizB.Columns.Clear();
            datagMatrizR.Columns.Clear();
            dataGMatriz.Rows.Clear();
            dataGMatrizB.Rows.Clear();
            datagMatrizR.Rows.Clear();

            txtEscalar.Clear();

            txtFilas.Text = "FILAS";
            txtFilas.ForeColor = Color.DimGray;
            txtColumnas.Text = "COLUMNAS";
            txtColumnas.ForeColor = Color.DimGray;

            txtFilas2.Text = "FILAS";
            txtFilas2.ForeColor = Color.DimGray;
            txtColumnas2.Text = "COLUMNAS";
            txtColumnas2.ForeColor = Color.DimGray;
        }
        #endregion



        #region mover arrastar formulario
       
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region TextBox
        private void txtFilas_Enter(object sender, EventArgs e)
        {
            if (txtFilas.Text == "FILAS")
            {
                txtFilas.Text = "";
                txtFilas.ForeColor = Color.LightGray;
            }
        }

        private void txtFilas_Leave(object sender, EventArgs e)
        {
            if (txtFilas.Text == "")
            {
                txtFilas.Text = "FILAS";
                txtFilas.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtColumnas.Text == "COLUMNAS")
            {
                txtColumnas.Text = "";
                txtColumnas.ForeColor = Color.LightGray;
            }
        }

        private void txtColumnas_Leave(object sender, EventArgs e)
        {
            if (txtColumnas.Text == "")
            {
                txtColumnas.Text = "COLUMNAS";
                txtColumnas.ForeColor = Color.DimGray;
            }
        }
        #endregion

        #region Cerrar minizar forma con PictureBox
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtFilas2_Enter(object sender, EventArgs e)
        {
            if (txtFilas2.Text == "FILAS")
            {
                txtFilas2.Text = "";
                txtFilas2.ForeColor = Color.LightGray;
            }

        }

        private void txtFilas2_Leave(object sender, EventArgs e)
        {
            if (txtFilas2.Text == "")
            {
                txtFilas2.Text = "FILAS";
                txtFilas2.ForeColor = Color.DimGray;
            }
        }

        private void txtColumnas2_Enter(object sender, EventArgs e)
        {
            if (txtColumnas2.Text == "COLUMNAS")
            {
                txtColumnas2.Text = "";
                txtColumnas2.ForeColor = Color.LightGray;
            }
        }

        private void txtColumnas2_Leave(object sender, EventArgs e)
        {
            if (txtColumnas2.Text == "")
            {
                txtColumnas2.Text = "COLUMNAS";
                txtColumnas2.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        #endregion

        private void btnGauss_Click(object sender, EventArgs e)
        {            
            OpenForm(frm2);
        }

        public void OpenForm(Form Principal)
        {
            if (this.Mainpanel.Controls.Count > 0)
            {
                this.Mainpanel.Controls.RemoveAt(0);
            }

            Principal.TopLevel = false;
            Principal.FormBorderStyle = FormBorderStyle.None;
            Principal.Dock = DockStyle.Fill;
            this.Mainpanel.Controls.Add(Principal);
            this.Mainpanel.Tag = Principal;
            this.Mainpanel.Visible = true;
            Principal.Show();
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            this.Mainpanel.Visible = false;            
        }

        private void btnMe_Inversa_Click(object sender, EventArgs e)
        {
            Op.LlenarA(txtFilas, txtColumnas);
            Op.Metodo_Inversa(dataGMatriz);
        }
    }
}
