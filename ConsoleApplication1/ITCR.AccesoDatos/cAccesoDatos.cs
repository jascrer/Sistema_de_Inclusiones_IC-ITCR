
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase de acceso a la base de datos
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Domingo, 12 de Diciembre de 2013, 10:50:00 a.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Added Libraries
using System.Xml;
using System.Data;
using System.Collections;
using System.Data.Common;
using System.Transactions;
using System.Data.SqlClient;
#endregion

#region Microsoft Libraries
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging;
#endregion

namespace ITCR.Ado.AccesoDatos
{
    public class cAccesoDatos
    {
        #region Atributos
        /// <summary>
        /// Object which stored the general database manager provide by the application block
        /// </summary>
        private Database _GeneralDatabase;
        #endregion

        #region Constructores
        /// <summary>
        /// Default Constructor
        /// </summary>
        public cAccesoDatos()
        {
            ConnectionStringName = DEFAULT_DATABASE_NAME;
        }

        /// <summary>
        /// Constructor to specify the ConnectionString to use
        /// </summary>
        /// <param name="pConnectionString"></param>
        public cAccesoDatos(string pConnectionString)
            : this()
        {
            ConnectionStringName = pConnectionString;
        }
        #endregion

        #region Metodos

        #region Configuration and General use
        /// <summary>
        /// Get the Database object used from the enterprise library application block
        /// </summary>
        /// <returns>Database object that allows database access</returns>
        protected virtual Database GetDatabase()
        {
            try
            {

                if (_GeneralDatabase == null)
                {
                    _GeneralDatabase = DatabaseFactory.CreateDatabase(ConnectionStringName);
                }
                return _GeneralDatabase;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// Prepare a DbCommand object with its parameters
        /// </summary>
        /// <param name="pStoredProcedureName">Stored procedure name using dbo.Name sintax</param>
        /// <param name="pParameters">Array of cParametroDatos</param>
        /// <param name="pOutputParameters">List of DataParameters that are for output purpose</param>
        /// <param name="pDbAccess">Database Object</param>
        /// <returns>Prepared DbCommand</returns>
        protected virtual DbCommand PrepareCommand(string pStoredProcedureName, IEnumerable<cParametroDatos> pParameters, out IList<cParametroDatos> pOutputParameters, out Database pDbAccess)
        {
            pDbAccess = GetDatabase();
            DbCommand command = pDbAccess.GetStoredProcCommand(pStoredProcedureName);


            pOutputParameters = new List<cParametroDatos>();
            pOutputParameters.Add(new cParametroDatos(RETURN_VALUE, DbType.Int32, ParameterDirection.ReturnValue, 0));

            SqlParameter param = new SqlParameter(RETURN_VALUE, SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(param);

            foreach (cParametroDatos parameter in pParameters)
            {
                pDbAccess.AddParameter(command, parameter.ParameterName, parameter.DbType, parameter.Direction, parameter.ParameterName, DataRowVersion.Current, parameter.Value);
                if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                {
                    pOutputParameters.Add(parameter);
                }
            }
            return command;
        }

        /// <summary>
        /// Fill the parameters value when they are for output
        /// </summary>
        /// <param name="pOutputParameters">Output parameter list</param>
        /// <param name="pCommand">DBCommand with the parameters array full filled</param>
        protected virtual void FillOutputParameters(ref IList<cParametroDatos> pOutputParameters, DbCommand pCommand)
        {
            foreach (cParametroDatos parameter in pOutputParameters)
            {
                if ((string.Compare(parameter.ParameterName, RETURN_VALUE) == 0) && (pCommand.Parameters[parameter.ParameterName].Value == null))
                {
                    parameter.Value = 0;
                }
                else
                {
                    parameter.Value = pCommand.Parameters[parameter.ParameterName].Value;
                }
            }
        }
        #endregion

        #region Execute Data Set

        /// <summary>
        /// Extract one DataSet using all the parameters required
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name using dbo.Name sintax</param>
        /// <param name="parameters">Array of cParametroDatos</param>
        /// <returns>Full fill dataset</returns>
        protected DataSet ExecuteDataSet(string pStoredProcedureName, cParametroDatos[] pParameters)
        {
            int returnValue;
            return ExecuteDataSet(pStoredProcedureName, pParameters, out returnValue);
        }

        /// <summary>
        /// Extract one DataSet using all the parameters required
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name using dbo.Name sintax</param>
        /// <param name="parameters">Array of cParametroDatos</param>
        /// <param name="returnValue">Returns stored procedure return code</param>
        /// <returns>Full fill dataset</returns>
        protected virtual DataSet ExecuteDataSet(string pStoredProcedureName, cParametroDatos[] pParameters, out int pReturnValue)
        {
            DbCommand command = null;
            pReturnValue = NULL_VALUE;
            try
            {
                IList<cParametroDatos> outputParameters;
                Database dbAccess;
                command = PrepareCommand(pStoredProcedureName, pParameters,
                                         out outputParameters, out dbAccess);
                DataSet result = dbAccess.ExecuteDataSet(command);
                FillOutputParameters(ref outputParameters, command);
                pReturnValue = (int)outputParameters[RETURN_VALUE_PARAM_INDEX].Value;

                return result;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
            finally
            {
                if (command != null && command.Connection != null && command.Connection.State == ConnectionState.Open && Transaction.Current == null)
                {
                    command.Connection.Close();
                }
            }
        }

        #endregion Execute Data Set

        #region Execute Scalar

        /// <summary>
        /// Execute a nonquery stored procedure and get its return value
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name using dbo.Name sintax</param>
        /// <param name="parameters">Array of cParametroDatos</param>
        /// <returns>Stored procedure return code</returns>
        protected virtual int ExecuteScalar(string pStoredProcedureName, cParametroDatos[] pParameters)
        {
            DbCommand command = null;
            try
            {
                IList<cParametroDatos> outputParameters;
                Database dbAccess;
                command = PrepareCommand(pStoredProcedureName, pParameters, out outputParameters, out dbAccess);

                dbAccess.ExecuteNonQuery(command);
                FillOutputParameters(ref outputParameters, command);

                return (int)outputParameters[RETURN_VALUE_PARAM_INDEX].Value;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return NULL_VALUE;
            }
            finally
            {
                if (command != null && command.Connection != null && command.Connection.State == ConnectionState.Open && Transaction.Current == null)
                {
                    command.Connection.Close();
                }
            }
        }

        #endregion Execute Scalar

        #region Execute XML

        /// <summary>
        /// This method executes a stored procedure.  It should be used with FOR XML
        /// commands only, without using Lock for concurrency
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="parameters">Parameters of the stored procedure</param>
        /// <returns>An XmlNode with the return value of the stored procedure</returns>
        protected XmlNode ExecuteXml(string pStoredProcedureName, cParametroDatos[] pParameters)
        {
            int returnValue;
            XmlNode xmlNode = ExecuteXml(pStoredProcedureName, XML_ROOT_NODE, pParameters, out returnValue);
            return (xmlNode == null) ? null : xmlNode.FirstChild.FirstChild;
        }

        /// <summary>
        /// This method executes a stored procedure.  It should be used with FOR XML
        /// commands only, without using Lock for concurrency
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="rootElementName">Name for the root element (it can be null)</param>
        /// <param name="parameters">Parameters of the stored procedure</param>
        /// <param name="returnValue">Value returned of the Stored Procedure</param>
        /// <returns>An XmlNode with the return value of the stored procedure</returns>
        protected virtual XmlNode ExecuteXml(string storedProcedureName,
                                     string rootElementName, cParametroDatos[] parameters, out int returnValue)
        {
            IDataReader reader = null;
            DbCommand command = null;
            returnValue = NULL_VALUE;

            try
            {
                IList<cParametroDatos> outputParameters;
                Database dbAccess;
                command = PrepareCommand(storedProcedureName, parameters,
                                         out outputParameters, out dbAccess);

                reader = dbAccess.ExecuteReader(command);


                FillOutputParameters(ref outputParameters, command);
                returnValue = (int)outputParameters[RETURN_VALUE_PARAM_INDEX].Value;

                StringBuilder sb = new StringBuilder();

                //Opens Root element
                sb.Append(TAG_OPEN_START);
                sb.Append(rootElementName);
                sb.Append(TAG_CLOSE);

                while (reader.Read())
                {
                    sb.Append(reader.GetString(0));
                }

                //Closes Root element
                sb.Append(TAG_OPEN_END);
                sb.Append(rootElementName);
                sb.Append(TAG_CLOSE);

                XmlDocument xmlResult = new XmlDocument();
                xmlResult.LoadXml(sb.ToString());

                return xmlResult;
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (command != null && command.Connection != null && command.Connection.State == ConnectionState.Open && Transaction.Current == null)
                {
                    command.Connection.Close();
                }
            }
        }

        #endregion Execute XML
        #endregion

        #region Propiedades
        /// <summary>
        /// Stores the name of the connection string to use
        /// </summary>
        public string ConnectionStringName { get; set; }

        /// <summary>
        /// Actual conexion
        /// </summary>
        public DbConnection CurrentConnection { get; set; }
        
        /// <summary>
        /// Gets and sets any error message
        /// </summary>
        public string LastErrorMessage { get; set; }
        #endregion

        #region Constantes
        /// <summary>
        /// Constant for the name of return value in SQL Server
        /// </summary>
        private string RETURN_VALUE = "@@RETURN_VALUE";
        /// <summary>
        /// Default value for a returning null value
        /// </summary>
        protected int NULL_VALUE = -1;
        /// <summary>
        /// Index for the param that must have the return value 
        /// </summary>
        private int RETURN_VALUE_PARAM_INDEX = 0;
        /// <summary>
        /// Root xml node name
        /// </summary>
        private string XML_ROOT_NODE = "rootXml";
        /// <summary>
        /// Symbol to open a new tag
        /// </summary>
        private string TAG_OPEN_START = "<";
        /// <summary>
        /// Symbol to close a tag
        /// </summary>
        private string TAG_CLOSE = ">";
        /// <summary>
        /// Closing symbol for tag
        /// </summary>
        private string TAG_OPEN_END = "</";
        /// <summary>
        /// Default name for the main database access connection string
        /// </summary>
        public string DEFAULT_DATABASE_NAME = "Inclutec_BD";
        #endregion
    }
}
