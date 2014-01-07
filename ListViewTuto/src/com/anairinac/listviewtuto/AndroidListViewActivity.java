package com.anairinac.listviewtuto;

import android.os.Bundle;
import android.app.Activity;
import android.app.ListActivity;
import android.content.Intent;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.view.View;

public class AndroidListViewActivity extends ListActivity {

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		//store string resources
		String[] adobe_products = getResources().getStringArray(R.array.adobe_products);
		
		//bind resources to list adapter
		
		this.setListAdapter(new ArrayAdapter<String>(this,R.layout.list_item,R.id.label,adobe_products));
	}
	
}
