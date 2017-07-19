using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PersistenciaSigeor
{
    public partial class AlertaReparacion
    {
        [DataMember]
        public String CampoCedulaUsuario { set; get; }
        [DataMember]
        public String CampoIpUsuario { set; get; }
        [DataMember]
        public String CampoTipoAlerta { set; get; }

    }
}
