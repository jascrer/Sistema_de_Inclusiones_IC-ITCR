package com.itcr.inclutec;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.annotation.SuppressLint;
import android.app.ExpandableListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.ActionBarDrawerToggle;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.ExpandableListView;
import android.widget.ListView;
import android.widget.SimpleExpandableListAdapter;
import android.widget.TextView;

import com.example.itcr.inclutec.R;

@SuppressLint("NewApi")
public class InicioActivity extends ExpandableListActivity {

	//Arreglo con el nombre de los grupos
	private final String _sGRUPOS[] = 
			new String[]{"PENDIENTES","ACEPTADAS","RECHAZADAS", "ANULADAS"};
	private final String _sNAVEGACION[]=
			new String[]{"INICIO", "FORMULARIO", "SALIR"};
	private ActionBarDrawerToggle _Toggle;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_inicio);
		
		getActionBar().setDisplayHomeAsUpEnabled(true);
		getActionBar().setHomeButtonEnabled(true);
		
		final ListView _lvDrawer = (ListView)findViewById(R.id.listDrawer);
		final DrawerLayout _dlDrawerLayout = (DrawerLayout)findViewById(R.id.drawer_layout);
		
		_lvDrawer.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, 
				android.R.id.text1,_sNAVEGACION));
		
		this.crearNavegacion(this, _lvDrawer, _dlDrawerLayout);
		//Crea el ExpandableListView
		try{
			@SuppressWarnings("unchecked")
			SimpleExpandableListAdapter _adapList =
					new SimpleExpandableListAdapter(this,
							crearListaGrupos(),
							R.layout.group_row,
							new String[]{"Group Item"},
							new int[]{R.id.row_name},
							crearListaItems(),
							R.layout.child_row,
							new String[]{"Sub Item"},
							new int[]{R.id.grp_child});
			setListAdapter(_adapList);
			
			
		}catch(Exception e){
		}
	}
	
	/**
	 * @return Lista con el nombre de los grupos
	 */
	@SuppressWarnings({ "rawtypes", "unchecked" })
	private List crearListaGrupos(){
		ArrayList _lListaGrupos = new ArrayList();
		
		for(String _sGrupo : _sGRUPOS){
			HashMap _hmMapa = new HashMap<String,String>();
			_hmMapa.put("Group Item", _sGrupo);
			_lListaGrupos.add(_hmMapa);
		}return (List)_lListaGrupos;
	}
	
	/**
	 * @return Lista con el nombre de los items
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
    private List crearListaItems() {
 
        ArrayList _lListaItems = new ArrayList();
        for( int i = 0 ; i < _sGRUPOS.length ; ++i ) { // this -15 is the number of groups(Here it's fifteen)
          /* each group need each HashMap-Here for each group we have 3 subgroups */
          ArrayList _lItems = new ArrayList();
          for( int n = 0 ; n < 3 ; n++ ) {
            HashMap _hmMapaItem = new HashMap();
            /* Aqui se debe cambiar el nombre asignado de "Sub Item" 
             * por el nombre de las materias.
             * "'Sub Item' + n" por la materia
             */
            //_hmMapaItem.put( "Sub Item", "Sub Item " + n );
            _hmMapaItem.put("Sub Item", "Solicitud " + n);
            _lItems.add( _hmMapaItem );
          }
         _lListaItems.add( _lItems );
        }
        return _lListaItems;
    }
	
	@SuppressLint("NewApi")
	private void crearNavegacion(InicioActivity pParent, ListView pDrawer, final DrawerLayout pLayout){
		pDrawer.setOnItemClickListener(new OnItemClickListener(){

			@Override
			public void onItemClick(AdapterView<?> arg0, View arg1, int arg2,
					long arg3) {
				pLayout.closeDrawers();
				Intent _iIntent;
				switch(arg2){
					case 1:
						_iIntent = new Intent(InicioActivity.this, FormularioActivity.class);
						startActivity(_iIntent);
						finish();
						break;
					case 2:
						_iIntent = new Intent(InicioActivity.this, LoginActivity.class);
						startActivity(_iIntent);
						finish();
						break;
					default:
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
							getResources().getString(R.string.title_activity_inicio));
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
	
	public void  onContentChanged  () {
        super.onContentChanged();
    }
	
	/**
	 * Con esta funcion se sabe si se hizo click en una materia
	 */
    @SuppressLint("ShowToast")
	public boolean onChildClick( ExpandableListView parent, 
    		View v, int groupPosition,int childPosition,long id) {
		Intent _intDetalle = new Intent(InicioActivity.this, DetalleActivity.class);
		String _sMateria = ((TextView)v.findViewById(R.id.grp_child))
							.getText().toString();
		
		Bundle _bunInformacion = new Bundle();
		_bunInformacion.putString("NOMBRE",_sMateria);
		_intDetalle.putExtras(_bunInformacion);
		
		startActivity(_intDetalle);
		finish();
        return true;
    }
 
    /**
     * Con esta funcion se sabe si un grupo ha sido
     * seleccionado
     */
    public void  onGroupExpand  (int groupPosition) {
        try{
        }catch(Exception e){
        }
    }
}
