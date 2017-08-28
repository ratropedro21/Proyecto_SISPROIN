using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Clases
{
    class ConectarDB
    {
        public NpgsqlConnection Cnn = null;

        public ConectarDB()
        {
            //Ini();
        }
        
        public void Ini()
        {
            string Str;
            //Conexion Local
            //Str = "HOST = 127.0.0.1;Port = 5432;User Id = postgres;Password = 123456789;Database = todovitodb;TIMEOUT = 15;POOLING = True;MINPOOLSIZE = 1;MAXPOOLSIZE = 20;COMMANDTIMEOUT = 20";
            
            //Conexion Todovito
            //Str = "HOST = 10.10.1.2;Port = 5432;User Id = postgres;Password = 123456789;Database = todovitodb;TIMEOUT = 15;POOLING = True;MINPOOLSIZE = 1;MAXPOOLSIZE = 20;COMMANDTIMEOUT = 20";
           
            //Str = "Server = 192.168.1.7; Port = 5432; Database = pymdb; User Id = postgres; Password = 123456789;";
            //Str = "Data Source=PEDRO-PC;Initial Catalog=PYMBASED;Persist Security Info=True;User ID=sa;Password=123456789";


            try
            {
                StreamReader objReader = new StreamReader(Directory.GetCurrentDirectory() + "\\Config_Cnn.Txt");
                //string sLine = " ";
                Str = objReader.ReadLine();
                //while (sLine != null)
                //{
                //    sLine = objReader.ReadLine();
                //    if (sLine != null)
                //        Str = sLine;
                //}
                objReader.Close();
                Cnn = new NpgsqlConnection(Str);
                Cnn.Open();
              
            }
            catch (Exception)
            {
                MessageBox.Show("Se perdió comunicación con la base de dato.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                Str = "HOST = 127.0.0.1;Port = 5432;User Id = postgres;Password = 123456789;Database = todovitodb;TIMEOUT = 15;POOLING = True;MINPOOLSIZE = 1;MAXPOOLSIZE = 20;COMMANDTIMEOUT = 20";
                //Str = "HOST = 10.10.1.2;Port = 5432;User Id = postgres;Password = 123456789;Database = todovitodb;TIMEOUT = 15;POOLING = True;MINPOOLSIZE = 1;MAXPOOLSIZE = 20;COMMANDTIMEOUT = 20";
                StreamWriter obj = new StreamWriter(Directory.GetCurrentDirectory() + "\\Config_Cnn.Txt");
                obj.WriteLine(Str);
                obj.Close();
                Environment.Exit(-1);
            }
        }
        public void ConecDb_Abrir()
        {
            Ini();
        }
        public void ConecDb_Close()
        {
            Cnn.Close();
        }
        public bool GetDataReader(ref NpgsqlDataReader dr2, String Sql)
        {
            NpgsqlCommand cmd = Cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Cnn;
            cmd.CommandText = Sql;
            dr2 = cmd.ExecuteReader();
            if (dr2.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Inset(string Sql)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, Cnn);
            cmd.ExecuteNonQuery();
        }
        public int Update(string Sql)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, Cnn);
            int Cantidad = cmd.ExecuteNonQuery();
            return Cantidad;
        }
        public bool GetDataSet(ref DTSet.DTSDATOS DS, string Sql, string TABLADS)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, Cnn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(DS, TABLADS);
            if (DS.Tables[TABLADS].Rows.Count != 0)
            {
                return true;
            }
            else
            {
                //MessageBox.Show("No hay Datos en el DataSet", "Atención",
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Exclamation,
                //                MessageBoxDefaultButton.Button1);
                return false;
            }
        }
        public bool GetDataTable(ref DataTable TABLADT, string Sql)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, Cnn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            if (da.Fill(TABLADT) != 0)
            {
                return true;
            }
            else
            {
                //MessageBox.Show("No hay Datos en el DataTable", "Atención",
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Exclamation,
                //                MessageBoxDefaultButton.Button1);
                return false;
            }
        }
    }
}
