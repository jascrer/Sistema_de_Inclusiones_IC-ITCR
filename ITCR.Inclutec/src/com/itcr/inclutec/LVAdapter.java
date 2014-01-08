package com.itcr.inclutec;

import java.util.ArrayList;
import java.util.HashMap;

import com.example.itcr.inclutec.R;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

public class LVAdapter extends BaseAdapter {

	private Activity _actividad;
	private ArrayList<HashMap<String,String>> _items;
	private static LayoutInflater inflater = null;
	
	public LVAdapter(Activity p_actividad, ArrayList<HashMap<String,String>> p_items) {
		
		_actividad = p_actividad;
		_items = p_items;
		inflater = (LayoutInflater)_actividad.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
		
	}
	
	public long getItemId(int position) {
		return position;
	}
	
	public int getCount() {
		return _items.size();
	}
	
	public Object getItem(int position) {
		return position;
	}
	
	
	public View getView(int position, View convertView, ViewGroup parent) {
        View vi = convertView;
        if(convertView == null)
            vi = inflater.inflate(R.layout.detail_child_row, null);
        
        TextView _txtForGrupo = (TextView)vi.findViewById(R.id.lbl_ForGrupo); // fijo de label Grupo
        TextView _txtGrupo = (TextView)vi.findViewById(R.id.lbl_Grupo);
        TextView _txtProfesor = (TextView)vi.findViewById(R.id.lbl_Profesor);
        TextView _txtHorario = (TextView)vi.findViewById(R.id.lbl_Horario);
        TextView _txtSede = (TextView)vi.findViewById(R.id.lbl_Sede);
        
        HashMap<String, String> item = new HashMap<String,String>();
        item = _items.get(position);
        
        //Asigno valores al item
        _txtForGrupo.setText("Grupo");
        _txtGrupo.setText(item.get("NUMGRUPO"));
        _txtProfesor.setText("Profesor: " + item.get("PROFESOR"));
        //_txtProfesor.setText(item.get("PROFESOR"));
        _txtHorario.setText("Horario: " + item.get("HORARIO"));
        _txtSede.setText("Sede: " + item.get("SEDE"));
        
        return vi;
    }
	
}

	
