using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        String Visor;
        Char operacaoAtual;
        bool operacaoUso = true;
        bool operacaoUso1 = false;
        bool operacaoUso2 = false;
        bool pontoUso = false;
        bool igualClique = false;
        double num1;
        double num2;
        double result;
        double memoresult;
        double memoresult1;
        public Form1()
        {
            InitializeComponent();
        }
        public void TestaOperacaoLimpaVisor()
        {
            if ((operacaoUso == true) || (Visor.Equals("0")))
            {
                operacaoUso = false;
                Visor = "";
                lblVisor.Text = ("");
            }
        }
        public void ExecutaOperacao()
        {
            if (operacaoUso2 == false)
            {
                if (operacaoUso1 == true)
                {
                    num2 = double.Parse(lblVisor.Text);
                    switch (operacaoAtual)
                    {
                        case '+':
                            result = num1 + num2;
                            lblVisor.Text = Convert.ToString(result);
                            break;
                        case '-':
                            result = num1 - num2;
                            lblVisor.Text = Convert.ToString(result);
                            break;
                        case 'x':
                            result = num1 * num2;
                            lblVisor.Text = Convert.ToString(result);
                            break;
                        case '÷':
                            if (num2 == 0)
                            {
                                lblVisor.Text = "Impossivel Dividir por ZERO";
                                operacaoUso = true;
                            }
                            else
                            {
                                result = num1 / num2;
                                lblVisor.Text = Convert.ToString(result);
                            }
                            break;
                    }
                    num1 = result;
                }
                else if (operacaoUso1 == false)
                {
                    num1 = double.Parse(lblVisor.Text);
                }
                operacaoUso2 = true;
            }
            operacaoUso1 = true;
            operacaoUso = true;
            pontoUso = false;
        }
        public void Memoria()
        {
            if (operacaoUso1 == true)
            {
                num2 = Double.Parse(lblVisor.Text);
                switch (operacaoAtual)
                {
                    case '+':
                        memoresult = num1 + num2;
                        lblVisor.Text = Convert.ToString(memoresult);
                        break;
                    case '-':
                        memoresult = num1 - num2;
                        lblVisor.Text = Convert.ToString(memoresult);
                        break;
                    case '÷':
                        if (num2 == 0)
                        {
                            lblVisor.Text = "ERROR";
                            operacaoUso = true;
                        }
                        else if (num1 != 0)
                        {
                            memoresult = num1 / num2;
                            lblVisor.Text = Convert.ToString(memoresult);
                        }
                        break;
                    case 'x':
                        memoresult = num1 * num2;
                        lblVisor.Text = Convert.ToString(memoresult);
                        break;
                }
            }
            operacaoUso = true;
        }

        private void btnMMenos_Click(object sender, EventArgs e)
        {
            Memoria();
            memoresult1 = memoresult1 - memoresult;
        }
        private void btnMMais_Click(object sender, EventArgs e)
        {
            Memoria();
            memoresult1 = memoresult1 + memoresult;
        }
        private void btnMMostra_Click(object sender, EventArgs e)
        {
            lblVisor.Text = Convert.ToString(memoresult1);
            operacaoUso = true;
        }
        private void btnDesliga_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblVisor.Text = "0";
            Visor = "0";
            operacaoUso = false;
            operacaoUso1 = false;
            operacaoUso2 = false;
            igualClique = false;
            pontoUso = false;
            num1 = 0;
            num2 = 0;
            result = 0;
            operacaoAtual = ' ';
        }
        private void btnSoma_Click(object sender, EventArgs e)
        {
            ExecutaOperacao();
            operacaoAtual = '+';
        }
        private void btnSubtrai_Click(object sender, EventArgs e)
        {
            ExecutaOperacao();
            operacaoAtual = '-';
        }
        private void btnMultiplica_Click(object sender, EventArgs e)
        {
            ExecutaOperacao();
            operacaoAtual = 'x';
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            ExecutaOperacao();
            operacaoAtual = '÷';
        }
        private void btnPotencia_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(lblVisor.Text);
            result = Math.Pow(num1, 2);
            operacaoUso = true;
            lblVisor.Text = Convert.ToString(result);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(lblVisor.Text);
            
            result = Math.Pow(num1, num2);
            operacaoUso = true;
            lblVisor.Text = Convert.ToString(result);
        }

        private void btnPorcent_Click(object sender, EventArgs e)
        {
            if (operacaoUso2 == false)
            {
                if (operacaoUso1 == true)
                {
                    num2 = double.Parse(lblVisor.Text);
                    switch (operacaoAtual)
                    {
                        case '+':
                            result = num1 + (num1 * (num2 / 100));
                            lblVisor.Text = Convert.ToString(result);
                            break;
                        case '÷':
                            if (num2 == 0)
                            {
                                lblVisor.Text = "ERROR";
                                operacaoUso = true;
                            }
                            else if (num1 != 0)
                            {
                                result = num1 / (num2 / 100);
                                lblVisor.Text = Convert.ToString(result);
                            }
                            break;
                        case '-':
                            result = num1 - (num1 * (num2 / 100));
                            lblVisor.Text = Convert.ToString(result);
                            break;
                        case 'x':
                            result = num1 * (num2 / 100);
                            lblVisor.Text = Convert.ToString(result);
                            break;
                    }
                    num1 = result;
                }
                else if (operacaoUso1 == false)
                {
                    num1 = double.Parse(lblVisor.Text);
                }
                operacaoUso2 = true;
            }
            operacaoUso1 = true;
            operacaoUso = true;
            pontoUso = false;
        }
        private void btnRaiz_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(lblVisor.Text);
            result = Math.Sqrt(num1);
            operacaoUso = true;
            lblVisor.Text = Convert.ToString(result);
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "0";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "1";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "2";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "3";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "4";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "5";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "6";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "7";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "8";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            Visor += "9";
            lblVisor.Text = Convert.ToString(Visor);
        }
        private void btnPonto_Click(object sender, EventArgs e)
        {
            TestaOperacaoLimpaVisor();
            Visor = lblVisor.Text;
            if (pontoUso == false)
            {
                if ((Visor.Equals("0")) || (Visor.Equals("")))
                {
                    lblVisor.Text = Visor = "0.";
                }
                else
                {
                    Visor = lblVisor.Text;
                    lblVisor.Text = Visor += ".";
                }
                pontoUso = true;
            }
        }
        private void btnMLimpa_Click(object sender, EventArgs e)
        {
            memoresult1 = 0;
            memoresult = 0;
        }
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (operacaoUso1 == true)
            {
                if (igualClique == false)
                {
                    num2 = double.Parse(lblVisor.Text);
                    igualClique = true;
                }
                switch (operacaoAtual)
                {
                    case '+':
                        result = num1 + num2;
                        lblVisor.Text = Convert.ToString(result);
                        break;
                    case '-':
                        result = num1 - num2;
                        lblVisor.Text = Convert.ToString(result);
                        break;
                    case 'x':
                        result = num1 * num2;
                        lblVisor.Text = Convert.ToString(result);
                        break;
                    case '÷':
                        if (num2 == 0)
                        {
                            Visor = ("Impossivel Dividir por ZERO");
                            operacaoUso = true;
                        }
                        else
                        {
                            result = num1 / num2;
                            lblVisor.Text = Convert.ToString(result);
                        }
                        break;
                }
                num1 = result;
            }
            else if (operacaoUso1 == false)
            {
                num1 = double.Parse(lblVisor.Text);
            }
            operacaoUso = true;
            operacaoUso1 = true;
            pontoUso = false;
        }
        private void btnCorrige_Click(object sender, EventArgs e)
        {
            if (operacaoUso == false)
            {
                Visor = lblVisor.Text;
                if (Visor.Length > 0)
                {
                    Visor = Convert.ToString((Visor.Length - 1));
                }
                lblVisor.Text = Visor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tranparente();
        }

        //fluflu da tela
     

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics grafico = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(96, 155, 173), 1);
            Rectangle area = new Rectangle(0, 0, this.Width, this.Height - 1);
            LinearGradientBrush blush = new LinearGradientBrush(area, Color.FromArgb(90, 155, 175),
                Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            grafico.FillRectangle(blush, area);
            grafico.DrawRectangle(pen, area);
        }


        //deixar a o visor tranparente
        public void tranparente()
        {
            lblVisor.Parent = this;
            lblVisor.BackColor = Color.AliceBlue;
        }

        private void btnDesliga_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnDesliga.Region = new Region(redondo);
        }

       

        private void btnCorrige_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnCorrige.Region = new Region(redondo);
        }

        private void btnLimpar_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnLimpar.Region = new Region(redondo);
        }

        private void btnMLimpa_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMLimpa.Region = new Region(redondo);
        }

        private void btnMMostra_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMMostra.Region = new Region(redondo);
        }

        private void btnMMais_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMMais.Region = new Region(redondo);
        }

        private void btnMMenos_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMMenos.Region = new Region(redondo);
        }

        private void btnPorcent_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnPorcent.Region = new Region(redondo);
        }

        private void btnRaiz_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnRaiz.Region = new Region(redondo);
        }

        private void btnPotencia_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnPotencia.Region = new Region(redondo);
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            button1.Region = new Region(redondo);
        }

        private void btn1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn1.Region = new Region(redondo);
        }

        private void btn2_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn2.Region = new Region(redondo);
        }

        private void btn3_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn3.Region = new Region(redondo);
        }

        private void btnDivide_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnDivide.Region = new Region(redondo);
        }

        private void btn4_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn4.Region = new Region(redondo);
        }

        private void btn5_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn5.Region = new Region(redondo);
        }

        private void btn6_MouseClick(object sender, MouseEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn6.Region = new Region(redondo);
        }

        private void btnMultiplica_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMultiplica.Region = new Region(redondo);
        }

        private void btn7_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn7.Region = new Region(redondo);
        }

        private void btn8_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn8.Region = new Region(redondo);
        }

        private void btn9_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn9.Region = new Region(redondo);
        }

        private void btnSubtrai_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnSubtrai.Region = new Region(redondo);
        }

        private void btnPonto_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnPonto.Region = new Region(redondo);
        }
   
        private void btn0_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btn0.Region = new Region(redondo);
        }

        private void btnIgual_MouseClick(object sender, MouseEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnIgual.Region = new Region(redondo);
        }

        private void btnSoma_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnSoma.Region = new Region(redondo);
        }

        private void btnMLimpa_Paint_1(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMLimpa.Region = new Region(redondo);
        }

        private void btnMMostra_Paint_1(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMMostra.Region = new Region(redondo);
        }

        private void btnMMais_Paint_1(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMMais.Region = new Region(redondo);
        }

        private void btnMMenos_Paint_1(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnMMenos.Region = new Region(redondo);
        }

        private void btnIgual_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath redondo = new GraphicsPath();
            redondo.AddEllipse(0, 0, btnDesliga.Width, btnDesliga.Height);
            btnIgual.Region = new Region(redondo);
        }
    }
}