using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class login : MonoBehaviour {

	string CreateUserUrl="https://scivre.000webhostapp.com/login.php";
	public string email, password;
	void Start () {

	}
	//qweqweqweqweqwe

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L))
			StartCoroutine (LoginDB (email, password));

	}

	IEnumerator LoginDB(string email, string password)

	{
		WWWForm form = new WWWForm ();



		form.AddField ("email", email);
		form.AddField ("password", password);
	
		WWW www = new WWW(CreateUserUrl,form);
		Debug.Log ("wait");

		yield return www;

		Debug.Log (www.text);


	}

}
