using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class creatingusers : MonoBehaviour {
	
	//site
	string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapiregister";


	public InputField txtstudent_id;
	public  InputField txtfname;
	public  InputField txtmname;
	public  InputField txtlname;
	public  InputField txtusername;
	public  InputField txtpassword;
	public  Text errorfield;








	void Start () {
		
	}
	
	// Update is called once per frame
	public void  Register(){

		if(txtstudent_id.text != "" && txtfname.text !="" && txtmname.text != "" && txtlname.text != "" && txtlname.text != "" && txtpassword.text !="" )

		{
			StartCoroutine(CreateUser (txtstudent_id.text, txtpassword.text, txtfname.text, txtmname.text, txtlname.text, txtusername.text));

		}

		else
		{

			errorfield.text = "All fields are required";
		}



	}
		

	IEnumerator  CreateUser(string student_id, string password, string fname, string mname, string lname, string username)
	{

		errorfield.text = "";




		//	first if checking internet connection ang web serve response pare
		if (Validation1.checkConnectionfail() == true) 
		{
			
			errorfield.text = "Error: Internet Connection";
		} 
		else 
		
		{
			//Checking web server response
			WWWForm form = new WWWForm ();


			form.AddField ("id", student_id);
			form.AddField ("password", password);
			form.AddField ("fname", fname);
			form.AddField ("mname", mname);
			form.AddField ("lname", lname);
			form.AddField ("name", username);

			//WWW www = new WWW(CreateUserUrl,form);

			WWW www = new WWW(CreateUserUrl, form);


			yield return www;
			Debug.Log (www.text);





			if (www.error == null) {
				if (www.text == "Successfully Registered") 
				{
					errorfield.text = "Sucessfully registered new account";
				} else {

					errorfield.text = www.text;


				}
			} 



			else 
			{
				errorfield.text = "Cannot connect to web server" + www.error;
				
			}
		
		
		}
		

	}

	   
	
	
	
	
	}















