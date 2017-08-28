using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Funciones
{
    class Fun_VENOBSDOC
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos1 = " codmov, cedper, fecdoc, netdoc, brudoc, mtidoc, codrec, tiptid, cxcdoc, estdoc, condoc, stadoc, comdoc ";

        private Clases._VENOBSDOC LLenar1(NpgsqlDataReader Dr)
        {
            return new Clases._VENOBSDOC(Dr.GetInt32(0), Dr.GetInt32(1), Dr.GetDateTime(2), Dr.GetDecimal(3), Dr.GetDecimal(4), Dr.GetDecimal(5), Dr.GetInt32(6), Dr.GetString(7), Dr.GetInt32(8), Dr.GetString(9), Dr.GetString(10), Dr.GetInt32(11), Dr.GetString(12));
        }

        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codmov FROM ventobsdoc ORDER BY codmov DESC LIMIT 1";
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

        public Clases._VENOBSDOC BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._VENOBSDOC usr = new Clases._VENOBSDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM ventobsdoc ORDER BY codmov DESC LIMIT 1";
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

        public Clases._VENOBSDOC BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._VENOBSDOC usr = new Clases._VENOBSDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM ventobsdoc ORDER BY codmov ASC LIMIT 1 ";
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
        public Clases._VENOBSDOC BuscarAnterior(Clases._VENOBSDOC VOD)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._VENOBSDOC usr = new Clases._VENOBSDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM ventobsdoc WHERE codmov < @codmov ORDER BY codmov DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", VOD.codmov);
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
        public Clases._VENOBSDOC BuscarSiguiente(Clases._VENOBSDOC VOD)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._VENOBSDOC usr = new Clases._VENOBSDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM ventobsdoc WHERE codmov > @codmov ORDER BY codmov ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", VOD.codmov);
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
        public Boolean NuevoOBS(Clases._VENOBSDOC clas)
        {
            if (!ExisteOBS(clas.codmov, clas.cedper, clas.codrec, clas.tiptid))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO ventobsdoc (codmov, cedper, fecdoc, netdoc, brudoc, mtidoc, codrec, tiptid, cxcdoc, estdoc, condoc, stadoc, comdoc) " +
                    "VALUES (@codmov, @cedper, @fecdoc, @netdoc, @brudoc, @mtidoc, @codrec, @tiptid, @cxcdoc, @estdoc, @condoc, @stadoc, @comdoc)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codmov", clas.codmov);
                cmd.Parameters.AddWithValue("@cedper", clas.cedper);
                cmd.Parameters.AddWithValue("@fecdoc", clas.fecdoc);
                cmd.Parameters.AddWithValue("@netdoc", clas.netdoc);
                cmd.Parameters.AddWithValue("@brudoc", clas.brudoc);
                cmd.Parameters.AddWithValue("@mtidoc", clas.mtidoc);
                cmd.Parameters.AddWithValue("@codrec", clas.codrec);
                cmd.Parameters.AddWithValue("@tiptid", clas.tiptid);
                cmd.Parameters.AddWithValue("@cxcdoc", clas.cxcdoc);
                cmd.Parameters.AddWithValue("@estdoc", clas.estdoc);
                cmd.Parameters.AddWithValue("@condoc", clas.condoc);
                cmd.Parameters.AddWithValue("@stadoc", clas.stadoc);
                cmd.Parameters.AddWithValue("@comdoc", clas.comdoc);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }


        public Boolean AnularENC_OBS(Clases._VENOBSDOC clas)
        {
            if (ExisteOBS(clas.codmov, clas.cedper, clas.codrec, clas.tiptid))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE ventobsdoc SET codmov = @codmov, stadoc = @stadoc  WHERE codmov = @codmov ";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codmov", clas.codmov);
                cmd.Parameters.AddWithValue("@stadoc", clas.stadoc);
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

        public Boolean ExisteOBS(int vcodmov, int vcedper, int vcodrec, string vtiptid)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codmov FROM ventobsdoc WHERE codmov = @codmov AND cedper = @cedper AND codrec = @codrec AND tiptid = @tiptid ";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codmov", vcodmov);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
            cmd.Parameters.AddWithValue("@codrec", vcodrec);
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

        //public Boolean ExisteMOVINV(int vcodmov, int vcoddoc, int vcodpro, string vtiptid)
        //{
        //    dbSQLConn.ConecDb_Abrir();
        //    NpgsqlDataReader Dr = null;
        //    string Sql = "SELECT codmov FROM detmovinv WHERE codmov = @codmov AND coddoc = @coddoc AND codpro = @codpro AND tiptid = @tiptid";
        //    NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
        //    cmd.Parameters.AddWithValue("@codmov", vcodmov);
        //    cmd.Parameters.AddWithValue("@coddoc", vcoddoc);
        //    cmd.Parameters.AddWithValue("@codpro", vcodpro);
        //    cmd.Parameters.AddWithValue("@tiptid", vtiptid);
        //    Dr = cmd.ExecuteReader();
        //    if (Dr.HasRows)
        //    {
        //        Dr.Close();
        //        dbSQLConn.ConecDb_Close();
        //        return true;
        //    }
        //    else
        //    {
        //        Dr.Close();
        //        dbSQLConn.ConecDb_Close();
        //        return false;
        //    }
        //}

       

        public Boolean BuscarCompraOBS(int vcedper, DateTime vfecdoc)
        {
            int nDeuda = 0;
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT COUNT(codmov)::integer AS DEUDA FROM ventobsdoc WHERE cedper = @cedper AND fecdoc::DATE = @fecdoc AND tiptid = 'OBS' AND cxcdoc = 1 AND stadoc = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
            cmd.Parameters.AddWithValue("@fecdoc", vfecdoc);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                nDeuda = Dr.GetInt32(0);
                if(nDeuda == 0)
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
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return false;
            }
        }

        public Clases._VENOBSDOC Buscar(int vcodmov)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._VENOBSDOC usr = new Clases._VENOBSDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM ventobsdoc WHERE codmov = @codmov LIMIT 1";
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

        public Clases._VENOBSDOC Search_UltimoEntrega_OBS(int vcedper)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._VENOBSDOC usr = new Clases._VENOBSDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos1 + " FROM ventobsdoc WHERE cedper = @cedper AND tiptid = 'OBS' ORDER BY codmov DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
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
                MessageBox.Show("Al trabajado no se ultimas entrega.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
        }

        public Clases._VENOBSDOC Search_UltimoEntregaPre_OBS(int vcedper)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._VENOBSDOC usr = new Clases._VENOBSDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT VEO.codmov, VEO.cedper, VEO.fecdoc, VEO.netdoc, VEO.brudoc, VEO.mtidoc, VEO.codrec, VEO.tiptid, VEO.cxcdoc, VEO.estdoc, VEO.condoc, VEO.stadoc, VEO.comdoc " +
                "FROM ventobsdoc AS VEO INNER JOIN movinv AS MOV ON VEO.codmov = MOV.codmov " +
                "WHERE VEO.tiptid = 'OBS' AND MOV.tiptra = 'S006' AND VEO.cedper = @cedper AND stadoc = 1" +
                "ORDER BY VEO.codmov DESC";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
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
                MessageBox.Show("Al trabajado no se le ha entregado el beneficio de cumpleaños.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
        }

        public Clases._VENOBSDOC Search_UltimoEntregaVac_OBS(int vcedper)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._VENOBSDOC usr = new Clases._VENOBSDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT VEO.codmov, VEO.cedper, VEO.fecdoc, VEO.netdoc, VEO.brudoc, VEO.mtidoc, VEO.codrec, VEO.tiptid, VEO.cxcdoc, VEO.estdoc, VEO.condoc, VEO.stadoc, VEO.comdoc " +
                "FROM ventobsdoc AS VEO INNER JOIN movinv AS MOV ON VEO.codmov = MOV.codmov " +
                "WHERE VEO.tiptid = 'OBS' AND MOV.tiptra = 'S007' AND VEO.cedper = @cedper AND stadoc = 1 " +
                "ORDER BY VEO.codmov DESC";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
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
                MessageBox.Show("Al trabajado no se le ha entregado el beneficio de Vacaciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
        }
    }
}
