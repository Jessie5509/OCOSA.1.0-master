using CommonSolution.Clases;
using CommonSolution.DTO;
using FileManagement.FileControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpers
{
    public class ClienteHelper
    {
        public DTOCliente getCliente(string ci)
        {
            ClienteFileController cfc = new ClienteFileController();
                return cfc.getCliente(ci);
        }



        // -------------------------------------
        public void addCliente(DTOCliente cliente)
        {
            ClienteFileController cfc = new ClienteFileController();
            cfc.addClienteExcel(cliente);
            
        }




        /* public void validarCliente(DTOCliente cliente, Response respuesta)
         {

             if (string.IsNullOrEmpty(cliente.cedula))
             {
                 respuesta.setError("Error! Cédula requerida");
             }

             if (string.IsNullOrEmpty(cliente.nombre))
             {
                 respuesta.setError("Error! Nombre requerido");
             }

             if (cliente.nombre.Length > 30)
             {
                 respuesta.setError("Error! El nombre no puede superar los 30 caracteres");
             }           
         }
         */
    }
}
