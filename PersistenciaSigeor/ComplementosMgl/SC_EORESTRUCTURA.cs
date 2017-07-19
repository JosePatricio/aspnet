using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistenciaSigeor
{
    public partial class SC_EORESTRUCTURA
    {
        public List<SD_EORESTRUCTURA> DetalleEorEstructura { set; get; }
        public SM_DEPOSITO CampoDeposito { set; get; }
        public S_ESTIMATE_PARTY_RESPON CampoResponsable { set; get; }
        public SC_EIR CampoEir { set; get; }
    }
}
