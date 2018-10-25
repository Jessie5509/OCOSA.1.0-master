using ExcelLibrary.SpreadSheet;
using OfficeOpenXml;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace FileManagement.FileControllers
{
    public enum NOMBRES_ARCHIVOS { CLIENTES }
    public class BaseFileHelper
    {
        protected string createOrGetFile(string nombreArchivo, List<string> propiedades)
        {
            string URL_DATA_DIR = "C://BASE_DATOS_COSA";
            bool exists = System.IO.Directory.Exists(URL_DATA_DIR);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(URL_DATA_DIR);
            }

            string name = string.Format("{0}.xlsx", nombreArchivo);
            string full_path = string.Format(@"{0}/{1}", URL_DATA_DIR, name);

            if (!System.IO.File.Exists(full_path))
            {
                FileInfo fi = new FileInfo(full_path);
                using (ExcelPackage package = new ExcelPackage(fi))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("Clientes");
                    for (int i = 0; i < propiedades.Count; i++)
                    {
                        ws.Cells[1, i + 1].Value = propiedades[i];
                    }
                    package.Save();
                }
                
            }

            return full_path;

        }

        public string getURLArchivo(string nombreArchivo)
        {
            string URL_DATA_DIR = "C://DATA_WEB_APP";
            string full_path = string.Format(@"{0}/{1}{2}", URL_DATA_DIR, nombreArchivo, ".xlsx");
            return full_path;
        }
    }
}
