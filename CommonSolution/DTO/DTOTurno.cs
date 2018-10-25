using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    [DataContract]
    public class DTOTurno
    {
        [DataMember]
        public long nro;
        [DataMember]
        public List<DayOfWeek> colDias;
        [DataMember]
        public string origenTurno;
        [DataMember]
        public string destinoTurno;
        [DataMember]
        public long nroCoche;

    }
}
