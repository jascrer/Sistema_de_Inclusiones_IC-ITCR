package com.itcr.inclutec;

import com.example.itcr.inclutec.R;
import com.itcr.inclutec.util.SystemUiHider;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
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
		//final TextView _txtPin = (TextView)findViewById(R.id.editText2);
		
		//Boton de ingreso
		final Button _btnIngresar = (Button)findViewById(R.id.button1);
		
		_btnIngresar.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View arg0) {
				/** 
				 * Aqui va la parte de la validacion del servicio web
				 * por ahora solo habra el paso del carne del estudiante.
				 */
				//Intent para la creacion de la nueva activity
				Intent _intInicio = new Intent(LoginActivity.this,InicioActivity.class);
				
				//Bundle para el paso de informacion entre activities
				Bundle _bunInformacion = new Bundle();
				_bunInformacion.putString("CARNE", _txtCarne.getText().toString());
				_intInicio.putExtras(_bunInformacion);
				
				startActivity(_intInicio);
			}
			
		});
	}
}