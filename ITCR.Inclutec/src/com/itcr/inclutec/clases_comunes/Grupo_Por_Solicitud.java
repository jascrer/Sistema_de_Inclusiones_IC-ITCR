package com.itcr.inclutec.clases_comunes;

public class Grupo_Por_Solicitud {
	public int Id_Grupo_Por_Solicitud, Num_Prioridad;
    public Grupo Id_Grupo;
	public int getId_Grupo_Por_Solicitud() {
		return Id_Grupo_Por_Solicitud;
	}
	public void setId_Grupo_Por_Solicitud(int id_Grupo_Por_Solicitud) {
		Id_Grupo_Por_Solicitud = id_Grupo_Por_Solicitud;
	}
	public int getNum_Prioridad() {
		return Num_Prioridad;
	}
	public void setNum_Prioridad(int num_Prioridad) {
		Num_Prioridad = num_Prioridad;
	}
	public Grupo getId_Grupo() {
		return Id_Grupo;
	}
	public void setId_Grupo(Grupo id_Grupo) {
		Id_Grupo = id_Grupo;
	}
}
