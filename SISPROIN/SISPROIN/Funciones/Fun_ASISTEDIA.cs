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
    class Fun_ASISTEDIA
    {
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos1 = " codasd, fecasd, staasd ";

        private Clases._ASISTEDIAS LLenar1(NpgsqlDataReader Dr)
        {
            return new Clases._ASISTEDIAS(Dr.GetInt32(0), Dr.GetDateTime(1), Dr.GetInt32(2));
        }


        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codasd FROM asistedia ORDER BY codasd DESC LIMIT 1";
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

        public Clases._ASISTEDIAS BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._ASISTEDIAS usr = new Clases._ASISTEDIAS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM asistedia ORDER BY codasd DESC LIMIT 1";
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
        public Clases._ASISTEDIAS BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._ASISTEDIAS usr = new Clases._ASISTEDIAS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM asistedia ORDER BY codasd ASC LIMIT 1 ";
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
        public Clases._ASISTEDIAS BuscarAnterior(Clases._ASISTEDIAS ASID)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._ASISTEDIAS usr = new Clases._ASISTEDIAS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM asistedia WHERE codasd < @codasd ORDER BY codasd DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codasd", ASID.codasd);
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
        public Clases._ASISTEDIAS BuscarSiguiente(Clases._ASISTEDIAS ASID)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._ASISTEDIAS usr = new Clases._ASISTEDIAS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM asistedia WHERE codasd > @codasd ORDER BY codasd ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codasd", ASID.codasd);
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
        public Boolean Nuevo(Clases._ASISTEDIAS ASID)
        {
            if (!ExisteENC(ASID.codasd))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO asistedia (codasd, fecasd, staasd) VALUES (@codasd, @fecasd, @staasd)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codasd", ASID.codasd);
                cmd.Parameters.AddWithValue("@fecasd", ASID.fecasd);
                cmd.Parameters.AddWithValue("@staasd", ASID.staasd);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Modificar(Clases._ASISTEDIAS ASID)
        {
            if (ExisteENC(ASID.codasd))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE asistedia SET codasd = @codasd, staasd = @staasd WHERE codasd = @codasd ";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codasd", ASID.codasd);
                cmd.Parameters.AddWithValue("@staasd", ASID.staasd);
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

        public Boolean RealizarNuevo(DateTime vfecasd)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codasd  FROM asistedia WHERE fecasd::DATE = @fecasd";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@fecasd ", vfecasd);
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

        public Boolean ExisteENC(int vcodasd)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codasd  FROM asistedia WHERE codasd = @codasd";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codasd ", vcodasd);
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

        public Boolean GuardarDET(Clases._ASISTEDIAS DETASID)
        {
            if (!ExisteDET(DETASID.codasd, DETASID.cedper))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO detasistedia (codasd, cedper, comasd, fecasd) VALUES (@codasd, @cedper, @comasd, @fecasd)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codasd", DETASID.codasd);
                cmd.Parameters.AddWithValue("@cedper", DETASID.cedper);
                cmd.Parameters.AddWithValue("@comasd", DETASID.comasd);
                cmd.Parameters.AddWithValue("@fecasd", DETASID.fecasd);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ExisteDET(int vcodasd, int vcedper)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codasd  FROM detasistedia WHERE codasd = @codasd AND cedper = @cedper";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codasd", vcodasd);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
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



        public Clases._ASISTEDIAS Buscar(int vcodasd)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._ASISTEDIAS usr = new Clases._ASISTEDIAS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM asistedia WHERE codasd = @codasd LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codasd ", vcodasd);
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

        public void GetLisInasisente(int vcodasd, ref ListView Lista)
        {
            dbSQLConn.ConecDb_Abrir();
            string[] arr = new string[8];
            ListViewItem itm;
            Lista.Items.Clear();
            NpgsqlDataReader Dr = null;
            string strSQL = "SELECT DETASISTEDIA.cedper, (PERSONAL.nomper || ' ' || PERSONAL.apeper) AS nompersonal, DETASISTEDIA.comasd FROM DETASISTEDIA " +
                "INNER JOIN PERSONAL ON DETASISTEDIA.cedper = PERSONAL.cedper " +
                "INNER JOIN ASISTEDIA ON ASISTEDIA.codasd = DETASISTEDIA.codasd " +
                "WHERE ASISTEDIA.codasd = @codasd AND ASISTEDIA.staasd = 1 " +
                "ORDER BY ASISTEDIA.codasd ASC ";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codasd", vcodasd);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                int COLC = 0;
                while (Dr.Read())
                {
                    arr[0] = Dr.GetInt32(0).ToString();
                    arr[1] = Dr.GetString(1).Trim();
                    arr[2] = Dr.GetString(2).Trim();
                    itm = new ListViewItem(arr);
                    Lista.Items.Add(itm);
                }
                Dr.Close();
                if (COLC % 2 == 0)
                {
                    Lista.Items[COLC].BackColor = Color.AliceBlue;
                }
                COLC++;
                dbSQLConn.ConecDb_Close();
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
            }
        }

        public bool EliminarDET(Clases._ASISTEDIAS usr)
        {
            dbSQLConn.ConecDb_Abrir();
            string strSQL = "DELETE FROM detasistedia WHERE codasd = @codasd";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codasd", usr.codasd);
            cmd.ExecuteNonQuery();
            dbSQLConn.ConecDb_Close();
            return true;
        }

        public Boolean InasistenciaDia(int vcedper, DateTime vfecasd)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT cedper, fecasd  FROM detasistedia WHERE cedper = @cedper AND fecasd::DATE = @fecasd::DATE";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
            cmd.Parameters.AddWithValue("@fecasd", vfecasd);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return false;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return true;
            }
        }
    }
}
