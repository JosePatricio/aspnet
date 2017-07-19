using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Reportes;
using Negocio.Utilidades;
using PersistenciaSigeor;
using Sigeor.Utilidades;
using Sigeor.GestionMglServiceReference;
using Sigeor.GestionReportesServiceReference;
using System.Globalization;

namespace Sigeor.GestionMgl
{


    public partial class EorCabeceraEstructuraWebForm : System.Web.UI.Page
    {
        private GestionMglServiceClient _clienteSigeor;
        private ReportesServiceClient _clienteReportes;
        private GestionMglServiceClient _clienteMgl;
        private List<ClaseBasica> _listaRegistrosVisibles;
        private int _totalRegistros;
        private int PageSizeActual
        {
            get
            {
                var result = RegistrosVisiblesDropDownList.SelectedValue;
                if (!string.IsNullOrEmpty(result))
                    return int.Parse(result);
                return 0;
            }
        }

        private int PageIndexActual
        {
            set
            {
                if (value > 0 && value <= int.Parse(totalPaginasLbl.Text))
                    paginaActualTextBox.Text = value.ToString();
            }
            get
            {
                if (string.IsNullOrEmpty(paginaActualTextBox.Text))
                    paginaActualTextBox.Text = "1";
                var pagina = int.Parse(GestionUtil.VerificarPaginaActual(paginaActualTextBox.Text));
                if (pagina > 0 && pagina <= int.Parse(totalPaginasLbl.Text))
                    return pagina;
                return 1;
            }
        }

        private string RecuperarFiltros()
        {
            string result = null;
            try
            {
                string fechaInicio = txtFechaInicio.Text = Request.Form[txtFechaInicio.UniqueID];
                string fechaFin = txtFechaFin.Text = Request.Form[txtFechaFin.UniqueID];
                ClaseBasica filtros;


                if (!string.IsNullOrEmpty(BuscarTextBox.Text.Trim().ToUpper()))
                    filtros = new ClaseBasica { DescripcionUno = BuscarTextBox.Text.Trim().ToUpper() };
                else
                    filtros = new ClaseBasica
                    {
                        Descripcion = string.Empty, //NUMERO DE EIR
                        //DescripcionUno = BuscarTextBox.Text.Trim().ToUpper(),
                        DescripcionDos = ddlLinea.SelectedValue,
                        DescripcionTres = ddlDeposito.SelectedValue,
                        //DescripcionCuatro = ddlLÍNEA.SelectedValue,
                        DescripcionCinco = string.Empty, //TIPO COMPONENTE
                        FechaDateTimeStringUno = !string.IsNullOrEmpty(fechaInicio) ? DateTime.Parse(fechaInicio).ToString(CultureInfo.InvariantCulture) : string.Empty,
                        FechaDateTimeStringDos = !string.IsNullOrEmpty(fechaFin) ? DateTime.Parse(fechaFin).ToString(CultureInfo.InvariantCulture) : string.Empty,
                        IdStringUno = ddlEstado.SelectedValue,
                        IdStringDos = string.Empty
                    };

                var listaContenedores = TipoContenedorListBox.Items.Cast<ListItem>().ToList().Where(ent => ent.Selected);

                if (listaContenedores.Any())
                {
                    foreach (ListItem item in listaContenedores)
                    {
                        filtros.DescripcionCinco += "'" + item.Value + "',";
                    }
                    filtros.DescripcionCinco = filtros.DescripcionCinco.Substring(0, filtros.DescripcionCinco.Length - 1);
                }


                result = Serializador.SerializeEntity(filtros);
            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo recuperar los filtros seleccionados" + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo recuperar los filtros seleccionados");
            }

            return result;
        }

