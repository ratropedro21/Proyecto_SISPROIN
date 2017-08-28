using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Funciones
{
    class Fun_MOVINV
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos1 = " codmov, fecmov, tiptra, commov, dotmov, stamov ";

        private Clases._MOVINV LLenar1(NpgsqlDataReader Dr)
        {
            return new Clases._MOVINV(Dr.GetInt32(0), Dr.GetDateTime(1), Dr.GetString(2),Dr.GetString(3), Dr.GetString(4), Dr.GetInt32(5));
        }


        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codmov FROM docmovinv ORDER BY codmov DESC LIMIT 1";
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

        public Clases._MOVINV BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._MOVINV usr = new Clases._MOVINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM docmovinv ORDER BY codmov DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar1(Dr);
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
        public Clases._MOVINV BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._MOVINV usr = new Clases._MOVINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM docmovinv ORDER BY codmov ASC LIMIT 1 ";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);

            Dr = cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar1(Dr);
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
        public Clases._MOVINV BuscarAnterior(Clases._MOVINV DOCMOV)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._MOVINV usr = new Clases._MOVINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM docmovinv WHERE codmov < @codmov ORDER BY codmov DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", DOCMOV.codmov);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar1(Dr);
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
        public Clases._MOVINV BuscarSiguiente(Clases._MOVINV DOCMOV)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._MOVINV usr = new Clases._MOVINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM docmovinv WHERE codmov > @codmov ORDER BY codmov ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", DOCMOV.codmov);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar1(Dr);
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
        public Boolean Nuevo(Clases._MOVINV clas)
        {
            if (!Existe(clas.codmov))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO docmovinv (codmov, fecmov, tiptra, commov, dotmov, stamov) VALUES (@codmov, @fecmov, @tiptra, @commov, @dotmov, @stamov)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codmov", clas.codmov);
                cmd.Parameters.AddWithValue("@fecmov", clas.fecmov);
                cmd.Parameters.AddWithValue("@tiptra", clas.tiptra);
                cmd.Parameters.AddWithValue("@commov", clas.commov);
                cmd.Parameters.AddWithValue("@dotmov", clas.dotmov);
                cmd.Parameters.AddWithValue("@stamov", clas.stamov);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean NuevoDET(Clases._MOVINV clas)
        {
            if (!ExisteMOVINV(clas.codmov, clas.cedper, clas.codpro, clas.tiptra, clas.tiptid))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO movinv (codmov, cedper, codpro, fecmov, tiptra, canmov, catmov, cosmov, predoc, totmov, tiptid, undunm, tiptiv, stamov, usuusu) "
                    + "VALUES (@codmov, @cedper, @codpro, @fecmov, @tiptra, @canmov, @catmov, @cosmov, @predoc, @totmov, @tiptid, @undunm, @tiptiv, @stamov, @usuusu)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codmov", clas.codmov);
                cmd.Parameters.AddWithValue("@cedper", clas.cedper);
                cmd.Parameters.AddWithValue("@codpro", clas.codpro);
                cmd.Parameters.AddWithValue("@fecmov", clas.fecmov);
                cmd.Parameters.AddWithValue("@tiptra", clas.tiptra);
                cmd.Parameters.AddWithValue("@canmov", clas.canmov);
                cmd.Parameters.AddWithValue("@catmov", clas.catmov);
                cmd.Parameters.AddWithValue("@cosmov", clas.cosmov);
                cmd.Parameters.AddWithValue("@predoc", clas.predoc);
                cmd.Parameters.AddWithValue("@totmov", clas.totmov);
                cmd.Parameters.AddWithValue("@tiptid", clas.tiptid);
                cmd.Parameters.AddWithValue("@undunm", clas.undunm);
                cmd.Parameters.AddWithValue("@tiptiv", clas.tiptiv);
                cmd.Parameters.AddWithValue("@stamov", clas.stamov);
                cmd.Parameters.AddWithValue("@usuusu", clas.usuusu);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }


        public Boolean AnularENC_MOV(Clases._MOVINV clas)
        {
            if (Existe(clas.codmov))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE docmovinv SET codmov = @codmov, stamov = @stamov WHERE codmov = @codmov";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codmov", clas.codmov);
                cmd.Parameters.AddWithValue("@stamov", clas.stamov);
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

        public Boolean AnularDET_MOV(Clases._MOVINV clas)
        {
            if (Existe(clas.codmov))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE movinv SET codmov = @codmov, stamov = @stamov WHERE codmov = @codmov AND tiptid= 'INV'";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codmov", clas.codmov);
                cmd.Parameters.AddWithValue("@stamov", clas.stamov);
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

        public Boolean AnularDET_OBS(Clases._MOVINV clas)
        {
            dbSQLConn.ConecDb_Abrir();
            string Sql = "UPDATE movinv SET codmov = @codmov, stamov = @stamov WHERE codmov = @codmov AND tiptid= 'OBS'";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", clas.codmov);
            cmd.Parameters.AddWithValue("@stamov", clas.stamov);
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

        public Boolean Existe(int vcodmov)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codmov FROM docmovinv WHERE codmov = @codmov";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", vcodmov);
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

        public Boolean ExisteMOVINV(int vcodmov, int vcedper, int vcodpro, string vtiptra, string vtiptid)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codmov FROM movinv WHERE codmov = @codmov AND cedper = @cedper AND codpro = @codpro AND tiptra = @tiptra AND tiptid = @tiptid ";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", vcodmov);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
            cmd.Parameters.AddWithValue("@tiptra", vtiptra);
            cmd.Parameters.AddWithValue("@tiptid", vtiptid);
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

        public Clases._MOVINV Buscar(int vcodmov)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._MOVINV usr = new Clases._MOVINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM docmovinv WHERE codmov = @codmov LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", vcodmov);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar1(Dr);
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

        public void GetLisMOVINVENTARIO(int vcodmov, ListView Lista)
        {
            dbSQLConn.ConecDb_Abrir();
            string[] arr = new string[7];
            ListViewItem itm;
            Lista.Items.Clear();
            NpgsqlDataReader Dr = null;
            string strSQL = "SELECT MOVINV.codpro, PRODUCTOS.despro, MOVINV.undunm, MOVINV.canmov, MOVINV.catmov, MOVINV.cosmov, MOVINV.totmov "
                + "FROM MOVINV INNER JOIN PRODUCTOS ON MOVINV.codpro = PRODUCTOS.codpro "
                + "WHERE MOVINV.codmov = @codmov AND MOVINV.tiptid= 'INV' "
                + "ORDER BY MOVINV.codpro ASC ";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", vcodmov);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                int COLC = 0;
                while (Dr.Read())
                {
                    arr[0] = Dr.GetInt32(0).ToString().PadLeft(8, '0');
                    arr[1] = Dr.GetString(1).Trim();
                    arr[2] = Dr.GetString(2).Trim();
                    arr[3] = string.Format("{0:0.00}", Dr.GetDecimal(3));
                    arr[4] = Dr.GetInt32(4).ToString();
                    arr[5] = string.Format("{0:0.00}", Dr.GetDecimal(5));
                    arr[6] = string.Format("{0:0.00}", Dr.GetDecimal(6));
                    itm = new ListViewItem(arr);
                    Lista.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        Lista.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                Dr.Close();
                dbSQLConn.ConecDb_Close();
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
            }
        }

        public Clases._MOVINV [] SearchTransByPersoRangeDate(string tiptra, int cedper, DateTime from, DateTime to)
        {
            dbSQLConn.ConecDb_Abrir();
            List<Clases._MOVINV> items = new List<Clases._MOVINV>();
            NpgsqlDataReader Dr = null;
            string strSQL = $"SELECT {Clases._MOVINV.attr} FROM movinv WHERE tiptra = @tiptra  AND cedper = @cedper AND fecmov >= @from AND fecmov <= @to AND stamov = 1 ";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", tiptra);
            cmd.Parameters.AddWithValue("@cedper", cedper);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    items.Add(Clases._MOVINV.ByDr(Dr));
                }
                Dr.Close();
                dbSQLConn.ConecDb_Close();
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();

            }
            return items.ToArray();
        }

        public void GetLisOBSEQUIO(int vcodmov, ListView Lista)
        {
            dbSQLConn.ConecDb_Abrir();
            string[] arr = new string[5];
            ListViewItem itm;
            Lista.Items.Clear();
            NpgsqlDataReader Dr = null;
            string strSQL = "SELECT MOVINV.codpro, PRODUCTOS.despro, MOVINV.undunm, MOVINV.canmov, MOVINV.catmov, MOVINV.tiptra "
                + "FROM MOVINV INNER JOIN PRODUCTOS ON MOVINV.codpro = PRODUCTOS.codpro "
                + "WHERE MOVINV.codmov = @codmov AND MOVINV.tiptid= 'OBS' "
                + "ORDER BY MOVINV.codpro ASC ";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", vcodmov);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                int COLC = 0;
                while (Dr.Read())
                {
                    if (Dr.GetString(5) == "S006")
                    {
                        arr[0] = Dr.GetInt32(0).ToString().PadLeft(8, '0');
                        arr[1] = Dr.GetString(1).Trim()+" CUMPLEAÑO";
                        arr[2] = Dr.GetString(2).Trim();
                        arr[3] = string.Format("{0:0.00}", Dr.GetDecimal(3));
                        arr[4] = Dr.GetInt32(4).ToString();
                    }
                    else if (Dr.GetString(5) == "S007")
                    {
                        arr[0] = Dr.GetInt32(0).ToString().PadLeft(8, '0');
                        arr[1] = Dr.GetString(1).Trim() + " VACACIONES";
                        arr[2] = Dr.GetString(2).Trim();
                        arr[3] = string.Format("{0:0.00}", Dr.GetDecimal(3));
                        arr[4] = Dr.GetInt32(4).ToString();
                    }
                    else
                    {
                        arr[0] = Dr.GetInt32(0).ToString().PadLeft(8, '0');
                        arr[1] = Dr.GetString(1).Trim();
                        arr[2] = Dr.GetString(2).Trim();
                        arr[3] = string.Format("{0:0.00}", Dr.GetDecimal(3));
                        arr[4] = Dr.GetInt32(4).ToString();
                    }
                    itm = new ListViewItem(arr);
                    Lista.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        Lista.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                Dr.Close();
                dbSQLConn.ConecDb_Close();
               
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
            }
        }

        public bool ExistenciaINV(int vcodpro, decimal vcanmov)
        {
            decimal nExiste = 0;
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT SUM(movinv.canmov*CASE WHEN LEFT(movinv.tiptra,1)='E' THEN 1 ELSE -1 END) AS EXISTE " +
                "FROM productos INNER JOIN movinv ON productos.codpro = movinv.codpro " +
                "WHERE movinv.codpro = @codpro AND movinv.stamov = 1" +
                "GROUP BY productos.despro, productos.undunm, productos.tiptiv, productos.prepro";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                nExiste = Dr.GetDecimal(0);
                if (nExiste >= vcanmov)
                {
                    Dr.Close();
                    dbSQLConn.ConecDb_Close();
                    return true;
                }
                else
                {
                    Dr.Close();
                    dbSQLConn.ConecDb_Close();
                    MessageBox.Show("La cantidad supera la existencia lo cual es actualmente [" + nExiste + "]", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;

                }
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                MessageBox.Show("Actualmente el producto no posee existencia en el inventario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        public int QuantityEmployeeMotion(string TipTra, int CePer, DateTime from, DateTime to)
        {
            Int32 R = 0;
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = $"SELECT COUNT(codpro)::integer AS R FROM movinv " +
                $"WHERE tiptra = @tiptra AND cedper = @cedper AND(fecmov::DATE BETWEEN @from AND @to) " +
                $"AND stamov = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", TipTra);
            cmd.Parameters.AddWithValue("@cedper", CePer);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            dr2 = cmd.ExecuteReader();
            if (dr2.HasRows)
            {
                dr2.Read();
                R = dr2.GetInt32(0);
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return R;
            }
            else
            {
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return 0;
            }
        }

        public bool QuantityProductsMotion(string TipTra, int CePer, int CodPro, DateTime from, DateTime to)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = $"SELECT codmov FROM movinv " +
                $"WHERE tiptra = @tiptra AND cedper = @cedper AND codpro = @codpro AND (fecmov::DATE BETWEEN @from AND @to) " +
                $"AND stamov = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", TipTra);
            cmd.Parameters.AddWithValue("@cedper", CePer);
            cmd.Parameters.AddWithValue("@codpro", CodPro);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            dr2 = cmd.ExecuteReader();
            if (dr2.HasRows)
            {
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return false;
            }
            else
            {
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return true;
            }
        }

    }
}

