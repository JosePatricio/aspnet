﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PersistenciaSigeor.ComplementosAdm
{
    public partial class Alerta
    {
        [DataMember]
        public String CampoCedulaUsuario { set; get; }
        [DataMember]
        public String CampoIpUsuario { set; get; }
    }
}
