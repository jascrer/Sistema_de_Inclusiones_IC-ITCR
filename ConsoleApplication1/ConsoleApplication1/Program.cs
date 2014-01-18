using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

#region Imported Libraries
using System.Data;
using System.Data.Linq;
using System.Threading;
using System.Data.Entity;
using System.Data.Linq.Mapping;
#endregion

#region Microsoft Practices Libraries
using Microsoft.Practices.EnterpriseLibrary.Data;
#endregion

#region Librerias Inclutec
using ITCR.Ado.ModeloAcDatos;
using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Interfaces;
using ITCR.MetodosAccesoDatos.Clases;
#endregion

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IXmlEditor _xmlEditor = new XmlEditor("OrdenReglas.xml");
            LinkedList<Regla> lista = _xmlEditor.ObtenerListaReglas();
            foreach (Regla regla in lista)
            {
                Console.WriteLine(regla.Nombre);
            }
            Console.ReadLine();
        }
    }
}
