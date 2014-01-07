package com.itcr.inclutec;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.app.ExpandableListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.SimpleExpandableListAdapter;

import com.example.itcr.inclutec.R;

@SuppressLint("NewApi")
public class DetalleActivity extends ExpandableListActivity {

	private String _Solicitud;
	private String _Curso = "Inteligencia Artificial";
	private String _Profesores[] = new String[]{"Jorge Vargas","Jose Castro"};
	
	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_detalle);
		getActionBar().setDisplayHomeAsUpEnabled(true);
		getActionBar().setHomeButtonEnabled(true);
		
		Bundle _bunInformacion = this.getIntent().getExtras();
		_Curso = _bunInformacion.getString("NOMBRE");
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
							R.layout.detail_child_row,
							new String[]{"Sub Item"},
							new int[]{R.id.grp_child});
			setListAdapter(_adapList);
			
			ExpandableListView _elvLista=(ExpandableListView) findViewById(android.R.id.list);
			
			
			
			_elvLista.expandGroup(0);
			
			
			this.getExpandableListView().setChoiceMode(ExpandableListView.CHOICE_MODE_SINGLE);
			
			
		}catch(Exception e){
		}
	}

	/**
	 * @return Lista con el nombre de los grupos
	 */
	@SuppressWarnings({ "rawtypes", "unchecked" })
	private List crearListaGrupos(){
		ArrayList _lListaGrupos = new ArrayList();
		
		HashMap _hmMapa = new HashMap<String,String>();
		_hmMapa.put("Group Item", _Curso);
		_lListaGrupos.add(_hmMapa);
		
		return (List)_lListaGrupos;
	}
	
	/**
	 * @return Lista con el nombre de los items
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
    private List crearListaItems() {
        ArrayList _lListaItems = new ArrayList();
        
	    ArrayList _lItems = new ArrayList();
	    for( int n = 0 ; n < _Profesores.length ; n++ ) {
	      HashMap _hmMapaItem = new HashMap();
	      /* Aqui se debe cambiar el nombre asignado de "Sub Item" 
	       * por el nombre de las materias.
	       * "'Sub Item' + n" por la materia
	       */
	      _hmMapaItem.put( "Sub Item",_Profesores[n] );
	      _lItems.add( _hmMapaItem );
	    }
	    
         _lListaItems.add( _lItems );
        return _lListaItems;
    }

	public void  onContentChanged  () {
        super.onContentChanged();
    }
	
	/**
	 * Con esta funcion se sabe si se hizo click en una materia
	 */
	/*
    public boolean onChildClick( ExpandableListView parent, 
    		View v, int groupPosition,int childPosition,long id) {
        return true;
    }*/
    /**
     * Con esta funcion se sabe si se hizo click largo en un grupo
     */
    public boolean onChildLongClick( ExpandableListView parent,
    		View v, int groupPosition,int childPosition,long id){
    	
    	//Abrir context
    	AlertDialog.Builder _dialItemSeleccionado = new AlertDialog.Builder(DetalleActivity.this);
    	_dialItemSeleccionado.setTitle("Seleccionado");
    	_dialItemSeleccionado.setMessage("Desea eliminar el grupo " + 
    					childPosition+" de la solicitud?");
    	_dialItemSeleccionado.setNegativeButton("Cancelar", null);
    	_dialItemSeleccionado.setPositiveButton("OK", null);
    	
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
    
    @Override
	public boolean onOptionsItemSelected(MenuItem pItem){
		switch(pItem.getItemId()){
			case android.R.id.home:
				Intent _intIntent = new Intent(DetalleActivity.this, InicioActivity.class);
				startActivity(_intIntent);
				finish();
				return true;
			default:
				return super.onOptionsItemSelected(pItem);
		}
	}
}
