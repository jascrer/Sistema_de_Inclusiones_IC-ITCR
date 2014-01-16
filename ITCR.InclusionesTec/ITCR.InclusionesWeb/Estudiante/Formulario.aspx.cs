using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Clases;
using ITCR.MetodosAccesoDatos.Interfaces;
#endregion

namespace ITCR.InclusionesWeb.Estudiante
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GET datos estudiante con un carnet
            string Txt_Carnet = "200966799";

            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            //Revisamos si el estudiante existe en la bd local
            bool Bin_EstudianteExiste = _metEstudiante.EstudianteExiste(Txt_Carnet);
            //Obtenemos info del estudiante
            Ado.ClasesComunes.Estudiante _estudianteNuevo = new Ado.ClasesComunes.Estudiante();
            _estudianteNuevo = _metEstudiante.ObtenerDatosEstudiante(Txt_Carnet, Bin_EstudianteExiste);
            //Obtenemos plan de estudios del estudiante y lo asignamos
            Ado.ClasesComunes.PlanEstudios _planNuevo = new Ado.ClasesComunes.PlanEstudios();
            _planNuevo = _metEstudiante.ObtenerPlanEstudios(Txt_Carnet, Bin_EstudianteExiste);
            if (!Bin_EstudianteExiste)
            {
                _estudianteNuevo.Id_Plan_Estudios = _planNuevo.Id_Plan_Estudios;
            }

            //Datos de backup
            string Txt_Nombre = "ROJAS VALVERDE JUAN JOSE";
            string Txt_Carrera = "INGENIERIA EN COMPUTACION";
            string Txt_Sede = "CARTAGO";
            int Num_Plan = 409;
            string Txt_CitaMatricula = "08:00:00";
            string Txt_Telefono = "22924768";
            string Txt_Celular = "85032291";
            string Txt_CorreoElectronico = "acalvo@gmail.com";

            //Asigna datos estudiante a controles
            lblNombreCompleto.Text = _estudianteNuevo.Txt_Apellido1 + " " + _estudianteNuevo.Txt_Apellido2 + " " + _estudianteNuevo.Nom_Nombre;
            lblCarnet.Text = _estudianteNuevo.Id_Carnet;
            lblCarrera.Text = _planNuevo.Nom_Carrera;
            lblSede.Text = Txt_Sede;
            lblPlan.Text = _planNuevo.Id_Plan_Estudios.ToString();
            lblCitaMatricula.Text = Txt_CitaMatricula;
            txtTelefono.Text = _estudianteNuevo.Num_Telefono;
            txtCelular.Text = _estudianteNuevo.Num_Celular;
            txtCorreo.Text = _estudianteNuevo.Dir_Email;

            //Encuentra cursos y llena el autocomplete
            
        }
    }
}