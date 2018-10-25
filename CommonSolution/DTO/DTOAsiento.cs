using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    [DataContract]
    public class DTOAsiento
    {
        [DataMember]
        public long nro;
        [DataMember]
        public bool reservado;
        [DataMember]
        public long nroCoche;

    }
}
