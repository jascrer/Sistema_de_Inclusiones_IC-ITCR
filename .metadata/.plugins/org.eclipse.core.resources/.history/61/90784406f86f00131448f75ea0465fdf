package com.example.itcr.inclutec;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.widget.ExpandableListView;

public class ModifyActivity extends Activity {
	
	ExpandableListView exv;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_modify);
		
		exv = (ExpandableListView) findViewById(R.id.expandableListView1);
		exv.setAdapter(new ELAdapter(this));
		
		exv.setOnChildClickListener(new ELChildClickListener(this));
		
		}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.modify, menu);
		return true;
	}

}
