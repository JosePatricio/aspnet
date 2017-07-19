using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PersistenciaSigeor
{

    public partial class SInv_M_Producto
    {
        [DataMember]
        public string ClaveString { set; get; }
        [DataMember]
        public string CodigoLinea { set; get; }
        [DataMember]
        public string CodigoTipoDanio { set; get; }
        [DataMember]
        public string CodigoDanio { set; get; }

        [DataMember]
        public string NombreLinea { set; get; }
        [DataMember]
        public string NombreTipoDanio { set; get; }
        [DataMember]
        public string NombreDanio { set; get; }
        [DataMember]
        public string NombreTipoComponente { set; get; }

        [DataMember]
        public string NombreCategoria1 { set; get; }
        [DataMember]
        public string NombreCategoria2 { set; get; }
        [DataMember]
        public string NombreCategoria3 { set; get; }
    }
}
