using Negocio.Aretina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SigeorServices.LecturaAretina
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "LecturaAretina" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione LecturaAretina.svc o LecturaAretina.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class LecturaAretina : ILecturaAretina
    {
        #region INICIO SERVICIOS AUTENTICACION

        public string ObtenerEorEstructuraPorNumero(string parametro)
        {
            return LecturaEorNegocio.ObtenerEorEstructuraPorNumEor(parametro);
        }


        public string ObtenerEorMaquinariaPorNumero(string parametro)
        {
            return LecturaEorNegocio.ObtenerEorMaquinariaPorNumEor(parametro);
        }


        public string ObtenerEorTransitoPorNumero(string parametro)
        {
            return LecturaEorNegocio.ObtenerEorTransitoPorNumEor(parametro);
        }


        #endregion FIN  SERVICIOS AUTENTICACION

        #region Inicio de Lectura de Productos por EOR [Inv_H_CEgrProducto] y [Inv_H_DEgrProducto]
        public string ObtenerEgresosProductosPorNumEorCodDeposito(string parametro)
        {
            return LecturaEorNegocio.ObtenerEgresosProductosPorNumEorCodDeposito(parametro);
        }
        #endregion Inicio de Lectura de Productos por EOR [Inv_H_CEgrProducto] y [Inv_H_DEgrProducto]


        #region Inicio de Lecturas de Eor Por Depósito

        public string ObtenerEorEstructuraPorDeposito(string parametro)
        {
            return LecturaEorNegocio.ObtenerEorEstructuraPorDeposito(parametro);
        }

        public string ObtenerEorMaquinariaPorDeposito(string parametro)
        {
            return LecturaEorNegocio.ObtenerEorMaquinariaPorNumEor(parametro);
        }

        #endregion Inicio de Lecturas de Eor Por Depósito

    }
}
