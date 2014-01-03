package com.itcr.inclutec;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import com.example.itcr.inclutec.R;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnChildClickListener;
import android.widget.ExpandableListView.OnGroupClickListener;
import android.widget.ExpandableListView.OnGroupCollapseListener;
import android.widget.ExpandableListView.OnGroupExpandListener;

public class FormularioActivity extends Activity {

	ELAdapter listAdapter;
	ExpandableListView expListView;
	List<String> listDataHeader;
	HashMap<String, List<String>> listDataChild;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_formulario);

		// get the listview
		expListView = (ExpandableListView) findViewById(R.id.listaForm);

		// preparing list data
		prepareListData();

		listAdapter = new ELAdapter(this, listDataHeader, listDataChild);

		// setting list adapter
		expListView.setAdapter(listAdapter);

		// Listview Group click listener
		expListView.setOnGroupClickListener(new OnGroupClickListener() {

			@Override
			public boolean onGroupClick(ExpandableListView parent, View v,
					int groupPosition, long id) {
				// Toast.makeText(getApplicationContext(),
				// "Group Clicked " + listDataHeader.get(groupPosition),
				// Toast.LENGTH_SHORT).show();
				return false;
			}
		});

		// Listview Group expanded listener
		expListView.setOnGroupExpandListener(new OnGroupExpandListener() {

			@Override
			public void onGroupExpand(int groupPosition) {
				
			}
		});

		// Listview Group collasped listener
		expListView.setOnGroupCollapseListener(new OnGroupCollapseListener() {

			@Override
			public void onGroupCollapse(int groupPosition) {
				
			}
		});

		// Listview on child click listener
		expListView.setOnChildClickListener(new OnChildClickListener() {

			@Override
			public boolean onChildClick(ExpandableListView parent, View v,
					int groupPosition, int childPosition, long id) {
				// TODO Auto-generated method stub
				return false;
			}
		});
	}

	/*
	 * Preparing the list data
	 */
	private void prepareListData() {
		listDataHeader = new ArrayList<String>();
		listDataChild = new HashMap<String, List<String>>();

		// Adding child data
		listDataHeader.add("Datos personales");
		listDataHeader.add("Curso");
		listDataHeader.add("Cursos matriculados");
		listDataHeader.add("Requisitos y otros");
		listDataHeader.add("Comentario adicional");

		// Adding child data
		List<String> _datosPersonales = new ArrayList<String>();
		_datosPersonales.add("Nombre");
		_datosPersonales.add("Carné");
		_datosPersonales.add("Teléfono");
		_datosPersonales.add("Celular");
		_datosPersonales.add("Correo");
		_datosPersonales.add("Plan de estudios");
		_datosPersonales.add("Cita de matrícula");

		List<String> _curso = new ArrayList<String>();
		_curso.add("IC-XXXX");

		List<String> _cursosMatriculados = new ArrayList<String>();
		_cursosMatriculados.add("IC-YYYY");
		
		List<String> _requisitos = new ArrayList<String>();
		_requisitos.add("IC-ZZZZ");
		
		List<String> _comentario = new ArrayList<String>();
		_comentario.add("Comentario de inclusión");

		listDataChild.put(listDataHeader.get(0), _datosPersonales); // Header, Child data
		listDataChild.put(listDataHeader.get(1), _curso);
		listDataChild.put(listDataHeader.get(2), _cursosMatriculados);
		listDataChild.put(listDataHeader.get(3), _requisitos);
		listDataChild.put(listDataHeader.get(4), _comentario);
	}
}
