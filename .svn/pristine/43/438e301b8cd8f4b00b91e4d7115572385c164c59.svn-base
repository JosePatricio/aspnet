using System;
using System.Collections.Generic;
using System.Web.Services;
using Negocio.Utilidades;
using Sigeor.GestionReportesServiceReference;

namespace Sigeor.ServiciosAsmx
{
    /// <summary>
    /// Descripción breve de HighchartService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class HighchartService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorEstructuraTodosEstimado()
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorEstructuraTodosEstimado();
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorEstructuraPorAnioEstimado(string Year)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorEstructuraPorAnioEstimado(Year);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorEstructuraTodosReal()
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorEstructuraTodosReal();
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorEstructuraRealPorAnio(string Year)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorEstructuraRealPorAnio(Year);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }


       


        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorMaquinariaTodosEstimado()
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorMaquinariaTodosEstimado();
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorMaquinariaPorAnioEstimado(string Year)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorMaquinariaPorAnioEstimado(Year);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorMaquinariaTodosReal()
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorMaquinariaTodosReal();
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorMaquinariaRealPorAnio(string Year)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorMaquinariaRealPorAnio(Year);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }




        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorTransitoTodosEstimado()
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorTransitoTodosEstimado();
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorTransitoPorAnioEstimado(string Year)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorTransitoPorAnioEstimado(Year);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorTransitoTodosReal()
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorTransitoTodosReal();
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorTransitoRealPorAnio(string Year)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorTransitoRealPorAnio(Year);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }        

        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorEstructuraTodosEstimadoPorLinea(string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorEstructuraTodosEstimadoPorLinea(linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorEstructuraPorAnioEstimadoPorLinea(string Year, string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorEstructuraPorAnioEstimadoPorLinea(Year, linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorEstructuraTodosRealPorLinea(string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorEstructuraTodosRealPorLinea(linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorEstructuraRealPorAnioPorLinea(string Year, string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorEstructuraRealPorAnioPorLinea(Year, linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }





        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorMaquinariaTodosEstimadoPorLinea(string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorMaquinariaTodosEstimadoPorLinea(linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorMaquinariaPorAnioEstimadoPorLinea(string Year, string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorMaquinariaPorAnioEstimadoPorLinea(Year, linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorMaquinariaTodosRealPorLinea(string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorMaquinariaTodosRealPorLinea(linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorMaquinariaRealPorAnioPorLinea(string Year, string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorMaquinariaRealPorAnioPorLinea(Year, linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }




        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorTransitoTodosEstimadoPorLinea(string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorTransitoTodosEstimadoPorLinea(linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorTransitoPorAnioEstimadoPorLinea(string Year, string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorTransitoPorAnioEstimadoPorLinea(Year, linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorTransitoTodosRealPorLinea(string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorTransitoTodosRealPorLinea(linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }
        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerTotalesEorTransitoRealPorAnioPorLinea(string Year, string linea)
        {
            ReportesServiceClient servicio = new ReportesServiceClient();
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = servicio.obtenerTotalesEorTransitoRealPorAnioPorLinea(Year, linea);
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }









        [WebMethod]
        public List<Negocio.Aretina.ReportesGraficos.Modelo> obtenerLineasPorEstado()
        {   
            List<Negocio.Aretina.ReportesGraficos.Modelo> lista = null;
            String xml = Negocio.Aretina.ReportesGraficos.obtenerLineasPorEstado("A");
            lista = xml != null ? Serializador.DeSerializeEntity<List<Negocio.Aretina.ReportesGraficos.Modelo>>(xml) : null;
            return lista;
        }





    }
}
