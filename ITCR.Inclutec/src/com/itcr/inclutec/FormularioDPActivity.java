package com.itcr.inclutec;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;

import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONException;
import org.json.JSONObject;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.ActionBarDrawerToggle;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.itcr.inclutec.R;
import com.google.gson.Gson;
import com.itcr.inclutec.clases_comunes.Estudiante;
import com.itcr.inclutec.clases_comunes.PlanEstudios;

@SuppressLint("NewApi")
public class FormularioDPActivity extends Activity {

	private final String _sNAVEGACION[]=
			new String[]{"INICIO", "FORMULARIO", "SALIR"};
	private final String _PERSONALES[]=
			new String[]{"nombre",
			"apellido1",
			"apellido2",
			"telefono",
			"celular",
			"email",
			"plan"};
	private ActionBarDrawerToggle _Toggle;
	public final static String _sEXTRA_MESSAGE = "com.itcr.inclutec.MESSAGE";
	String _sCarnet;
	HttpClient httpClient = new DefaultHttpClient();
	HttpGet _getDatos, _getPlan;
	HttpPut _putContacto;
	Estudiante _eActual;
	PlanEstudios _pActual;

	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_formulario_dp);
		
		Intent _intentAnterior = getIntent();
        _sCarnet = _intentAnterior.getStringExtra("CARNE");
		
		getActionBar().setDisplayHomeAsUpEnabled(true);
		getActionBar().setHomeButtonEnabled(true);
		
		final ListView _lvDrawer = (ListView)findViewById(R.id.listDrawer);
		final DrawerLayout _dlDrawerLayout = (DrawerLayout)findViewById(R.id.drawer_layout);
		
		_lvDrawer.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, 
				android.R.id.text1,_sNAVEGACION));
		
		crearNavegacion(this, _lvDrawer, _dlDrawerLayout);
		//////////////////////////////////////////////////////////////////////
		
		_getDatos = new HttpGet("http://10.0.2.2:3740/RestServicioEstudiante.svc/estudiante/?id="+_sCarnet);
		_getDatos.setHeader("content-type", "application/json");
		_getPlan = new HttpGet("http://10.0.2.2:3740/RestServicioEstudiante.svc/plan/?id="+_sCarnet);
		_getPlan.setHeader("content-type", "application/json");
		JSONObject respJSON, respJSON2, respJSON3, respJSON4;
		
		try
		{
		        HttpResponse resp = httpClient.execute(_getDatos);
		        String respStr = EntityUtils.toString(resp.getEntity());
		        Log.e("ServicioRestDatos",respStr);
		        
		        HttpResponse resp2 = httpClient.execute(_getPlan);
		        String respStr2 = EntityUtils.toString(resp2.getEntity());
		        Log.e("ServicioRestPlan",respStr2);
		        
		        respJSON = new JSONObject(respStr);
		        respJSON2 = respJSON.getJSONObject("ObtenerInformacionEstudianteResult");
		        _eActual = new Gson().fromJson(respJSON2.toString(),Estudiante.class);
		        
		        respJSON3 = new JSONObject(respStr2);
		        respJSON4 = respJSON3.getJSONObject("ObtenerPlanEstudiosResult");
		        _pActual = new Gson().fromJson(respJSON4.toString(),PlanEstudios.class);
		        
		        _PERSONALES[0] = _eActual.getNom_Nombre();
		        _PERSONALES[1] = _eActual.getTxt_Apellido1();
		        _PERSONALES[2] = _eActual.getTxt_Apellido2();
		        _PERSONALES[3] = _eActual.getNum_Telefono();
		        _PERSONALES[4] = _eActual.getNum_Celular();
		        _PERSONALES[5] = _eActual.getDir_Email();
		        _PERSONALES[6] = ""+_pActual.getId_Plan_Estudios();
		}
		catch(Exception ex)
		{
		        Log.e("ServicioRest","Error!", ex);
		}
		////////////////////////////////////////////////////////////
		final TextView _tvNombre = (TextView)findViewById(R.id.textViewNombre);
		_tvNombre.setText(_PERSONALES[0] + " " +_PERSONALES[1] + " " + _PERSONALES[2]);
		final TextView _tvCarnet = (TextView)findViewById(R.id.textViewCarnet);
		_tvCarnet.setText(_sCarnet);
		
		final EditText _edtTelefono = (EditText)findViewById(R.id.editTextTelefono);
		final EditText _edtCelular = (EditText)findViewById(R.id.editTextCelular);
		final EditText _edtEmail = (EditText)findViewById(R.id.editTextEmail);
		_edtTelefono.setText(_PERSONALES[3]);
		_edtCelular.setText(_PERSONALES[4]);
		_edtEmail.setText(_PERSONALES[5]);
		
		final TextView _tvPlan = (TextView)findViewById(R.id.textViewPlan);
		_tvPlan.setText(_PERSONALES[6]);
		
		final Button _btnIngresar = (Button)findViewById(R.id.buttonSend);
		_btnIngresar.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View arg0) {
 
				String _sTel = _edtTelefono.getText().toString();
				String _sCel = _edtCelular.getText().toString();
				String _sEmail = _edtEmail.getText().toString();
				ArrayList<String> _sDataBundle = new ArrayList<String>();
				_sDataBundle.add(_sTel);
				_sDataBundle.add(_sCel);
				_sDataBundle.add(_sEmail);
				
				_eActual.setDir_Email(_sEmail);
				_eActual.setNum_Celular(_sCel);
				_eActual.setNum_Telefono(_sTel);
				
				
				_putContacto = new HttpPut("http://10.0.2.2:3740/RestServicioEstudiante.svc/estudiante");
				_putContacto.setHeader("content-type", "application/json");
				
				Gson _gEstudiante = new Gson();
				
				JSONObject _jsonDatos = new JSONObject();
				try {
					JSONObject _jEstudiante = new JSONObject(_gEstudiante.toJson(_eActual));
					_jsonDatos.put("pEstudiante", _jEstudiante);
					_jsonDatos.put("pPlanEstudios", _pActual.getId_Plan_Estudios());
					
					StringEntity _jsonEstudiante = new StringEntity(_jsonDatos.toString());
					_putContacto.setEntity(_jsonEstudiante);
				    HttpResponse resp = httpClient.execute(_putContacto);
				    String respStr = EntityUtils.toString(resp.getEntity());
				    Log.e("respStr", respStr);
					
				} catch (JSONException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				} catch (UnsupportedEncodingException e2) {
					// TODO Auto-generated catch block
					e2.printStackTrace();
				} catch (ClientProtocolException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
				//Intent para la creacion de la nueva activity
				Intent _intSiguiente = new Intent(FormularioDPActivity.this,FormularioCursosActivity.class);
				_intSiguiente.putExtra(_sEXTRA_MESSAGE, _sDataBundle);
				startActivity(_intSiguiente);
			}
			
		});
	}
	
	@SuppressLint("NewApi")
	private void crearNavegacion(FormularioDPActivity pParent, ListView pDrawer, final DrawerLayout pLayout){
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
						_iIntent = new Intent(FormularioDPActivity.this, LoginActivity.class);
						startActivity(_iIntent);
						finish();
						break;
					default:
						_iIntent = new Intent(FormularioDPActivity.this, InicioActivity.class);
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
