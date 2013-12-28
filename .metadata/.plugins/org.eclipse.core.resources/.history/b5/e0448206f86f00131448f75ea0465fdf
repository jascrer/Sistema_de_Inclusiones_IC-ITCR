package com.example.itcr.inclutec;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

public class ELAdapter extends BaseExpandableListAdapter {
	
	Context contexto;
	String[]padre = {"IC-XXXX Curso de prueba 1", "IC-YYYY Curso de prueba 2"};
	String[][]hijos = {
			{"Grupo 1", "Grupo 2"},
			{"Grupo 3", "Grupo 4"}
	};

	public ELAdapter(Context con) {
		// TODO Auto-generated constructor stub
		this.contexto = con;
	}

	@Override
	public Object getChild(int arg0, int arg1) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public long getChildId(int arg0, int arg1) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public View getChildView(int arg0, int arg1, boolean arg2, View arg3,
			ViewGroup arg4) {
		// TODO Auto-generated method stub
		TextView _tv = new TextView(contexto);
		_tv.setText(hijos[arg0][arg1]);
		_tv.setTextSize(18);
		return _tv;
	}

	@Override
	public int getChildrenCount(int arg0) {
		// TODO Auto-generated method stub
		return hijos[arg0].length;
	}

	@Override
	public Object getGroup(int arg0) {
		// TODO Auto-generated method stub
		return arg0;
	}

	@Override
	public int getGroupCount() {
		// TODO Auto-generated method stub
		return padre.length;
	}

	@Override
	public long getGroupId(int arg0) {
		// TODO Auto-generated method stub
		return arg0;
	}

	@Override
	public View getGroupView(int groupPosition, boolean arg1, View arg2, ViewGroup arg3) {
		// TODO Auto-generated method stub
		TextView tv = new TextView(contexto);
		tv.setText(this.padre[groupPosition]);
		tv.setTextSize(20);
		return tv;
	}

	@Override
	public boolean hasStableIds() {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean isChildSelectable(int arg0, int arg1) {
		// TODO Auto-generated method stub
		return true;
	}
	
}