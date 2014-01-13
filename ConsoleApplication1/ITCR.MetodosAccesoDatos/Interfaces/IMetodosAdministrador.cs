
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Interfaz que publica los metodos para el Administrador.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Lunes, 30 de Diciembre de 2013, 2:20:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ITCR.Ado.ClasesComunes;

namespace ITCR.MetodosAccesoDatos.Interfaces
{
    public interface IMetodosAdministrador
    {
        /**
         * Devuelve la lista de solicitudes del periodo.
         **/
        LinkedList<string> ObtenerReporteSolicitudes();

        /**
         * Devuelve la lista de sugerencias para nuevos grupos.
         **/
        LinkedList<string> ObtenerReporteSugerencias();

        /**
         * Agrega una regla al negocio.
         **/
        bool AgregarRegla(Regla pRegla);

        /**
         * Define un periodo para la aceptacion de solicitudes.
         **/
        bool DefinirPeriodoSolicitud(Periodo pPeriodo);

        /**
         * Modifica el estado del periodo.
         **/
        bool ModificarEstadoPeriodo(int pPeriodo, string pEstado);
        
        /**
         * Modifica el orden de las reglas establecido
         * en el archivo OrdenReglas.xml.
         **/
        bool ModificarOrdenReglas(LinkedList<Regla> pReglas);

        /**
         * Modifica el procedimiento de una regla del negocio.
         **/
        bool ModificarProcedimientoRegla(Regla pNombreProcedimiento, string pProcedimiento);

        /**
         * Elimina una regla del negocio.
         **/
        bool EliminarRegla(Regla pRegla);
        
    }
}
