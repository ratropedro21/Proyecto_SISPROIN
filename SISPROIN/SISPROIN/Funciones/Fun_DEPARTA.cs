using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Funciones
{
    class Fun_DEPARTA
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " coddpt, nomdpt, stadpt ";
        private Clases._DEPARTA LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._DEPARTA(Dr.GetInt32(0), Dr.GetString(1), Dr.GetInt32(2));
        }

        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT coddpt FROM departa ORDER BY coddpt DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            dr2 = cmd.ExecuteReader();
            if (dr2.HasRows)
            {
                dr2.Read();
                R = dr2.GetInt32(0).ToString();
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                R = (Convert.ToInt32(R) + 1).ToString();
                return R;
            }
            else
            {
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return "1";
            }
        }

        public Clases._DEPARTA BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._DEPARTA usr = new Clases._DEPARTA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM departa ORDER BY coddpt DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
        }
        public Clases._DEPARTA BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._DEPARTA usr = new Clases._DEPARTA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM departa ORDER BY coddpt ASC LIMIT 1 ";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);

            Dr = cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
        }
        public Clases._DEPARTA BuscarAnterior(Clases._DEPARTA DP)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._DEPARTA usr = new Clases._DEPARTA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM departa WHERE coddpt < @coddpt ORDER BY coddpt DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@coddpt", DP.coddpt);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return BuscarPrimero();
            }
        }
        public Clases._DEPARTA BuscarSiguiente(Clases._DEPARTA DP)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._DEPARTA usr = new Clases._DEPARTA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM departa WHERE coddpt > @coddpt ORDER BY coddpt ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@coddpt", DP.coddpt);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return BuscarUltimo();
            }
        }
        public Boolean Nuevo(Clases._DEPARTA DP)
        {
            if (!Existe(DP.coddpt))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO departa (coddpt, nomdpt, stadpt) VALUES (@coddpt, @nomdpt, @stadpt)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@coddpt", DP.coddpt);
                cmd.Parameters.AddWithValue("@nomdpt", DP.nomdpt);
                cmd.Parameters.AddWithValue("@stadpt", DP.stadpt);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._DEPARTA DP)
        {
            if (Existe(DP.coddpt))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE departa SET coddpt = @coddpt, nomdpt = @nomdpt, stadpt = @stadpt WHERE coddpt = @coddpt";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@coddpt", DP.coddpt);
                cmd.Parameters.AddWithValue("@nomdpt", DP.nomdpt);
                cmd.Parameters.AddWithValue("@stadpt", DP.stadpt);
                int retVal = cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                if (retVal == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public Boolean Existe(int vcoddpt)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT coddpt FROM departa WHERE coddpt = @coddpt";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@coddpt", vcoddpt);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return false;
            }
        }

        public Boolean StatudAI(int vcoddpt)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT coddpt FROM departa WHERE coddpt = @coddpt AND stadpt = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@coddpt", vcoddpt);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return false;
            }
        }

        public Clases._DEPARTA Buscar(int vcoddpt)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._DEPARTA usr = new Clases._DEPARTA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM departa WHERE coddpt = @coddpt LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@coddpt", vcoddpt);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return BuscarPrimero();
            }
        }

        public string Sent_NomDpt(int vcoddpt)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT nomdpt FROM departa WHERE coddpt = @coddpt ORDER BY coddpt Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@CodDpt", vcoddpt);
            Dr = cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();
                _ValorR = Dr.GetString(0);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return _ValorR;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return "";
            }
        }

        public void ImprimirListaDP()
        {
            //string fileName = Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            //Document doc = new Document(PageSize.LETTER);
            //PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.OpenOrCreate));
            //doc.Open();
            //iTextSharp.text.Font FuenteTitulo = FontFactory.GetFont("Arial", 22, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            //Paragraph Titulo = new Paragraph("Lista de Departamentos", FuenteTitulo);
            //Titulo.Alignment = Element.ALIGN_CENTER;
            //doc.Add(Titulo);
            //doc.Add(new Paragraph("\n"));
            //PdfPTable table = new PdfPTable(2);
            //iTextSharp.text.Font SubTitulos = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            //PdfPCell clcoddpt = new PdfPCell(new Phrase("Cod. Departamento", SubTitulos));
            //clcoddpt.HorizontalAlignment = Element.ALIGN_CENTER;
            //PdfPCell cldesdpt = new PdfPCell(new Phrase("Desc. Departamentos", SubTitulos));
            //cldesdpt.HorizontalAlignment = Element.ALIGN_CENTER;
            //table.AddCell(clcoddpt);
            //table.AddCell(cldesdpt);
            //dbSQLConn.ConecDb_Abrir();
            //NpgsqlDataReader Rst = null;
            //string strSQL = "SELECT * FROM departa ORDER BY coddpt Asc";
            //if (dbSQLConn.GetDataReader(ref Rst, strSQL))
            //{
            //    while (Rst.Read())
            //    {
            //        table.AddCell(Rst.GetString(0).Trim());
            //        table.AddCell(Rst.GetString(1).Trim());
            //    }
            //    Rst.Close();
            //}
            //dbSQLConn.ConecDb_Close();
            //doc.Add(table);
            //doc.Close();
            //Process prc = new Process();
            //prc.StartInfo.FileName = fileName;
            //prc.Start();
        }

        public void LlenarDpt(ComboBox ComboDPT)
        {
            string vnomdpt = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            string strSQL = "SELECT coddpt, nomdpt FROM departa ORDER BY nomdpt DESC";
            if (dbSQLConn.GetDataReader(ref Rst, strSQL))
            {
                while (Rst.Read())
                {
                    vnomdpt = Rst.GetString(0).Trim() + " - " + Rst.GetString(1).Trim();
                    ComboDPT.Items.Add(vnomdpt);
                }
                Rst.Close();
            }
            dbSQLConn.ConecDb_Close();
        }
    }
}
