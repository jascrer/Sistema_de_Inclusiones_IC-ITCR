package com.itcr.inclutec.clases_comunes;

import java.sql.Date;
import java.util.LinkedList;

public class Solicitud {
	public int Id_Solicitud;

    public String Txt_Comentario, txt_Curso, Txt_Motivo;
    public Date Fec_Creacion;
    public String Txt_Estado;
    public LinkedList<Grupo_Por_Solicitud> Li_Grupos;
    public int Id_GrupoAceptado;
    
    /////////////////////////////////////////////
    public int getId_Solicitud() {
		return Id_Solicitud;
	}
	public void setId_Solicitud(int id_Solicitud) {
		Id_Solicitud = id_Solicitud;
	}
	public String getTxt_Comentario() {
		return Txt_Comentario;
	}
	public void setTxt_Comentario(String txt_Comentario) {
		Txt_Comentario = txt_Comentario;
	}
	public String getTxt_Curso() {
		return txt_Curso;
	}
	public void setTxt_Curso(String txt_Curso) {
		this.txt_Curso = txt_Curso;
	}
	public String getTxt_Motivo() {
		return Txt_Motivo;
	}
	public void setTxt_Motivo(String txt_Motivo) {
		Txt_Motivo = txt_Motivo;
	}
	public Date getFec_Creacion() {
		return Fec_Creacion;
	}
	public void setFec_Creacion(Date fec_Creacion) {
		Fec_Creacion = fec_Creacion;
	}
	public String getTxt_Estado() {
		return Txt_Estado;
	}
	public void setTxt_Estado(String txt_Estado) {
		Txt_Estado = txt_Estado;
	}
	public LinkedList<Grupo_Por_Solicitud> getLi_Grupos() {
		return Li_Grupos;
	}
	public void setLi_Grupos(LinkedList<Grupo_Por_Solicitud> li_Grupos) {
		Li_Grupos = li_Grupos;
	}
	public int getId_GrupoAceptado() {
		return Id_GrupoAceptado;
	}
	public void setId_GrupoAceptado(int id_GrupoAceptado) {
		Id_GrupoAceptado = id_GrupoAceptado;
	}
}
