package com.itcr.inclutec.clases_comunes;

public class Horario {
	public int Id_Horario;
    public String Txt_Dia, Txt_Hora_Inicio, Txt_Hora_Final;
	public int getId_Horario() {
		return Id_Horario;
	}
	public void setId_Horario(int id_Horario) {
		Id_Horario = id_Horario;
	}
	public String getTxt_Dia() {
		return Txt_Dia;
	}
	public void setTxt_Dia(String txt_Dia) {
		Txt_Dia = txt_Dia;
	}
	public String getTxt_Hora_Inicio() {
		return Txt_Hora_Inicio;
	}
	public void setTxt_Hora_Inicio(String txt_Hora_Inicio) {
		Txt_Hora_Inicio = txt_Hora_Inicio;
	}
	public String getTxt_Hora_Final() {
		return Txt_Hora_Final;
	}
	public void setTxt_Hora_Final(String txt_Hora_Final) {
		Txt_Hora_Final = txt_Hora_Final;
	}
}
