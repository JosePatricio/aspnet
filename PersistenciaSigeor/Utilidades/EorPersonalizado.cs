using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PersistenciaSigeor
{
    public class EorPersonalizado
    {
        [DataMember]
        public string NumeroEor { get; set; }

        [DataMember]
        public string TipoEor { get; set; }

        [DataMember]
        public string TipoContainer { get; set; }

        [DataMember]
        public string Ciudad { get; set; }

        [DataMember]
        public string Linea { get; set; }

        [DataMember]
        public DateTime? FechaAprobacion { get; set; }

        [DataMember]
        public DateTime? FechaReparacion { get; set; }

        [DataMember]
        public string Aprobado { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public decimal? ValorEstimadoHH { get; set; }

        [DataMember]
        public decimal? ValorRealHH { get; set; }

        [DataMember]
        public decimal? ValorEstimadoMaterial { get; set; }

        [DataMember]
        public decimal? ValorRealMaterial { get; set; }


    }
}
