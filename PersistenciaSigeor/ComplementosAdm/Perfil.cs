using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenciaSigeor;
using System.Runtime.Serialization;
using System.Data.Objects.DataClasses;

namespace PersistenciaSigeor
{
    public partial class Perfil
    {

        [DataMember]
        public String CampoCedulaUsuario { set; get; }
        [DataMember]
        public String CampoIpUsuario { set; get; }
    }

}
