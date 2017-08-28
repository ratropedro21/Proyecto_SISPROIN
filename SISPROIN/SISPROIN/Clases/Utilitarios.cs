using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Clases
{
    class Utilitarios
    {
        public string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        public DateTime GetDate()
        {
            ConectarDB Cnn = new ConectarDB();
            DateTime Regreso;
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            Cnn.GetDataReader(ref Rst, "SELECT current_timestamp");
            Rst.Read();
            Regreso = Rst.GetDateTime(0);
            Rst.Close();
            Cnn.ConecDb_Close();
            return Regreso;
        }
        public void SoloNumero(KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                // MessageBox.Show("SOLO SE PERMITEN NUMEROS", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        public void SoloLetras(KeyPressEventArgs e)
        {
            //if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
        }
        public decimal FormatDecimal(string ValorEntrada)
        {
            decimal ValorSalida = 0;
            //cultura ingles
            CultureInfo cultureDefault = CultureInfo.CreateSpecificCulture("en-US");
            NumberStyles styleDefault = NumberStyles.AllowDecimalPoint;
            Boolean Convierte = decimal.TryParse(ValorEntrada, styleDefault, cultureDefault, out ValorSalida);
            if (Convierte == false)
            {
                //si da error convierte usando la cultura Español
                NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
                decimal.TryParse(ValorEntrada, style, culture, out ValorSalida);
            }
            return ValorSalida;
        }

        public void SoloNumeroDecimales(object sender, KeyPressEventArgs e, TextBox TXT)
        {
            //if (e.KeyChar == (char)(Keys.Enter))
            //{
            //    e.Handled = true;
            //    SendKeys.Send("{TAB}");
            //}
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;
            int nroInt = 0;

            for (int i = 0; i < TXT.Text.Length; i++)
            {
                if (TXT.Text[i] == ',' || TXT.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2) // Cantidad Maxima de decimales
                {
                    e.Handled = true;
                    return;
                }
                if (!IsDec)
                {
                    nroInt++;
                }
            }
            if (!IsDec && nroInt == 12 && e.KeyChar != 46 && e.KeyChar != 44) //Cantidad Maxima de Numeros Interos
                e.Handled = true;
            else
            {
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46 || e.KeyChar == 44)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }

        public void MastMayuscula(object sender, KeyPressEventArgs e, MaskedTextBox MTXT)
        {
            e.KeyChar = (char)Encoding.ASCII.GetBytes(e.KeyChar.ToString().ToUpper())[0];
        }

        public void CambiarTxt(TextBox Actual, TextBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(TextBox Actual, ComboBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(ComboBox Actual, TextBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(ComboBox Actual, ComboBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(MaskedTextBox Actual, MaskedTextBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(TextBox Actual, MaskedTextBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(MaskedTextBox Actual, TextBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(DateTimePicker Actual, DateTimePicker Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
        }
        public void CambiarTxt(DateTimePicker Actual, TextBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(TextBox Actual, DateTimePicker Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
        }
        public void CambiarTxt(MaskedTextBox Actual, DateTimePicker Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
        }
        public void CambiarTxt(DateTimePicker Actual, MaskedTextBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(DateTimePicker Actual, ComboBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(ComboBox Actual, DateTimePicker Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
        }
        public void CambiarTxt(ComboBox Actual, MaskedTextBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
        public void CambiarTxt(MaskedTextBox Actual, ComboBox Nuevo)
        {
            Actual.Enabled = false;
            Actual.BackColor = System.Drawing.Color.White;
            Nuevo.Enabled = true;
            Nuevo.BackColor = System.Drawing.Color.Turquoise;
            Nuevo.Focus();
            Nuevo.SelectAll();
        }
    }
}
