using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ITCR.Ado.ClasesComunes;

namespace ITCR.MetodosAccesoDatos.Interfaces
{
    public interface IXmlEditor
    {
        #region Metodos
        /// <summary>
        /// Guarda los cambios hechos al documento.
        /// </summary>
        //void GuardarCambios();

        /// <summary>
        /// Agrega una regla al archivo xml.
        /// </summary>
        /// <param name="pRegla"></param>
        void AgregarRegla(Regla pRegla, string pProcedimiento);

        /// <summary>
        /// Modifica el orden de las reglas establecido
        /// en el archivo OrdenReglas.xml.
        /// </summary>
        /// <param name="pReglas"></param>
        void ModificarPrioridadReglas(LinkedList<Regla> pReglas);

        /// <summary>
        /// Modifica el procedimiento de una regla del negocio.
        /// </summary>
        /// <param name="pRegla"></param>
        /// <param name="pProcedimiento"></param>
        void ModificarProcedureRegla(Regla pRegla, string pProcedimiento);

        /// <summary>
        /// Elimina una regla del negocio.
        /// </summary>
        /// <param name="pRegla"></param>
        void EliminarRegla(Regla pRegla);
        #endregion
    }
}
