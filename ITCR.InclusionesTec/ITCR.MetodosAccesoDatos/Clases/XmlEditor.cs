using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Interfaces;
#endregion

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
        public void AgregarRegla(Regla pRegla)
        {
            
            XmlElement _xmlElemento = _xmlEditor.CreateElement("regla");

            //Agrega los atributos a los elementos
            XmlAttribute _xmlAtributo = _xmlEditor.CreateAttribute(_sATRIBUTOSREGLA[0]);
            _xmlAtributo.Value = pRegla.Posicion.ToString();
            _xmlElemento.Attributes.Append(_xmlAtributo);

            _xmlAtributo = _xmlEditor.CreateAttribute(_sATRIBUTOSREGLA[1]);
            _xmlAtributo.Value = pRegla.Nombre;
            _xmlElemento.Attributes.Append(_xmlAtributo);

            _xmlAtributo = _xmlEditor.CreateAttribute(_sATRIBUTOSREGLA[2]);
            _xmlAtributo.Value = pRegla.StoredProcedure;
            _xmlElemento.Attributes.Append(_xmlAtributo);

            _xmlAtributo = _xmlEditor.CreateAttribute(_sATRIBUTOSREGLA[3]);
            _xmlAtributo.Value = pRegla.Estado;
            _xmlElemento.Attributes.Append(_xmlAtributo);

            //Agrega los parametros del stored procedure a la regla
            foreach (Parametro _param in pRegla.Parametros)
            {
                XmlElement _xmlParametro= _xmlEditor.CreateElement("param");

                XmlAttribute _xmlAtributoParam = _xmlEditor.CreateAttribute(_sATRIBUTOSPARAMETRO[0]);
                _xmlAtributoParam.Value = _param.Nombre;
                _xmlParametro.Attributes.Append(_xmlAtributoParam);

                _xmlAtributoParam = _xmlEditor.CreateAttribute(_sATRIBUTOSPARAMETRO[1]);
                _xmlAtributoParam.Value = _param.Tipo;
                _xmlParametro.Attributes.Append(_xmlAtributoParam);

                _xmlElemento.AppendChild(_xmlParametro);
            }
            _xmlEditor.DocumentElement.AppendChild(_xmlElemento);
            this.GuardarCambios();
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
                    if (_regla.Attributes[_sATRIBUTOSREGLA[1]].Value.Equals(_rRegla.Nombre))
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
        /// <param name="pParametros"></param>
        public void ModificarProcedureRegla(Regla pRegla)
        {
            XmlNodeList _liReglas = _xmlEditor.SelectNodes(_sNODOSXML[0]);
            foreach (XmlNode _regla in _liReglas)
            {
                if (_regla.Attributes[_sATRIBUTOSREGLA[1]].Value.Equals(pRegla.Nombre))
                {
                    _regla.Attributes[_sATRIBUTOSREGLA[2]].Value = pRegla.StoredProcedure;
                    //Elimina los parametros anteriores
                    foreach (XmlNode _child in _regla.ChildNodes)
                    {
                        _regla.RemoveChild(_child);
                    }
                    //Agrega los parametros del stored procedure a la regla
                    foreach (Parametro _param in pRegla.Parametros)
                    {
                        XmlElement _xmlParametro = _xmlEditor.CreateElement("param");

                        XmlAttribute _xmlAtributoParam = _xmlEditor.CreateAttribute(_sATRIBUTOSPARAMETRO[0]);
                        _xmlAtributoParam.Value = _param.Nombre;
                        _xmlParametro.Attributes.Append(_xmlAtributoParam);

                        _xmlAtributoParam = _xmlEditor.CreateAttribute(_sATRIBUTOSPARAMETRO[1]);
                        _xmlAtributoParam.Value = _param.Tipo;
                        _xmlParametro.Attributes.Append(_xmlAtributoParam);

                        _regla.AppendChild(_xmlParametro);
                    }
                    break;
                }
            } this.GuardarCambios();
        }

        /// <summary>
        /// Habilita una regla del negocio
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        public bool HabilitarRegla(Regla pRegla)
        {
            try
            {
                XmlNodeList _liReglas = _xmlEditor.SelectNodes(_sNODOSXML[0]);
                foreach (XmlNode _regla in _liReglas)
                {
                    if (_regla.Attributes[_sATRIBUTOSREGLA[1]].Value.ToString().Equals(pRegla.Nombre))
                    {
                        _regla.Attributes["posicion"].Value = pRegla.Posicion.ToString();
                        _regla.Attributes["estado"].Value = _sESTADOSREGLAS[0];
                        break;
                    }
                } this.GuardarCambios();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina una regla del negocio.
        /// </summary>
        /// <param name="pRegla"></param>
        public bool DeshabilitarRegla(Regla pRegla)
        {
            try
            {
                XmlNodeList _liReglas = _xmlEditor.SelectNodes(_sNODOSXML[0]);
                foreach (XmlNode _regla in _liReglas)
                {
                    if (_regla.Attributes[_sATRIBUTOSREGLA[1]].Value.ToString().Equals(pRegla.Nombre))
                    {
                        _regla.Attributes["posicion"].Value = "0";
                        _regla.Attributes["estado"].Value = _sESTADOSREGLAS[1];
                        break;
                    }
                } this.GuardarCambios();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        /// <summary>
        /// Retorna la informacion de todas las reglas.
        /// </summary>
        /// <returns></returns>
        public LinkedList<Regla> ObtenerListaReglas()
        {
            try
            {
                XmlNodeList _liNodos = _xmlEditor.SelectNodes(_sNODOSXML[0]);
                LinkedList<Regla> _liReglas = new LinkedList<Regla>();
                foreach (XmlNode _xmlNodo in _liNodos)
                {
                    Regla _regla = new Regla();
                    _regla.Posicion = Int32.Parse(_xmlNodo.Attributes[_sATRIBUTOSREGLA[0]].Value);
                    _regla.Nombre = _xmlNodo.Attributes[_sATRIBUTOSREGLA[1]].Value;
                    _regla.StoredProcedure = _xmlNodo.Attributes[_sATRIBUTOSREGLA[2]].Value;
                    _regla.Estado = _xmlNodo.Attributes[_sATRIBUTOSREGLA[3]].Value;
                    _liReglas.AddLast(_regla);
                }

                return _liReglas;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Constantes
        /// <summary>
        /// Nombra los tags de las reglas.
        /// </summary>
        private string[] _sNODOSXML = { "//regla", "//param" };

        /// <summary>
        /// Nombra los atributos de la regla.
        /// </summary>
        private string[] _sATRIBUTOSREGLA = { "posicion", "nombre", "storedprocedure", "estado"};

        /// <summary>
        /// Nombra los atributos del parametro.
        /// </summary>
        private string[] _sATRIBUTOSPARAMETRO = { "nombre", "tipo" };

        /// <summary>
        /// Representa los estados de las reglas.
        /// </summary>
        private string[] _sESTADOSREGLAS = { "habilitada", "deshabilitada" };
        #endregion

        #region Propiedades
        #endregion
    }
}
