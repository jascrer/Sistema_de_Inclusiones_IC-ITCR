package com.itcr.inclutec;

import java.util.ArrayList;

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
import android.widget.EditText;
import android.widget.ListView;

import com.example.itcr.inclutec.R;

@SuppressLint("NewApi")
public class FormularioDPActivity extends Activity {

	private final String _sNAVEGACION[]=
			new String[]{"INICIO", "FORMULARIO", "SALIR"};
	private ActionBarDrawerToggle _Toggle;
	public final static String _sEXTRA_MESSAGE = "com.itcr.inclutec.MESSAGE";

	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_formulario_dp);
		
		getActionBar().setDisplayHomeAsUpEnabled(true);
		getActionBar().setHomeButtonEnabled(true);
		
		final ListView _lvDrawer = (ListView)findViewById(R.id.listDrawer);
		final DrawerLayout _dlDrawerLayout = (DrawerLayout)findViewById(R.id.drawer_layout);
		
		_lvDrawer.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, 
				android.R.id.text1,_sNAVEGACION));
		
		crearNavegacion(this, _lvDrawer, _dlDrawerLayout);
		
		final Button _btnIngresar = (Button)findViewById(R.id.buttonSend);
		_btnIngresar.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View arg0) {
				final EditText _edtTelefono = (EditText)findViewById(R.id.editTextTelefono);
				final EditText _edtCelular = (EditText)findViewById(R.id.editTextCelular);
				final EditText _edtEmail = (EditText)findViewById(R.id.editTextEmail);
 
				String _sTel = _edtTelefono.getText().toString();
				String _sCel = _edtCelular.getText().toString();
				String _sEmail = _edtEmail.getText().toString();
				ArrayList<String> _sDataBundle = new ArrayList<String>();
				_sDataBundle.add(_sTel);
				_sDataBundle.add(_sCel);
				_sDataBundle.add(_sEmail);
				
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
