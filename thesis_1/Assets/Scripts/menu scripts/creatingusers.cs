using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatingusers : MonoBehaviour {

	// Use this for initialization


	string CreateUserUrl="https://scivre.000webhostapp.com/inserdata.php";
	public string student_id, fname, mname,lname,email,password;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
			CreateUser (student_id, email, password, fname, mname, lname);

	}

	public void CreateUser(string student_id, string email, string password, string fname, string mname, string lname)

	{
		WWWForm form = new WWWForm ();


		form.AddField ("student_id", student_id);
		form.AddField ("email", email);
		form.AddField ("password", password);
		form.AddField ("fname", fname);
		form.AddField ("mname", mname);
		form.AddField ("lname", lname);

		WWW www = new WWW(CreateUserUrl,form);



	}


}
