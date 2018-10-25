using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    [DataContract]
    public class DTOCliente
    {
        [DataMember]
        public string ci;
        [DataMember]
        public string nombre;
        [DataMember]
        public string tel;
        [DataMember]
        public string mail;
    }
}
