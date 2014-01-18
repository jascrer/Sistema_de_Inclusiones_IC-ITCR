package com.itcr.inclutec;

import java.util.ArrayList;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONArray;
import org.json.JSONObject;

import com.example.itcr.inclutec.R;
import com.example.itcr.inclutec.R.layout;
import com.example.itcr.inclutec.R.menu;
import com.google.gson.Gson;
import com.itcr.inclutec.clases_comunes.Curso;
import com.itcr.inclutec.clases_comunes.Estudiante;
import com.itcr.inclutec.clases_comunes.PlanEstudios;

import android.os.Build;
import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.support.v4.app.NavUtils;

public class FormularioCursosActivity extends Activity {
	
	private final String _sCURSOS[]=
			new String[]{"Inteligencia Artificial", "Principios de Sistemas Operativos", "Diseño de Software"};
	private final String _sMATRICULADOS[]=
			new String[]{"Investigación de Operaciones"};
	public final static String _sEXTRA_MESSAGE = "com.itcr.inclutec.MESSAGE";
	ArrayList<String> _alCursos = new ArrayList<String>();
	HttpClient httpClient = new DefaultHttpClient();
	HttpGet _getCursos;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_formulario_cursos);
		// Make sure we're running on Honeycomb or higher to use ActionBar APIs
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB) {
            // Show the Up button in the action bar.
            getActionBar().setDisplayHomeAsUpEnabled(true);
        }
        
        Intent intent = getIntent();
        final ArrayList<String> _sDataBundle = intent.getStringArrayListExtra(FormularioDPActivity._sEXTRA_MESSAGE);
        
        _getCursos = new HttpGet("http://10.0.2.2:3740/RestServicioEstudiante.svc/cursos");
		_getCursos.setHeader("content-type", "application/json");
		JSONObject respJSON;
		JSONArray respJSON2;
		
		try
		{
		        HttpResponse resp = httpClient.execute(_getCursos);
		        String respStr = EntityUtils.toString(resp.getEntity());
		        Log.e("ServicioRestCursos",respStr);
		     
		        respJSON = new JSONObject(respStr);
		        respJSON2 = respJSON.getJSONArray("ObtenerCursosResult");
		        Log.e("Cursos",respJSON2.toString());
		        
		        for(int i = 0; i<respJSON2.length(); i++){
		        	JSONObject _jCurso = respJSON2.getJSONObject(i);
		        	Curso _cCurso = new Gson().fromJson(_jCurso.toString(),Curso.class);
		        	_alCursos.add(_cCurso.getTxt_Curso());
		        }
		        
		}
		catch(Exception ex)
		{
		        Log.e("ServicioRest","Error!", ex);
		}
        
        final AutoCompleteTextView _actvCursos;
        _actvCursos = (AutoCompleteTextView) findViewById(R.id.autoCompleteTextView1);
        ArrayAdapter _aaCursos = new ArrayAdapter (this,android.R.layout.simple_list_item_1,_alCursos);
        _actvCursos.setAdapter(_aaCursos);
        
        final ListView _lvMatriculados;
        _lvMatriculados = (ListView) findViewById(R.id.listView1);
        ArrayAdapter _aaMatricula = new ArrayAdapter (this,android.R.layout.simple_list_item_1,_sMATRICULADOS);
        _lvMatriculados.setAdapter(_aaMatricula);
        
        final Button _btnIngresar = (Button)findViewById(R.id.button1);
		_btnIngresar.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View arg0) {
				
				String _sCurso = _actvCursos.getText().toString();
				_sDataBundle.add(_sCurso);
				
				//Intent para la creacion de la nueva activity
				Intent _intSiguiente = new Intent(FormularioCursosActivity.this,FormularioComentarioActivity.class);
				_intSiguiente.putExtra(_sEXTRA_MESSAGE, _sDataBundle);
				startActivity(_intSiguiente);
			}
			
		});
        
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.formulario_cursos, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case android.R.id.home:
			// This ID represents the Home or Up button. In the case of this
			// activity, the Up button is shown. Use NavUtils to allow users
			// to navigate up one level in the application structure. For
			// more details, see the Navigation pattern on Android Design:
			//
			// http://developer.android.com/design/patterns/navigation.html#up-vs-back
			//
			NavUtils.navigateUpFromSameTask(this);
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

}
