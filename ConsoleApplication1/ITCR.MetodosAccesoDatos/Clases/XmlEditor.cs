using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Interfaces;

namespace ITCR.MetodosAccesoDatos.Clases
{
    public class XmlEditor : IXmlEditor
    {        
        #region Atributos
        /// <summary>
        /// Nombre del archivo que se va a editar.
        /// </summary>
        XmlDocument _xmlEditor;
        /// <summary>
        /// Representa el nombre del archivo
        /// </summary>
        string _sNombreArchivo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="pNombreArchivo"></param>
        public XmlEditor(string pNombreArchivo)
        {
            _sNombreArchivo = pNombreArchivo;
            _xmlEditor = new XmlDocument();
            _xmlEditor.Load(pNombreArchivo);
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guarda los cambios hechos al documento.
        /// </summary>
        private void GuardarCambios()
        {
            _xmlEditor.PreserveWhitespace = true;
            XmlTextWriter _textWriter = new XmlTextWriter(_sNombreArchivo, Encoding.Unicode);
            _xmlEditor.WriteTo(_textWriter);
            _textWriter.Close();
        }

        /// <summary>
        /// Agrega una regla al archivo xml.
        /// </summary>
        /// <param name="pRegla"></param>
        public void AgregarRegla(Regla pRegla, string pProcedimiento)
        {

        }

        /// <summary>
        /// Modifica el orden de las reglas establecido
        /// en el archivo OrdenReglas.xml.
        /// </summary>
        /// <param name="pReglas"></param>
        public void ModificarPrioridadReglas(LinkedList<Regla> pReglas)
        {
            XmlNodeList _liReglas = _xmlEditor.SelectNodes(_sNODOSXML[0]);
            foreach (Regla _rRegla in pReglas)
            {
                foreach (XmlNode _regla in _liReglas)
                {
                    if (_regla.Attributes[_sATRIBUTOSREGLA[1]].Equals(_rRegla.Nombre))
                    {
                        _regla.Attributes[_sATRIBUTOSREGLA[0]].Value = _rRegla.Posicion.ToString();
                        break;
                    }
                }
            } this.GuardarCambios();
        }

        /// <summary>
        /// Modifica el procedimiento de una regla del negocio.
        /// </summary>
        /// <param name="pRegla"></param>
        /// <param name="pProcedimiento"></param>
        public void ModificarProcedureRegla(Regla pRegla, string pProcedimiento)
        {
            XmlNodeList _liReglas = _xmlEditor.SelectNodes(_sNODOSXML[0]);
            foreach (XmlNode _regla in _liReglas)
            {
                if (_regla.Attributes[_sATRIBUTOSREGLA[1]].Equals(pRegla.Nombre))
                {
                    _regla.Attributes[_sATRIBUTOSREGLA[2]].Value = pRegla.StoredProcedure;
                    break;
                }
            } this.GuardarCambios();
        }

        /// <summary>
        /// Elimina una regla del negocio.
        /// </summary>
        /// <param name="pRegla"></param>
        public void EliminarRegla(Regla pRegla)
        {
            XmlNodeList _liReglas = _xmlEditor.SelectNodes(_sNODOSXML[0]);
            foreach (XmlNode _regla in _liReglas)
            {
                if (_regla.Attributes[_sATRIBUTOSREGLA[1]].Equals(pRegla.Nombre))
                {
                    _regla.RemoveAll();
                    _xmlEditor.RemoveChild(_regla);
                    break;
                }
            } this.GuardarCambios();
        }
        #endregion

        #region Constantes
        /// <summary>
        /// Nombra los tags de las reglas.
        /// </summary>
        private string[] _sNODOSXML = { "//Regla", "//param" };

        /// <summary>
        /// Nombra los atributos de la regla.
        /// </summary>
        private string[] _sATRIBUTOSREGLA = { "posicion", "nombre", "storedprocedure"};

        /// <summary>
        /// Nombra los atributos del parametro.
        /// </summary>
        private string[] _sATRIBUTOSPARAMETRO = { "nombre", "tipo" };
        #endregion

        #region Propiedades
        #endregion
    }
}
