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
        void AgregarRegla(Regla pRegla);

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
        /// <param name="pParametros"></param>
        void ModificarProcedureRegla(Regla pRegla);

        /// <summary>
        /// Habilita una regla del negocio
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        bool HabilitarRegla(Regla pRegla);

        /// <summary>
        /// Deshabilita una regla del negocio.
        /// </summary>
        /// <param name="pRegla"></param>
        bool DeshabilitarRegla(Regla pRegla);
        #endregion
    }
}
