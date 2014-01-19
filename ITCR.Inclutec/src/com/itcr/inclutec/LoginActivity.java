package com.itcr.inclutec;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URL;

import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONObject;

import com.example.itcr.inclutec.R;
import com.itcr.inclutec.util.SystemUiHider;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.Window;
import android.widget.Button;
import android.widget.TextView;
/**
 * An example full-screen activity that shows and hides the system UI (i.e.
 * status bar and navigation/system bar) with user interaction.
 * 
 * @see SystemUiHider
 */
public class LoginActivity extends Activity {
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		//Le quita el titulo a la aplicacion
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		
		setContentView(R.layout.activity_login);

		//Campos de texto para el login
		final TextView _txtCarne = (TextView)findViewById(R.id.editText1);
		final TextView _txtPin = (TextView)findViewById(R.id.editText2);
		
		//Boton de ingreso
		final Button _btnIngresar = (Button)findViewById(R.id.button1);
		
		StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
	    StrictMode.setThreadPolicy(policy);
		
		_btnIngresar.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View arg0) {
				/** 
				 * Aqui va la parte de la validacion del servicio web
				 * por ahora solo habra el paso del carne del estudiante.
				 */
				String _sCarne = _txtCarne.getText().toString();
				String _sPin = _txtPin.getText().toString();
				//boolean _bExiste = callWebErvice(_sCarne, _sPin);
				boolean _bExiste = true;
				
				if(_bExiste){
					//Intent para la creacion de la nueva activity
					Intent _intInicio = new Intent(LoginActivity.this,InicioActivity.class);
					
					//Bundle para el paso de informacion entre activities
					Bundle _bunInformacion = new Bundle();
					_bunInformacion.putString("CARNE", _txtCarne.getText().toString());
					_intInicio.putExtras(_bunInformacion);
					
					startActivity(_intInicio);
				}
				else{
					
				}
				
			}
			
		});
	}
	boolean callWebErvice(String _sCarne, String _sPin){
		HttpClient httpClient = new DefaultHttpClient();
		HttpGet del =
		    new HttpGet("http://10.0.2.2:3740/RestServicioLogin.svc/login/?carne="+_sCarne+"&pin="+_sPin);
		del.setHeader("content-type", "application/json");
		
		boolean resultCli = false;
		
		try
		{
		        HttpResponse resp = httpClient.execute(del);
		        String respStr = EntityUtils.toString(resp.getEntity());
		        Log.e("ServicioRest",respStr);
		        
		        JSONObject respJSON = new JSONObject(respStr);
		        
		        resultCli = respJSON.getBoolean("VerificarEstudianteResult");
		}
		catch(Exception ex)
		{
		        Log.e("ServicioRest","Error!", ex);
		}
		
		return resultCli;
	}
}
