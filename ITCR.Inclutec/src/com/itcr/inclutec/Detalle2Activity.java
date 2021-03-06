package com.itcr.inclutec;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import com.example.itcr.inclutec.R;
import com.example.itcr.inclutec.R.id;
import com.example.itcr.inclutec.R.layout;

import android.os.Bundle;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

@SuppressLint("NewApi")
public class Detalle2Activity extends Activity {

	private String _Solicitud;
	private String _CodigoCurso;
	private String _NombreCurso;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_detalle2);
		getActionBar().setDisplayHomeAsUpEnabled(true);
		getActionBar().setHomeButtonEnabled(true);
		
		//Toma los datos que recibe la pantalla
		Bundle _bunInformacion = this.getIntent().getExtras();
		_Solicitud = _bunInformacion.getString("SOLICITUD");
		_CodigoCurso = _bunInformacion.getString("CODIGO");
		_NombreCurso = _bunInformacion.getString("NOMBRE");
		
		//Asignamos valores a textviews de titulo
		final TextView _txtSolicitud = (TextView)findViewById(R.id.lbl_Solicitud);
		final TextView _txtCodigoCurso = (TextView)findViewById(R.id.lbl_CodigoCurso);
		final TextView _txtNombreCurso = (TextView)findViewById(R.id.lbl_NombreCurso);
		
		_txtSolicitud.setText(/*"Solicitud " +*/ _Solicitud /*+ " "*/);
		_txtCodigoCurso.setText(_CodigoCurso);
		_txtNombreCurso.setText(_NombreCurso);
		
		//Creamos la lista de grupos por solicitud
		final ListView _lvGrupos = (ListView)findViewById(R.id.lv_Grupos);
		
		//Creo arreglo de grupos
		ArrayList<HashMap<String,String>> _arrGrupos = new ArrayList<HashMap<String,String>>();
		
		HashMap<String,String> item1 = new HashMap<String,String>();
		item1.put("NUMGRUPO", "01");
		item1.put("PROFESOR", "Jorge Vargas");
		item1.put("HORARIO", "L J 7:30 - 9:20 am");
		item1.put("SEDE", "Cartago");
		//item1.put("PRIORIDAD", value);
		_arrGrupos.add(item1);
		
		HashMap<String,String> item2 = new HashMap<String,String>();
		item2.put("NUMGRUPO", "02");
		item2.put("PROFESOR", "Jose Castro");
		item2.put("HORARIO", "K J 7:30 - 9:20 am");
		item2.put("SEDE", "Cartago");
		//item1.put("PRIORIDAD", value);
		_arrGrupos.add(item2);
		
		HashMap<String,String> item3 = new HashMap<String,String>();
		item3.put("NUMGRUPO", "03");
		item3.put("PROFESOR", "Jose Helo");
		item3.put("HORARIO", "M V 7:30 - 9:20 am");
		item3.put("SEDE", "Centro Academico");
		//item1.put("PRIORIDAD", value);
		_arrGrupos.add(item3);
		
		
		LVAdapter _adapGrupos = new LVAdapter(this,_arrGrupos);
		_lvGrupos.setAdapter(_adapGrupos);
		
		//final TextView _txtForGrupo = (TextView)findViewById(R.id.lbl_ForGrupo);
		//_lvGrupos.setAdapter(new ArrayAdapter<String>(this,R.layout.detail_child_row,R.id.lbl_Grupo,numGrupo));
		
		/**
		 * Crear el listener para el click en un item de la lista
		 */
		_lvGrupos.setOnItemClickListener( new AdapterView.OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id){
				
			}
		});
		
		
		
	}
	
	@Override
	  public boolean onCreateOptionsMenu(Menu menu) {
	    MenuInflater inflater = getMenuInflater();
	    inflater.inflate(R.menu.detallemenu, menu);
	    return true;
	  }


    @Override
	public boolean onOptionsItemSelected(MenuItem pItem){
		switch(pItem.getItemId()){
			case android.R.id.home:
				Intent _intIntent = new Intent(Detalle2Activity.this, InicioActivity.class);
				startActivity(_intIntent);
				finish();
				return true;
			case R.id.action_anular:
			      Toast.makeText(this, "Action anular selected", Toast.LENGTH_SHORT)
			          .show();
			      return true;
			    case R.id.action_settings:
			      Toast.makeText(this, "Action Settings selected", Toast.LENGTH_SHORT)
			          .show();
			      return true;
			default:
				return super.onOptionsItemSelected(pItem);
		}
	}
	
}
