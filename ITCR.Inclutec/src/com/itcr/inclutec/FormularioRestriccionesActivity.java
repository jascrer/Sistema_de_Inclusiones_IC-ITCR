package com.itcr.inclutec;

import java.util.ArrayList;

import com.example.itcr.inclutec.R;
import com.example.itcr.inclutec.R.layout;
import com.example.itcr.inclutec.R.menu;

import android.os.Build;
import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import android.support.v4.app.NavUtils;

public class FormularioRestriccionesActivity extends Activity {

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
        
        final Button _btnIngresar = (Button)findViewById(R.id.button1);
		_btnIngresar.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View arg0) {
				
				//String _sCurso = _actvCursos.getText().toString();
				//_sDataBundle.add(_sCurso);
				
				//Intent para la creacion de la nueva activity
				Intent _intSiguiente = new Intent(FormularioRestriccionesActivity.this,InicioActivity.class);
				//_intSiguiente.putExtra(_sEXTRA_MESSAGE, _sDataBundle);
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
