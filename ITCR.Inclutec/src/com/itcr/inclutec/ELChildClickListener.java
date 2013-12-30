package com.itcr.inclutec;

import android.content.Context;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnChildClickListener;

public class ELChildClickListener implements OnChildClickListener {
	
	Context contexto;

	public ELChildClickListener(Context con) {
		// TODO Auto-generated constructor stub
		this.contexto = con;
	}

	@Override
	public boolean onChildClick(ExpandableListView arg0, View arg1, int arg2,
			int arg3, long arg4) {
		// TODO Auto-generated method stub
		return false;
	}

}