        public EorCabeceraEstructuraWebForm()
        {
            try
            {
                _clienteSigeor = new GestionMglServiceClient();
                _clienteReportes = new ReportesServiceClient();
                _clienteMgl = new GestionMglServiceClient();

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_CARGA_VARIABLES + " " + ex.Message);
            }
        }

        protected void formularioPrincipal_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.AplicarFocoBusqueda(this, BuscarTextBox);
            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_PRERENDER);

            }
        }

        private void CargarFiltros()
        {
            try
            {
                paginaActualTextBox.Text = "1";
                totalPaginasLbl.Text = "1";

                _listaRegistrosVisibles = GestionUtil.CargarNumeroRegistrosGridView();
                RegistrosVisiblesDropDownList.DataSource = _listaRegistrosVisibles;
                RegistrosVisiblesDropDownList.DataValueField = "IdInt";
                RegistrosVisiblesDropDownList.DataTextField = "Descripcion";
                RegistrosVisiblesDropDownList.DataBind();
                RegistrosVisiblesDropDownList.SelectedValue = "20";



                var result = _clienteSigeor.ObtenerDepositosPorEstado("A");

                var listaDepositos = !string.IsNullOrEmpty(result)
                    ? Serializador.DeSerializeEntity<List<SM_DEPOSITO>>(result)
                    : new List<SM_DEPOSITO>();

                listaDepositos.Insert(0, new SM_DEPOSITO { COD_DEPOSITO = string.Empty, NOMBRE_DEPOSITO = "TODOS LOS DEPÓSITOS" });
                //listaDepositos.Insert(0,new SM_DEPOSITO{COD_DEPOSITO = null, NOMBRE_DEPOSITO = "Elija un Deposito..."});
                ddlDeposito.DataSource = listaDepositos;
                ddlDeposito.DataValueField = "COD_DEPOSITO";
                ddlDeposito.DataTextField = "NOMBRE_DEPOSITO";
                ddlDeposito.DataBind();

                result = _clienteSigeor.ObtenerLineasPorEstado("A");

                var listaLineas = !string.IsNullOrEmpty(result)
                    ? Serializador.DeSerializeEntity<List<SM_LINEA>>(result)
                    : new List<SM_LINEA>();

                listaLineas.Insert(0, new SM_LINEA { COD_LINEA = string.Empty, NOM_LINEA = "TODAS LAS LÍNEAS" });
                //listaLineas.Insert(0, new SM_LINEA { COD_LINEA = null, NOM_LINEA = "Elija una Línea..." });
                ddlLinea.DataSource = listaLineas;
                ddlLinea.DataValueField = "COD_LINEA";
                ddlLinea.DataTextField = "NOM_LINEA";
                ddlLinea.DataBind();

                //result = _clienteSigeor.ObtenerLÍNEAsPorEstado("A");

                //var listaLÍNEAs = !string.IsNullOrEmpty(result)
                //    ? Serializador.DeSerializeEntity<List<M_LÍNEA>>(result)
                //    : new List<M_LÍNEA>();

                //listaLÍNEAs.Insert(0, new M_LÍNEA { COD_LÍNEA = string.Empty, NOMBRE_LÍNEA = "Todas las LÍNEAs" });
                //ddlLÍNEA.DataSource = listaLÍNEAs;
                //ddlLÍNEA.DataValueField = "COD_LÍNEA";
                //ddlLÍNEA.DataTextField = "NOMBRE_LÍNEA";
                //ddlLÍNEA.DataBind();

                var parametro = new ClaseBasica { EstadoString = "A", Descripcion = string.Empty };
                result = _clienteMgl.ObtenerTipoContenedorPorTipoEstado(Serializador.SerializeEntity(parametro));


                var listaTipoContenedores = !string.IsNullOrEmpty(result)
                   ? Serializador.DeSerializeEntity<List<SM_TIPCONTAINER>>(result)
                   : new List<SM_TIPCONTAINER>();


                TipoContenedorListBox.DataSource = listaTipoContenedores;
                TipoContenedorListBox.DataTextField = "NOM_TIPCONT";
                TipoContenedorListBox.DataValueField = "COD_TIPCONT";
                TipoContenedorListBox.DataBind();


                result = _clienteReportes.ObtenerEstadosEorEstructuraMaquinaria();

                var listaEstados = !string.IsNullOrEmpty(result)
                    ? Serializador.DeSerializeEntity<List<ClaseBasica>>(result)
                    : new List<ClaseBasica>();

                listaEstados.Insert(0, new ClaseBasica { IdString = string.Empty, Nombre = "TODOS LOS ESTADOS" });
                ddlEstado.DataSource = listaEstados;
                ddlEstado.DataValueField = "IdString";
                ddlEstado.DataTextField = "Nombre";
                ddlEstado.DataBind();

            }
            catch (Exception ex)
            {
                Log.WriteEntry("No se pudo cargar los filtros del reporte EOR por estructura: " + ex, EventLogEntryType.Error);
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar los filtros del reporte EOR por estructura");
            }
        }

        protected void formularioPrincipal_OnLoad(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    GestionUtil.RedireccionarSesionExpirada();
                    return;
                }

                if (!Page.IsPostBack)
                {
                    GestionUtil.ControlAccesoPerfil(GestionUtil.UsuarioSesion.Cedula, this.Request.Url.LocalPath);
                    lblCabecera.Text = GestionUtil.tituloPagina(this.Request.Url.LocalPath); ;

                    calendarExtenderInicio.EndDate = DateTime.Now;
                    calendarExtenderFin.EndDate = DateTime.Now;

                    txtFechaInicio.Text = DateTime.Now.AddDays(-30).ToShortDateString();
                    txtFechaFin.Text = DateTime.Now.ToShortDateString();

                    CargarFiltros();


                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, "Eor's por Estructura", ConstantesUtil.MENSAJE_ERROR_LOAD);
            }
        }

        protected void VerReporte(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.VerReporte(this, "EorCabeceraEstructuraReport", RecuperarFiltros());
            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, "No se pudo cargar los reportes: " + ex.Message);
            }
        }

        protected void OnClickNavegacion(object sender, EventArgs e)
        {
            try
            {
                GestionUtil.Redireccionar(ConstantesUtil.URL_MENU_REPORTES);

            }
            catch (Exception ex)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGACION_MENU + " " + ex.Message);
            }
        }

        protected void BuscarButton_OnClick(object sender, EventArgs e)
        {
            try
            {

                CargarDatosPorEstadoCoincidencia();

            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty,
                    ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
            }
        }

        protected void RegistrosVisiblesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                paginaActualTextBox.Text = "1";
                EorCabeceraEstructuraGridView.PageSize = PageSizeActual;
                CargarDatosPorEstadoCoincidencia();
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_PAGE_SIZE);
            }
        }

        protected void EorCabeceraEstructuraGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var headerGroups = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[0].ToString();
                    var footerGroups = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[e.Row.Cells.Count - 4].ToString();

                    if (headerGroups.Contains("DEPÓSITO:") || headerGroups.Contains("LÍNEA:"))
                    {
                        e.Row.BackColor = headerGroups.Contains("DEPÓSITO:") ? ColorTranslator.FromHtml("#2f5270") : ColorTranslator.FromHtml("#4680af");
                        e.Row.ForeColor = Color.White;
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].ColumnSpan = e.Row.Cells.Count;

                        for (int i = 1; i < e.Row.Cells.Count; i++)
                            e.Row.Cells[i].Visible = false;
                    }
                    else
                    {
                        if (footerGroups.Contains("TOTAL LÍNEA:") || footerGroups.Contains("TOTAL DEPÓSITO:") || footerGroups.Contains("GRAN TOTAL"))
                        {
                            e.Row.BackColor = footerGroups.Contains("TOTAL DEPÓSITO") ? ColorTranslator.FromHtml("#2f5270") :
                                              footerGroups.Contains("TOTAL LÍNEA:") ? ColorTranslator.FromHtml("#a4a8aa") : Color.White;

                            e.Row.ForeColor = footerGroups.Contains("GRAN TOTAL") ? Color.Black : Color.White;
                            e.Row.Font.Bold = true;
                            e.Row.HorizontalAlign = HorizontalAlign.Right;
                            e.Row.Cells[e.Row.Cells.Count - 5].ColumnSpan = e.Row.Cells.Count - 4;
                            e.Row.Cells[e.Row.Cells.Count - 5].HorizontalAlign = HorizontalAlign.Right;

                            for (int i = 0; i < e.Row.Cells.Count - 5; i++)
                                e.Row.Cells[i].Visible = false;
                        }
                        else
                        {
                            e.Row.Cells[e.Row.Cells.Count - 3].HorizontalAlign =
                               e.Row.Cells[e.Row.Cells.Count - 4].HorizontalAlign =
                                   e.Row.Cells[e.Row.Cells.Count - 5].HorizontalAlign =
                                       e.Row.Cells[e.Row.Cells.Count - 6].HorizontalAlign = HorizontalAlign.Center;

                            var valorCelda = ((DataRowView)(e.Row.DataItem)).Row.ItemArray[e.Row.Cells.Count].ToString();
                            valorCelda = valorCelda.Replace("$", string.Empty);

                            var styleOverEvent = "originalstyle=style.backgroundColor;style.backgroundColor='{0}';style.cursor='pointer';";

                            var valorRealCostoHH = decimal.Parse(((DataRowView)(e.Row.DataItem)).Row.ItemArray[e.Row.Cells.Count].ToString().Replace("$", string.Empty));
                            var valorEstiCostoHH = decimal.Parse(((DataRowView)(e.Row.DataItem)).Row.ItemArray[e.Row.Cells.Count - 1].ToString().Replace("$", string.Empty));
                            var valorRealMaterial = decimal.Parse(((DataRowView)(e.Row.DataItem)).Row.ItemArray[e.Row.Cells.Count - 2].ToString().Replace("$", string.Empty));
                            var valorEstiMaterial = decimal.Parse(((DataRowView)(e.Row.DataItem)).Row.ItemArray[e.Row.Cells.Count - 3].ToString().Replace("$", string.Empty));


                            if ((valorEstiCostoHH < valorRealCostoHH) || (valorEstiMaterial < valorRealMaterial))
                            {
                                e.Row.BackColor = ColorTranslator.FromHtml("#FFCCCC");
                                styleOverEvent = string.Format(styleOverEvent, "#FFB3B3");
                            }
                            else {
                                styleOverEvent = string.Format(styleOverEvent, "#d0dfea");
                            }
                            e.Row.Attributes.Add("onMouseOver", styleOverEvent);
                            e.Row.Attributes.Add("OnMouseOut", "style.backgroundColor=originalstyle;");
                        }

                    }
                }
            }
            catch
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_ROWDATA_BOUND);
            }
        }

        private void BindingDatosPaginadosPorLista(List<GET_CABECERA_EOR_ESTRUCTURA_Result> lista, int totalRegistros)
        {
            try
            {
                var totalPaginas =
               (Math.Round(new decimal(totalRegistros / PageSizeActual), 0, MidpointRounding.AwayFromZero));

                if ((totalRegistros > 0 && totalPaginas == 0) || (totalPaginas == 0 && _totalRegistros > 0))
                    totalPaginas = 1;

                if ((totalRegistros % PageSizeActual > 0) && (totalRegistros > PageSizeActual))
                    totalPaginas++;

                totalPaginasLbl.Text = totalPaginas.ToString();

                var dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("NUM_EOREST"));
                dataTable.Columns.Add(new DataColumn("ID_EIR"));
                dataTable.Columns.Add(new DataColumn("NUM_CONTAINER"));
                dataTable.Columns.Add(new DataColumn("COD_TIPCONT"));
                dataTable.Columns.Add(new DataColumn("ISO_CODE"));
                dataTable.Columns.Add(new DataColumn("NOM_LINEA"));
                dataTable.Columns.Add(new DataColumn("CIUDAD"));
                dataTable.Columns.Add(new DataColumn("FECHA_EOR"));
                dataTable.Columns.Add(new DataColumn("FECHA_APROBACION"));
                dataTable.Columns.Add(new DataColumn("FECHA_REPARACION"));
                dataTable.Columns.Add(new DataColumn("ESTADO"));
                dataTable.Columns.Add(new DataColumn("TOTAL_ESTIMAT"));
                dataTable.Columns.Add(new DataColumn("TOTAL_REALMAT"));
                dataTable.Columns.Add(new DataColumn("TOTAL_ESTICOSTOHH"));
                dataTable.Columns.Add(new DataColumn("TOTAL_REALCOSTOHH"));

                var depositos = lista.Select(ent => ent.NOMBRE_DEPOSITO).Distinct().ToList();
                var lineas = lista.Select(ent => ent.NOM_LINEA).Distinct().ToList();
                DataRow dataRow = null;


                decimal sumaTotalRealMat = 0;
                decimal sumaTotalEstiMat = 0;
                decimal sumaTotalRealCostoHH = 0;
                decimal sumaTotalEstiCostoHH = 0;


                foreach (var dep in depositos)
                {
                    decimal sumaDepositoRealMat = 0;
                    decimal sumaDepositoEstiMat = 0;
                    decimal sumaDepositoRealCostoHH = 0;
                    decimal sumaDepositoEstiCostoHH = 0;

                    dataRow = dataTable.NewRow();
                    dataRow["NUM_EOREST"] = "  DEPÓSITO: " + dep;
                    dataTable.Rows.Add(dataRow);

                    foreach (var lin in lineas)
                    {
                        var listaFiltradaEor =
                            lista.Where(ent => ent.NOMBRE_DEPOSITO == dep && ent.NOM_LINEA == lin).ToList();

                        if (listaFiltradaEor.Any())
                        {
                            dataRow = dataTable.NewRow();
                            dataRow["NUM_EOREST"] = "   LÍNEA: " + lin;
                            dataTable.Rows.Add(dataRow);
                        }

                        decimal sumaLineaRealMat = 0;
                        decimal sumaLineaEstiMat = 0;
                        decimal sumaLineaRealCostoHH = 0;
                        decimal sumaLineaEstiCostoHH = 0;

                        foreach (var eor in listaFiltradaEor)
                        {
                            dataRow = dataTable.NewRow();
                            dataRow["NUM_EOREST"] = eor.NUM_EOREST;
                            dataRow["ID_EIR"] = eor.ID_EIR;
                            dataRow["COD_TIPCONT"] = eor.COD_TIPCONT;
                            dataRow["NUM_CONTAINER"] = eor.PREF_CONTAINER + eor.NUM_CONTAINER;
                            dataRow["ISO_CODE"] = eor.ISO_CODE;
                            dataRow["NOM_LINEA"] = eor.NOM_LINEA;
                            dataRow["CIUDAD"] = eor.CIUDAD;
                            dataRow["FECHA_EOR"] = eor.FECHA_EOR != null ? eor.FECHA_EOR.Value.ToString("dd/MM/yyyy") : string.Empty;
                            dataRow["FECHA_APROBACION"] = eor.FECHA_APROBACION != null ? eor.FECHA_APROBACION.Value.ToString("dd/MM/yyyy") : string.Empty;
                            dataRow["FECHA_REPARACION"] = eor.FECHA_FINREPARA != null ? eor.FECHA_FINREPARA.Value.ToString("dd/MM/yyyy") : string.Empty;
                            dataRow["ESTADO"] = eor.ESTADO;
                            dataRow["TOTAL_REALMAT"] = GestionUtil.ConvertirStringToDivisa(eor.TOTAL_REALMAT);
                            dataRow["TOTAL_ESTIMAT"] = GestionUtil.ConvertirStringToDivisa(eor.TOTAL_ESTIMAT);
                            dataRow["TOTAL_REALCOSTOHH"] = GestionUtil.ConvertirStringToDivisa(eor.TOTAL_REALCOSTOHH);
                            dataRow["TOTAL_ESTICOSTOHH"] = GestionUtil.ConvertirStringToDivisa(eor.TOTAL_ESTICOSTOHH);
                            dataTable.Rows.Add(dataRow);

                            sumaLineaRealMat += eor.TOTAL_REALMAT;
                            sumaLineaEstiMat += eor.TOTAL_ESTIMAT;
                            sumaLineaRealCostoHH += eor.TOTAL_REALCOSTOHH;
                            sumaLineaEstiCostoHH += eor.TOTAL_ESTICOSTOHH;
                        }
                        if (listaFiltradaEor.Any())
                        {
                            dataRow = dataTable.NewRow();
                            dataRow["ESTADO"] = " TOTAL LÍNEA: " + lin.ToUpper();
                            dataRow["TOTAL_REALMAT"] = GestionUtil.ConvertirStringToDivisa(sumaLineaRealMat);
                            dataRow["TOTAL_ESTIMAT"] = GestionUtil.ConvertirStringToDivisa(sumaLineaEstiMat);
                            dataRow["TOTAL_REALCOSTOHH"] = GestionUtil.ConvertirStringToDivisa(sumaLineaRealCostoHH);
                            dataRow["TOTAL_ESTICOSTOHH"] = GestionUtil.ConvertirStringToDivisa(sumaLineaEstiCostoHH);
                            dataTable.Rows.Add(dataRow);

                            sumaDepositoRealMat += sumaLineaRealMat;
                            sumaDepositoEstiMat += sumaLineaEstiMat;
                            sumaDepositoRealCostoHH += sumaLineaRealCostoHH;
                            sumaDepositoEstiCostoHH += sumaLineaEstiCostoHH;
                        }
                    }
                    dataRow = dataTable.NewRow();
                    dataRow["ESTADO"] = " TOTAL DEPÓSITO: " + dep.ToUpper();
                    dataRow["TOTAL_REALMAT"] = GestionUtil.ConvertirStringToDivisa(sumaDepositoRealMat);
                    dataRow["TOTAL_ESTIMAT"] = GestionUtil.ConvertirStringToDivisa(sumaDepositoEstiMat);
                    dataRow["TOTAL_REALCOSTOHH"] = GestionUtil.ConvertirStringToDivisa(sumaDepositoRealCostoHH);
                    dataRow["TOTAL_ESTICOSTOHH"] = GestionUtil.ConvertirStringToDivisa(sumaDepositoEstiCostoHH);
                    dataTable.Rows.Add(dataRow);

                    sumaTotalRealMat += sumaDepositoRealMat;
                    sumaTotalEstiMat += sumaDepositoEstiMat;
                    sumaTotalRealCostoHH += sumaDepositoRealCostoHH;
                    sumaTotalEstiCostoHH += sumaDepositoEstiCostoHH;
                }

                if (depositos.Any())
                {
                    dataRow = dataTable.NewRow();
                    dataRow["ESTADO"] = " GRAN TOTAL";
                    dataRow["TOTAL_REALMAT"] = GestionUtil.ConvertirStringToDivisa(sumaTotalRealMat);
                    dataRow["TOTAL_ESTIMAT"] = GestionUtil.ConvertirStringToDivisa(sumaTotalEstiMat);
                    dataRow["TOTAL_REALCOSTOHH"] = GestionUtil.ConvertirStringToDivisa(sumaTotalRealCostoHH);
                    dataRow["TOTAL_ESTICOSTOHH"] = GestionUtil.ConvertirStringToDivisa(sumaTotalEstiCostoHH);
                    dataTable.Rows.Add(dataRow);
                }

                EorCabeceraEstructuraGridView.DataSource = dataTable;
                EorCabeceraEstructuraGridView.DataBind();

            }
            catch (Exception)
            {
                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }

        }



        private void CargarDatosPaginadosPorNavegacion(object sender)
        {
            try
            {
                var control = sender as LinkButton;

                if (control != null)
                {

                    var totalPaginas = int.Parse(totalPaginasLbl.Text);


                    if (control.ID.Equals("Inicio"))
                        PageIndexActual = 1;

                    if (control.ID.Equals("Siguiente") && PageIndexActual < totalPaginas)
                        if (PageIndexActual < totalPaginas)
                            PageIndexActual++;
                        else
                            return;
                    if (control.ID.Equals("Anterior") && PageIndexActual > 0)
                        if (PageIndexActual > 0)
                            PageIndexActual--;
                        else
                            return;

                    if (control.ID.Equals("Final"))
                        PageIndexActual = totalPaginas;

                    var result = _clienteReportes.ObtenerEorCabeceraEstructuraPorFiltrosPaginado(out _totalRegistros, RecuperarFiltros(), PageSizeActual, PageIndexActual);


                    //var result =
                    //        ReporteEorEstructuraNegocio.ObtenerEorCabeceraPorFiltrosPaginado(
                    //            RecuperarFiltros(), PageSizeActual, PageIndexActual,
                    //            out _totalRegistros);

                    var lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_CABECERA_EOR_ESTRUCTURA_Result>>(result) : new List<GET_CABECERA_EOR_ESTRUCTURA_Result>();
                    BindingDatosPaginadosPorLista(lista, _totalRegistros);
                }
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_NAVEGAR_PAGINACION);
            }
        }

        protected void Paginador_OnClick(object sender, EventArgs e)
        {
            CargarDatosPaginadosPorNavegacion(sender);
        }

        private void CargarDatosPorEstadoCoincidencia()
        {
            try
            {
                var result = _clienteReportes.ObtenerEorCabeceraEstructuraPorFiltrosPaginado(out _totalRegistros, RecuperarFiltros(), PageSizeActual, PageIndexActual);

                var lista = !string.IsNullOrEmpty(result) ? Serializador.DeSerializeEntity<List<GET_CABECERA_EOR_ESTRUCTURA_Result>>(result) : new List<GET_CABECERA_EOR_ESTRUCTURA_Result>();

                BindingDatosPaginadosPorLista(lista, _totalRegistros);
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_CARGA_DATA);
            }
        }

        protected void paginaActualDdl_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosPorEstadoCoincidencia();
        }

        protected void RegistrosVisiblesDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosPorEstadoCoincidencia();
        }

        protected void paginaActualTextBox_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(paginaActualTextBox.Text))
                {
                    var index = int.Parse(GestionUtil.VerificarPaginaActual(paginaActualTextBox.Text));

                    if (index.Equals(0))
                        PageIndexActual = 1;
                    else
                    {
                        var total = int.Parse(totalPaginasLbl.Text);
                        if (index > total)
                            PageIndexActual = total;
                    }
                    CargarDatosPorEstadoCoincidencia();
                }
            }
            catch (Exception)
            {

                GestionUtil.MostrarNotificacion(this, ConstantesUtil.NOTIFICACION_ERROR, string.Empty, ConstantesUtil.MENSAJE_ERROR_BUSQUEDA_POR_COINCIDENCIAS);
            }
        }


    }
}
