package com.itcr.inclutec;

import java.util.ArrayList;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.sql.Date;

import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONException;
import org.json.JSONObject;

import com.example.itcr.inclutec.R;
import com.example.itcr.inclutec.R.layout;
import com.example.itcr.inclutec.R.menu;
import com.google.gson.Gson;
import com.itcr.inclutec.clases_comunes.Solicitud;

import android.os.Build;
import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import android.support.v4.app.NavUtils;

public class FormularioRestriccionesActivity extends Activity {
	HttpClient httpClient = new DefaultHttpClient();
	HttpPost _postSolicitud;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_formulario_comentario);
		if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB) {
            // Show the Up button in the action bar.
            getActionBar().setDisplayHomeAsUpEnabled(true);
        }
        
        Intent intent = getIntent();
        final ArrayList<String> _sDataBundle = intent.getStringArrayListExtra(FormularioDPActivity._sEXTRA_MESSAGE);
        Log.v("DataBundle", _sDataBundle.toString());
        
        final TextView _tvComment = (TextView) findViewById(R.id.editTextComment);
        
        final Button _btnIngresar = (Button)findViewById(R.id.button1);
		_btnIngresar.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View arg0) {
				
				Solicitud _solNueva = new Solicitud();
				_solNueva.setTxt_Comentario(_tvComment.getText().toString());
				_solNueva.setTxt_Curso(_sDataBundle.get(4));
				_solNueva.setTxt_Estado("PENDIENTE");
				_solNueva.setTxt_Motivo("bun");
				
				_postSolicitud = new HttpPost("http://10.0.2.2:3740/RestServicioEstudiante.svc/solicitud/crear/?estudiante="+_sDataBundle.get(0)+"&periodo=1");
				_postSolicitud.setHeader("content-type", "application/json");
				
				Gson _gSolicitud = new Gson();
				
				JSONObject _jsonDatos = new JSONObject();
				try {
					JSONObject _jSolicitud = new JSONObject(_gSolicitud.toJson(_solNueva));
					_jsonDatos.put("pSolicitud", _jSolicitud);
					Log.v("Solicitud",_jsonDatos.toString());
					
					StringEntity _jsonSolicitud = new StringEntity(_jsonDatos.toString());
					_postSolicitud.setEntity(_jsonSolicitud);
				    HttpResponse resp = httpClient.execute(_postSolicitud);
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
				Intent _intSiguiente = new Intent(FormularioRestriccionesActivity.this,InicioActivity.class);
				Bundle _bunInformacion = new Bundle();
				_bunInformacion.putString("CARNE", _sDataBundle.get(0));
				_intSiguiente.putExtras(_bunInformacion);
				Toast.makeText(getApplicationContext(), "Solicitud enviada", Toast.LENGTH_LONG).show();
				startActivity(_intSiguiente);
			}
			
		});
        
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.formulario_restricciones, menu);
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
