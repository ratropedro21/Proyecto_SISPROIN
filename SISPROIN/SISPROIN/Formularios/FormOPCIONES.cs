using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Formularios
{
    public partial class FormOPCIONES : Form
    {
        Button[] btn = new Button[3];
        public string Returno = "0";
        public string[] Opc;

        public FormOPCIONES()
        {
            InitializeComponent();
        }

        private void LoadControls()
        {
            // Se crea el boton que movera todos los botones al mismo tiempo
            Button btn = new Button();
            // Se crean 50 botones dinamicamente
            for (int i = 0; i < Opc.Count(); i++)
            {
                btn = new Button();
                btn.Name = (i + 1).ToString();
                btn.Size = new Size(100, 50);
                btn.UseVisualStyleBackColor = true;
                btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btn.Location = new Point(100 * i, 25);
                btn.Text = (i + 1).ToString() + ". " + Opc[i];
                btn.Tag = i.ToString();
                btn.Click += new System.EventHandler(ButtonClick);
                this.panel1.Controls.Add(btn);
            }
            panel1.Width = btn.Width + btn.Left;
            if (this.Width < panel1.Width + panel1.Left)
            {
                if (this.Width < panel1.Width)
                {
                    this.Width = panel1.Width;
                    panel1.Left = 0;
                }
                else
                {
                    panel1.Left = (this.Width - panel1.Width) / 2;
                }
            }
            else
            {
                panel1.Left = (this.Width - panel1.Width) / 2;
            }
        }

        private void ButtonClick(object sender, System.EventArgs e)
        {
            //Modo Manual
            Button btnManual = (Button)sender;
            Returno = btnManual.Text.Substring(0, 1);
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Close();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void FormOPCIONES_Load(object sender, EventArgs e)
        {
            LoadControls();

        }
    }
}
