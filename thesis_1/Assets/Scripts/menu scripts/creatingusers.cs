using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class creatingusers : MonoBehaviour {

	//site
	string CreateUserUrl="http://localhost:81/superweb/webscivre/public/api/register";


	public InputField txtstudent_id;
	public  InputField txtfname;
	public  InputField txtmname;
	public  InputField txtlname;
	public  InputField txtusername;
	public  InputField txtpassword;



	//public string student_id, fname, mname,lname,username,password;

	void Start () {
		
	}
	
	// Update is called once per frame
	public void  Register(){

		StartCoroutine(CreateUser (txtstudent_id.text, txtpassword.text, txtfname.text, txtmname.text, txtlname.text, txtusername.text));

	}
		

	IEnumerator  CreateUser(string student_id, string password, string fname, string mname, string lname, string username)
	{

		WWWForm form = new WWWForm ();


		form.AddField ("id", student_id);
		form.AddField ("password", password);
		form.AddField ("fname", fname);
		form.AddField ("mname", mname);
		form.AddField ("lname", lname);
		form.AddField ("name", username);

		//WWW www = new WWW(CreateUserUrl,form);
		WWW www = new WWW ("http://localhost:81/superweb/webscivre/public/api/register", form);
		yield return www;



		Debug.Log (www.text);

	}




}
