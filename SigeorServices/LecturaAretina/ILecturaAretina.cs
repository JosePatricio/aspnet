using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SigeorServices.LecturaAretina
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ILecturaAretina" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ILecturaAretina
    {
        #region INICIO SERVICIO ATENTICACION

        [OperationContract]
        string ObtenerEorEstructuraPorNumero(string parametro);

        [OperationContract]
        string ObtenerEorMaquinariaPorNumero(string parametro);

        [OperationContract]
        string ObtenerEorTransitoPorNumero(string parametro);

        #endregion INICIO SERVICIO ATENTICACION

        #region Inicio de Lectura de Productos por EOR [Inv_H_CEgrProducto] y [Inv_H_DEgrProducto]

        [OperationContract]
        string ObtenerEgresosProductosPorNumEorCodDeposito(string parametro);

        #endregion Inicio de Lectura de Productos por EOR [Inv_H_CEgrProducto] y [Inv_H_DEgrProducto]


        #region Inicio de Lecturas de Eor Por Depósito

        [OperationContract]
        string ObtenerEorEstructuraPorDeposito(string parametro);

        [OperationContract]
        string ObtenerEorMaquinariaPorDeposito(string parametro);

        #endregion Inicio de Lecturas de Eor Por Depósito
    }
}
