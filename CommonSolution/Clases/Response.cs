using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Clases
{
    public enum ESTADO { OK, ERROR }
    public class Response
    {
        public ESTADO estado;

        public string msg;

        public void setError(string msg)
        {
            this.estado = ESTADO.ERROR;
            this.msg = msg;
        }

        public void setOk(string msg)
        {
            this.estado = ESTADO.OK;
            this.msg = msg;
        }

        public bool isError()
        {
            if (this.estado == ESTADO.ERROR)
                return true;

            return false;            
        }
    }
}
