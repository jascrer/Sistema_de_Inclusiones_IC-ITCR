using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Interfaces;
#endregion

namespace ITCR.MetodosAccesoDatos.Clases
{
    public class MetodosAdministrador : IMetodosAdministrador
    {        
        #region Atributos
        #endregion

        #region Constructores
        #endregion

        #region Metodos
        /**
         * Devuelve la lista de solicitudes del periodo.
         **/
        public LinkedList<string> ObtenerReporteSolicitudes()
        {
            return null;
        }

        /**
         * Devuelve la lista de sugerencias para nuevos grupos.
         **/
        public LinkedList<string> ObtenerReporteSugerencias()
        {
            return null;
        }

        /**
         * Agrega una regla al negocio.
         **/
        public bool AgregarRegla(int pPosicion, string pNombreRegla,
            string pNombreProcedimiento, string pProcedimiento)
        {
            return true;
        }

        /**
         * Define un periodo para la aceptacion de solicitudes.
         **/
        public bool DefinirPeriodoSolicitud(Periodo pPeriodo)
        {
            return true;
        }

        /**
         * Modifica el estado del periodo.
         **/
        public bool ModificarEstadoPeriodo(string pEstado)
        {
            return true;
        }

        /**
         * Modifica el orden de las reglas establecido
         * en el archivo OrdenReglas.xml.
         **/
        public bool ModificarOrdenReglas(LinkedList<string> pReglas)
        {
            return true;
        }

        /**
         * Modifica el procedimiento de una regla del negocio.
         **/
        public bool ModificarProcedimientoRegla(string pNombreProcedimiento, string pProcedimiento)
        {
            return true;
        }

        /**
         * Elimina una regla del negocio.
         **/
        public bool EliminarRegla(string pRegla)
        {
            return true;
        }
        #endregion

        #region Propiedades
        #endregion
    }
}
