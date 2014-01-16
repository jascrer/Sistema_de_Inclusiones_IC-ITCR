package com.itcr.inclutec.clases_comunes;

public class Estudiante {
	public String Id_Carnet, 
				  Nom_Nombre,
				  Txt_Apellido1,
				  Txt_Apellido2,
				  Num_Telefono,
				  Num_Celular,
				  Dir_Email;
	public int Id_Plan_Estudios;
	
	public String getId_Carnet() {
		return Id_Carnet;
	}
	public void setId_Carnet(String id_Carnet) {
		Id_Carnet = id_Carnet;
	}
	public String getNom_Nombre() {
		return Nom_Nombre;
	}
	public void setNom_Nombre(String nom_Nombre) {
		Nom_Nombre = nom_Nombre;
	}
	public String getTxt_Apellido1() {
		return Txt_Apellido1;
	}
	public void setTxt_Apellido1(String txt_Apellido1) {
		Txt_Apellido1 = txt_Apellido1;
	}
	public String getTxt_Apellido2() {
		return Txt_Apellido2;
	}
	public void setTxt_Apellido2(String txt_Apellido2) {
		Txt_Apellido2 = txt_Apellido2;
	}
	public String getNum_Telefono() {
		return Num_Telefono;
	}
	public void setNum_Telefono(String num_Telefono) {
		Num_Telefono = num_Telefono;
	}
	public String getNum_Celular() {
		return Num_Celular;
	}
	public void setNum_Celular(String num_Celular) {
		Num_Celular = num_Celular;
	}
	public String getDir_Email() {
		return Dir_Email;
	}
	public void setDir_Email(String dir_Email) {
		Dir_Email = dir_Email;
	}
	public int getId_Plan_Estudios() {
		return Id_Plan_Estudios;
	}
	public void setId_Plan_Estudios(int id_Plan_Estudios) {
		Id_Plan_Estudios = id_Plan_Estudios;
	}
}
