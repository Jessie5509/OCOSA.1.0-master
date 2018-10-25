using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    [DataContract]
    public class DTOReserva
    {
        [DataMember]
        public long nro;
        [DataMember]
        public DateTime dtTurno;
        [DataMember]
        public float precioTotal;
        [DataMember]
        public DateTime dtEmision;
        [DataMember]
        public string ciCli;
        [DataMember]
        public long nroTurno;
        [DataMember]
        public List<DTOAsiento> colAsientos;


    }
}
