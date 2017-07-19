using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PersistenciaSigeor
{
    public partial class S_OCRD
    {
        [DataMember]
        public string CampoCedulaUsuario { set; get; }
        [DataMember]
        public string CampoIpUsuario { set; get; }

        [DataMember]
        public string CampoInspector { set; get; }
    }
}
