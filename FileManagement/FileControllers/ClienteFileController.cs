using CommonSolution.Constantes;
using CommonSolution.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web.Script.Serialization;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using OfficeOpenXml;
using System.IO;

namespace FileManagement.FileControllers
{
    public class ClienteFileController : BaseFileHelper
    {
                  

        public DTOCliente getCliente(string ci)
        {
            List<string> colPropiedades = new List<string>() { "CI", "NOMBRE", "TEL", "MAIL" };
            string urlFile = createOrGetFile(CCliente.NOMBRE_ARCHIVO_CLIENTES, colPropiedades);
            FileInfo fi = new FileInfo(urlFile);

            DTOCliente Cliente = null;

            using (ExcelPackage excelCliente = new ExcelPackage(fi))
            {
                ExcelWorksheet ws = excelCliente.Workbook.Worksheets.FirstOrDefault();
              
               
                //Definimos el el rango de celdas que seran leidas
                var exlRange = ws.SelectedRange.End.Row +1 ;

                //Recorremos el archivo excel como si fuera una matriz
                for (int i = 1; i <= exlRange; i++)
                {
                        if (ws.Cells[i, 1].Value.ToString() == ci)
                        {


                            Cliente = new DTOCliente();

                            Cliente.ci = ws.Cells[i, 1].Value.ToString();
                            Cliente.nombre = ws.Cells[i, 2].Value.ToString();
                            Cliente.tel = ws.Cells[i, 3].Value.ToString();
                            Cliente.mail = ws.Cells[i, 4].Value.ToString();
                        }

                }

                excelCliente.Save();
            }

            return Cliente;
        }


        public void addClienteExcel(DTOCliente cliente)
        {
            List<string> colPropiedades = new List<string>() { "CI", "NOMBRE","TEL","MAIL"};
            string urlFile = createOrGetFile(CCliente.NOMBRE_ARCHIVO_CLIENTES, colPropiedades);
            FileInfo fi = new FileInfo(urlFile);
            using (ExcelPackage excelCliente = new ExcelPackage(fi))
            {
                int lastRow = 1;
                ExcelWorksheet ws = excelCliente.Workbook.Worksheets.FirstOrDefault();
                if (ws.Dimension != null)
                {
                    lastRow = ws.Dimension.End.Row + 1;
                }
                ws.Cells[lastRow, 1].Value = cliente.ci;
                ws.Cells[lastRow, 2].Value = cliente.nombre;
                ws.Cells[lastRow, 3].Value = cliente.tel;
                ws.Cells[lastRow, 4].Value = cliente.mail;


                excelCliente.Save();
            }

        }
    }
}
