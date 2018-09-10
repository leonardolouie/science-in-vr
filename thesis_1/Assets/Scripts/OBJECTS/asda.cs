using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asda : MonoBehaviour {
	public Text a;
	int b=0;
	bool is1 = false;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (!is1) {
			b++;
			a.text = b.ToString ("0")+ "%";
			if (b == 100) 
				is1 = true;
		} else {
			b--;
			a.text = b.ToString ("0")+"%";
			if (b == 0) 
				is1 = false;
		}
	}
}
