using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISPROIN.DTSet;
using SISPROIN.Clases;
using SISPROIN.Reportes;

namespace SISPROIN.Formularios
{
    public partial class FormVISORRPT : Form
    {
        ConectarDB Cnn = new ConectarDB();
        public FormVISORRPT()
        {
            InitializeComponent();
        }

        public void Reporte_MOVINVPRO(string vdesde, string vhasta)
        {
            Text = "Listado de Movimiento de Inventario por Productos";
            Cnn.ConecDb_Abrir();
            DTSDATOS DS = new DTSDATOS();
            CRp_MOVINVPRO rpt = new CRp_MOVINVPRO();
            string strSQL = $"SELECT movinv.codpro, productos.despro, movinv.codmov,  to_char(movinv.fecmov,'DD/MM/YYYY') AS fecmov, movinv.tiptra, movinv.canmov " +
                $"FROM productos INNER JOIN movinv ON productos.codpro = movinv.codpro "+
                $"WHERE movinv.stamov = 1 AND(DATE(movinv.fecmov) BETWEEN '{vdesde}' AND '{vhasta}') "+
                $"GROUP BY movinv.codmov, movinv.codpro,  movinv.fecmov, movinv.tiptra, productos.despro, movinv.canmov "+
                $"ORDER BY movinv.codpro ASC, movinv.fecmov ASC, movinv.codmov ASC";
            if (Cnn.GetDataSet(ref DS, strSQL, "movinv"))
            {
                rpt.SetDataSource(DS);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            Cnn.ConecDb_Close();
        }

        public void Reporte_MOVINVPROCED(string vdesde, string vhasta)
        {
            Text = "Listado de Movimiento de Inventario por Productos y Cedulas";
            Cnn.ConecDb_Abrir();
            DTSDATOS DS = new DTSDATOS();
            CRp_MOVINVPROCED rpt = new CRp_MOVINVPROCED();
            string strSQL = $"SELECT movinv.codpro, productos.despro, movinv.cedper,  to_char(movinv.fecmov,'DD/MM/YYYY') AS fecmov, movinv.tiptra, movinv.canmov " +
                $"FROM productos INNER JOIN movinv ON productos.codpro = movinv.codpro " +
                $"WHERE movinv.stamov = 1 AND (DATE(movinv.fecmov) BETWEEN '{vdesde}' AND '{vhasta}') " +
                $"GROUP BY movinv.codmov, movinv.cedper, movinv.codpro,  movinv.fecmov, movinv.tiptra, productos.despro, movinv.canmov " +
                $"ORDER BY movinv.codpro ASC, movinv.fecmov ASC, movinv.codmov ASC";
            if (Cnn.GetDataSet(ref DS, strSQL, "movinvced"))
            {
                rpt.SetDataSource(DS);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            Cnn.ConecDb_Close();
        }


        public void Reporte_RESMOVINV(string vdesde, string vhasta)
        {
            DateTime dd = Convert.ToDateTime(vdesde);
            DateTime dh = Convert.ToDateTime(vhasta);
            Text = "Listado de Movimiento de Inventario por Productos y Cedulas";
            Cnn.ConecDb_Abrir();
            DTSDATOS DS = new DTSDATOS();
            CRp_RESMOVINV rpt = new CRp_RESMOVINV();
            string strSQL = $"SELECT T1.despro, T2.tiptra, T3.destra, count(T3.tiptra) AS cantmov, SUM(T2.canmov) AS sumov FROM productos T1 " + 
                $"INNER JOIN(SELECT codpro, tiptra, canmov, fecmov FROM movinv WHERE stamov = 1 GROUP BY codpro, canmov, tiptra, fecmov) AS T2 ON T1.codpro = T2.codpro " +
                $"INNER JOIN tiptransa T3 ON T3.tiptra = T2.tiptra " +
                $"WHERE (DATE(T2.fecmov) BETWEEN '{vdesde}' AND '{vhasta}') " +
                $"GROUP BY T2.codpro, T2.tiptra, T3.destra, T1.despro  " +
                $"ORDER BY T2.codpro ASC";
            if (Cnn.GetDataSet(ref DS, strSQL, "resmovinv"))
            {
                rpt.SetDataSource(DS);
                rpt.SetParameterValue("Rdesde", string.Format("{0:d}", dd));
                rpt.SetParameterValue("Rhasta", string.Format("{0:dd/MM/yyyy}", dh));
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            Cnn.ConecDb_Close();
        }
    }
}
