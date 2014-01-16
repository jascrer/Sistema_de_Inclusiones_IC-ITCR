using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AjaxControlToolkit;

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
            string Txt_Carnet = (string)Session["NUsuario"];

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
            string Txt_Sede = "CARTAGO";
            string Txt_CitaMatricula = "08:00:00";

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
            LinkedList<Curso> _cursos = new LinkedList<Curso>();
            _cursos = _metEstudiante.ObtenerCursosEstudiante(Txt_Carnet, null);

            foreach (var _cursoActual in _cursos)
            {
                ListItem _item = new ListItem();
                _item.Value = _cursoActual.Id_Curso.ToString();
                _item.Text = _cursoActual.Txt_Curso;
                ddlCursos.Items.Add(_item);
            }

            Session["Estudiante"] = _estudianteNuevo;
            Session["Plan"] = _planNuevo;
        }

        protected void ddlCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            Ado.ClasesComunes.Estudiante _estudianteDatos = (Ado.ClasesComunes.Estudiante)Session["Estudiante"];
            LinkedList<Curso> _cursos = new LinkedList<Curso>();
            _cursos = _metEstudiante.ObtenerCursosEstudiante(_estudianteDatos.Id_Carnet, null);
            int Num_CursoSeleccionado = int.Parse(ddlCursos.SelectedValue);
            lblCodigoCursoSeleccionado.Text = Num_CursoSeleccionado.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Ado.ClasesComunes.Estudiante _estudianteDatos = (Ado.ClasesComunes.Estudiante)Session["Estudiante"];
            PlanEstudios _planEstudios = (PlanEstudios)Session["Plan"];

            IMetodosAdministrador _metAdmin = new MetodosAdministrador();
            Periodo _perUltimo = _metAdmin.UltimoPeriodo();

            Solicitud _solicitudNueva = new Solicitud();
            _solicitudNueva.Fec_Creacion = DateTime.Now;
            _solicitudNueva.Txt_Comentario = txtComentario.Text;
            _solicitudNueva.txt_Curso = ddlCursos.SelectedValue;
            _solicitudNueva.Txt_Estado = "PENDIENTE";
            _solicitudNueva.Txt_Motivo = "";

            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            _metEstudiante.GuardarDatosEstudiantes(_estudianteDatos, _planEstudios.Id_Plan_Estudios);

            if ((_perUltimo.Fec_Inicio <= _solicitudNueva.Fec_Creacion) &&
                (_perUltimo.Fec_Fin >= _solicitudNueva.Fec_Creacion))
            {
                _metEstudiante.GuardarSolicitud(_estudianteDatos.Id_Carnet, _perUltimo.Id_Periodo, _solicitudNueva);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Error al crear la solicitud",
                    "alert('Su solicitud no pudo ser procesada, ya que no fue realizada dentro del periodo de recepción",true);
            }
        }   
            
    }
}