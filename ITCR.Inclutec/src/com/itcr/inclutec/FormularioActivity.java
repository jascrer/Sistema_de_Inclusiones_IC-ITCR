package com.itcr.inclutec;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.ActionBarDrawerToggle;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnChildClickListener;
import android.widget.ExpandableListView.OnGroupClickListener;
import android.widget.ExpandableListView.OnGroupCollapseListener;
import android.widget.ExpandableListView.OnGroupExpandListener;
import android.widget.ListView;

import com.example.itcr.inclutec.R;

@SuppressLint("NewApi")
public class FormularioActivity extends Activity {

	ELAdapter listAdapter;
	ExpandableListView expListView;
	List<String> listDataHeader;
	HashMap<String, List<String>> listDataChild;
	private final String _sNAVEGACION[]=
			new String[]{"INICIO", "FORMULARIO", "SALIR"};
	private ActionBarDrawerToggle _Toggle;

	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_formulario);
		
		getActionBar().setDisplayHomeAsUpEnabled(true);
		getActionBar().setHomeButtonEnabled(true);
		
		final ListView _lvDrawer = (ListView)findViewById(R.id.listDrawer);
		final DrawerLayout _dlDrawerLayout = (DrawerLayout)findViewById(R.id.drawer_layout);
		
		_lvDrawer.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, 
				android.R.id.text1,_sNAVEGACION));
		
		crearNavegacion(this, _lvDrawer, _dlDrawerLayout);

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
		
		final Button _btnIngresar = (Button)findViewById(R.id.buttonSend);
		
		_btnIngresar.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View arg0) {
				/** 
				 * Aqui va la parte de la validacion del servicio web
				 * por ahora solo habra el paso del carne del estudiante.
				 */
				//Intent para la creacion de la nueva activity
				Intent _intInicio = new Intent(FormularioActivity.this,InicioActivity.class);
				
				startActivity(_intInicio);
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
		_datosPersonales.add("Correo electrónico");
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
	
	@SuppressLint("NewApi")
	private void crearNavegacion(FormularioActivity pParent, ListView pDrawer, final DrawerLayout pLayout){
		pDrawer.setOnItemClickListener(new OnItemClickListener(){

			@Override
			public void onItemClick(AdapterView<?> arg0, View arg1, int arg2,
					long arg3) {
				pLayout.closeDrawers();
				Intent _iIntent;
				switch(arg2){
					case 1:
						break;
					case 2:
						_iIntent = new Intent(FormularioActivity.this, LoginActivity.class);
						startActivity(_iIntent);
						finish();
						break;
					default:
						_iIntent = new Intent(FormularioActivity.this, InicioActivity.class);
						startActivity(_iIntent);
						finish();
						break;
				}
			}
			
		});
		
		
		// Sombra del panel Navigation Drawer
        pLayout.setDrawerShadow(R.drawable.drawer_shadow, GravityCompat.START);
		
		_Toggle = new ActionBarDrawerToggle(
				pParent,
				pLayout,
				R.drawable.ic_drawer,
				R.string.app_name,
				R.string.app_name){
				@SuppressLint("NewApi")
				public void onDrawerClosed(View view){
					getActionBar().setTitle(
							getResources().getString(R.string.title_activity_formulario));
					invalidateOptionsMenu();
				}
				public void onDrawerOpened(View view){
					getActionBar().setTitle("Navegación");
					invalidateOptionsMenu();
				}
		};
		
		pLayout.setDrawerListener(_Toggle);
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem pItem){
		if (_Toggle.onOptionsItemSelected(pItem)){
			return true;
		}else{
			return super.onOptionsItemSelected(pItem);
		}
	}
	
	@Override
	protected void onPostCreate(Bundle pSavedInstanceState){
		super.onPostCreate(pSavedInstanceState);
		_Toggle.syncState();
	}
}
