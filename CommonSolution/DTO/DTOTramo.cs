using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    [DataContract]
    public class DTOTramo
    {
        [DataMember]
        public long nro;
        [DataMember]
        public string nombre;
        [DataMember]
        public TimeSpan hrSalida;
        [DataMember]
        public TimeSpan hrLlegada;
        [DataMember]
        public string origen;
        [DataMember]
        public string destino;
        [DataMember]
        public float precioByPasajero;
        [DataMember]
        public long nroTurno;

    }
}
