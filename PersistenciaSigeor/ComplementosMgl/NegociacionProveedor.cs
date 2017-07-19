using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PersistenciaSigeor
{
    public partial class NegociacionProveedor
    {
        [DataMember]
        public String CampoCedulaUsuario { set; get; }

        [DataMember]
        public String CampoIpUsuario { set; get; }

        [DataMember]
        public String CampoNombreProveedor { set; get; }

        [DataMember]
        public String CampoNombreDeposito { set; get; }
    }
}
