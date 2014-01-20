package com.itcr.inclutec.clases_comunes;

import java.util.LinkedList;

public class Grupo {
	public int Id_Grupo, Num_Grupo, Num_Cupos, Num_Cupos_Extra, Id_Curso;
    public int getId_Grupo() {
		return Id_Grupo;
	}
	public void setId_Grupo(int id_Grupo) {
		Id_Grupo = id_Grupo;
	}
	public int getNum_Grupo() {
		return Num_Grupo;
	}
	public void setNum_Grupo(int num_Grupo) {
		Num_Grupo = num_Grupo;
	}
	public int getNum_Cupos() {
		return Num_Cupos;
	}
	public void setNum_Cupos(int num_Cupos) {
		Num_Cupos = num_Cupos;
	}
	public int getNum_Cupos_Extra() {
		return Num_Cupos_Extra;
	}
	public void setNum_Cupos_Extra(int num_Cupos_Extra) {
		Num_Cupos_Extra = num_Cupos_Extra;
	}
	public int getId_Curso() {
		return Id_Curso;
	}
	public void setId_Curso(int id_Curso) {
		Id_Curso = id_Curso;
	}
	public LinkedList<Horario> getLi_Horarios() {
		return Li_Horarios;
	}
	public void setLi_Horarios(LinkedList<Horario> li_Horarios) {
		Li_Horarios = li_Horarios;
	}
	public LinkedList<Horario> Li_Horarios;
}
