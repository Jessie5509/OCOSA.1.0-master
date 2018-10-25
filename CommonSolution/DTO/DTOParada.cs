using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    [DataContract]
    public class DTOParada
    {
        [DataMember]
        public long nro;
        [DataMember]
        public string nombreTramo;

    }
}
