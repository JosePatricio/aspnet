using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;//
using System.Data.SqlClient;//
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Negocio.Reportes;
using PersistenciaSigeor;
using System.Data.EntityClient;
using System.Globalization;
using System.Data.Objects.SqlClient;
using Negocio.Utilidades;
using Sigeor.ReportesServiceReference;
using Sigeor.Utilidades;
namespace Sigeor.ReportesAspx
{
    public partial class ChartWebForm : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                GestionUtil.RedireccionarSesionExpirada();
                return;
            }

            if (!Page.IsPostBack)
            {
                GestionUtil.ControlAccesoPerfil(GestionUtil.ObtenerUsuarioSesion.Cedula, this.Request.Url.LocalPath);
              


            }

        }

       
      
        Negocio.Aretina.ReportesGraficos reporte = new Negocio.Aretina.ReportesGraficos();
        ReportesServiceClient servicio = new ReportesServiceClient();


        public void EstiloChart(Chart chart) {
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
          //  chart.Series[0].BorderColor = ColorTranslator.FromHtml("#17578C");
           // chart.Series[0].Color = ColorTranslator.FromHtml("#3477AF");
        
            chart.Series[0].Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            chart.Series[0].BorderWidth = 2;
            chart.BackColor = ColorTranslator.FromHtml("#6E6E6E");
            String[] colores = { "4BC6FF", "11517D" };

            int k = 0;
            foreach (var item in chart.Series[0].Points)
            {if(k>=colores.Length){
               k = 0;
            }

            item.Color = ColorTranslator.FromHtml("#" + colores[k]);
            k++;
            }



            foreach (Series b in chart.Series)
            {
                b.Label = "#VALY{$#,##0.00}";
                b.LegendText = "#VALX";
                foreach (DataPoint cf in b.Points)
                {
                    cf.AxisLabel = meses(cf.XValue.ToString());
                }
            }
        }

        protected void Chart1_Load(object sender, EventArgs e)
        { 
            List<Negocio.Aretina.ReportesGraficos.modelo> lista=null;
            String xml = "";

            xml = servicio.obtenerTotalesEorEstructuraTodosEstimado();
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.modelo>>(xml) : null;
            
                string Year = "";
                string Month = "";
                if (Request["Year"] != null) Year = Request["Year"].ToString();
                if (Request["Month"] != null) Month = Request["Month"].ToString();
                if ((Year == "") && (Month == ""))
                {
                 lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.modelo>>(xml) : null;
        
                }

                else if (Month == "")
                {
                    xml = servicio.obtenerTotalesEorEstructuraPorAnioEstimado(Year);
                    lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.modelo>>(xml) : null;
 
                }


                Chart1.DataSource = lista;
                Series Series1 = new Series();
                Series1.XValueMember = "Year";
                Series1.YValueMembers = "Total";

                Chart1.Series.Add(Series1);
              
                Chart1.DataBind();

           
                foreach (DataPoint p in Chart1.Series[0].Points)
                {
                  
                    if ((Year != ""))
                    {
                        p.Url = string.Format("ChartWebForm.aspx");
                    }
                    else
                    {
                        p.Url = string.Format("ChartWebForm.aspx?Year={0}", p.XValue);
                    }
             
                }


                EstiloChart(Chart1);

             
        
        }



        protected void Chart2_Load(object sender, EventArgs e)
        {

            List<Negocio.Aretina.ReportesGraficos.modelo> lista = null;
            String xml = "";
            xml = servicio.obtenerTotalesEorEstructuraTodosReal();
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.modelo>>(xml) : null;
           

            string Year = "";
            string Month = "";
            if (Request["Year"] != null) Year = Request["Year"].ToString();
            if (Request["Month"] != null) Month = Request["Month"].ToString();
            if ((Year == "") )
            {
                lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.modelo>>(xml) : null;
           

            }

            else if (Month == "")
            {
          
                xml = servicio.obtenerTotalesEorEstructuraRealPorAnio(Year);
                lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.modelo>>(xml) : null;
 
            }


            Chart2.DataSource = lista;
            Series Series1 = new Series();
            Series1.XValueMember = "Year";
            Series1.YValueMembers = "Total";

            Chart2.Series.Add(Series1);
   
            Chart2.DataBind();

            foreach (DataPoint p in Chart2.Series[0].Points)
            {

                if ((Year != ""))
                {
                    p.Url = string.Format("ChartWebForm.aspx");
                }
                else
                {
                    p.Url = string.Format("ChartWebForm.aspx?Year={0}", p.XValue);
                }
              
            }

            EstiloChart(Chart2);

          
        }



        public string meses(string n)
        {
            int[] m = new int[12];
            if (Int32.Parse(n) <= m.Length)
            {
                for (int i = 1; i <= m.Length; i++)
                {
                    if (i == Int32.Parse(n))
                    {
                        return new CultureInfo("en-US").TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
                    }
                }
            }
            return "";
        }


        public void paginaToPdf() {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();
            this.Parent.Controls.Add(frm);
            
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(this);
            frm.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
               
    
            if (DropDownList1.SelectedValue.ToString()=="1")
            {
                exportarPDF(Chart1);
            }
            if (DropDownList1.SelectedValue.ToString() == "2")
            {
                 exportarPDF(Chart2);

                }}
            



        public void exportarPDF(Chart chart) {
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            using (MemoryStream stream = new MemoryStream())
            {
                chart.SaveImage(stream, ChartImageFormat.Png);
                iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                chartImage.ScalePercent(40f);

                pdfDoc.Add(chartImage);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Chart.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        
        }


            }
        

}