using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moviePlayer : MonoBehaviour {
	public MovieTexture m;
	// Use this for initialization
	void Start () {
		GetComponent<RawImage> ().texture = m as MovieTexture;
		m.Play ();
	}
}
