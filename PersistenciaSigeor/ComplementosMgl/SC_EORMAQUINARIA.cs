using System.Collections.Generic;


namespace PersistenciaSigeor
{
    public partial class SC_EORMAQUINARIA
    {
        public List<SD_EORMAQUINARIA> DetalleEorMaquinaria { set; get; }
        public SM_DEPOSITO CampoDeposito { set; get; }
        public S_ESTIMATE_PARTY_RESPON CampoResponsable { set; get; }
        public SC_EIR CampoEir { set; get; }
    }
}
