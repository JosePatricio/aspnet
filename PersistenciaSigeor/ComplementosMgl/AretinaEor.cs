using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PersistenciaSigeor;

namespace PersistenciaSigeor
{
    [Serializable]
    public partial class AretinaEor
    {
        [DataMember]
        public SC_EORESTRUCTURA CabeceraEstructura { set; get; }

        [DataMember]
        public SC_EORMAQUINARIA CabeceraMaquinaria { set; get; }

        [DataMember]
        public SC_EORTRANSITO CabeceraTransito { set; get; }

        [DataMember]
        public List<SD_EORESTRUCTURA> DetalleEstructura { set; get; }

        [DataMember]
        public List<SD_EORMAQUINARIA> DetalleMaquinaria { set; get; }

        [DataMember]
        public List<SD_EORTRANSITO> DetalleTransito { set; get; }
    }
}
