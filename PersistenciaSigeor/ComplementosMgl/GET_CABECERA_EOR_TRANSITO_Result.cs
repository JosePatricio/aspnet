using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PersistenciaSigeor
{
    public partial class GET_CABECERA_EOR_TRANSITO_Result
    {
        [DataMember]
        public Decimal TotalReal
        {
            set;
            get;
        }

        //[DataMember]
        //public Decimal TotalRealMaquinaria
        //{
        //    set;
        //    get;
        //}
    }
}
