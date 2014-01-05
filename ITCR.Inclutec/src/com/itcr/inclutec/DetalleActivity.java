package com.itcr.inclutec;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import com.example.itcr.inclutec.R;

import android.os.Bundle;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.SimpleExpandableListAdapter;
import android.widget.Toast;
import android.annotation.SuppressLint;
import android.app.ExpandableListActivity;

@SuppressLint("NewApi")
public class DetalleActivity extends ExpandableListActivity {

	private String _Curso = "Inteligencia Artificial";
	private String _Profesores[] = new String[]{"Jorge Vargas","Jose Castro"};
	
	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_detalle);
		
		getActionBar().setDisplayHomeAsUpEnabled(true);
		getActionBar().setHomeButtonEnabled(true);
		
		
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
	    for( int n = 0 ; n < 3 ; n++ ) {
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
    public boolean onChildClick( ExpandableListView parent, 
    		View v, int groupPosition,int childPosition,long id) {
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
