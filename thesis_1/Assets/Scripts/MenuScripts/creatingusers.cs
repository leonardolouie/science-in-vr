using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class creatingusers : MonoBehaviour {

		//site
		//string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapiregister";
	string CreateUserUrl = "https://scivre.herokuapp.com/api/webscivreapiregister";
	//string CreateUserUrl = "http://localhost/scivre/public/api/webscivreapiregister";

		public InputField txtstudent_id;
		public  InputField txtfname;
		public  InputField txtmname;
		public  InputField txtlname;
		public  InputField txtusername;
		public  InputField txtpassword;
		public  InputField txtretype;
		public  Text errorfield;
	 

		public GameObject canvasLoad;
		public Text lblLoader;


		public bool fetching = false;



		//public GameObject button, canvasLoad;
		

	void Start () {

	}

	// Update is called once per frame
	public void  Register(){

		if(txtstudent_id.text != "" && txtfname.text !="" && txtmname.text != "" && txtlname.text != "" && txtlname.text != "" && txtpassword.text !="" && txtretype.text != "" && txtusername.text != "")

		{ 



			if (Validation1.CheckPasswordMatch(txtpassword.text, txtretype.text) == true) {
				StartCoroutine (CreateUser (txtstudent_id.text, txtpassword.text, txtfname.text, txtmname.text, txtlname.text, txtusername.text));
			} else {
				errorfield.text = "Password did not match";
			}
		}

		else
		{

			errorfield.text = "All fields are required";
		}



	}


	IEnumerator  CreateUser(string student_id, string password, string fname, string mname, string lname, string username)
	{

		errorfield.text = "";

		canvasLoad.SetActive (true);
		lblLoader.text = "Creating account..... wait for response";
		fetching = true;

		//	first if checking internet connection ang web serve response pare
		if (Validation1.checkConnectionfail() == true) 
		{

			errorfield.text = "Error: Internet Connection";
		} 
		else 

		{
			//Checking web server response
			WWWForm form = new WWWForm ();


			form.AddField ("student_id", student_id);
			form.AddField ("password", password);
			form.AddField ("fname", fname);
			form.AddField ("mname", mname);
			form.AddField ("lname", lname);
			form.AddField ("name", username);



			using (UnityWebRequest www = UnityWebRequest.Post (CreateUserUrl, form)) 
			{
				www.chunkedTransfer = false;
				yield return www.SendWebRequest();

				Debug.Log (www.error+" ");
				if (www.error != null)
				{
					errorfield.text = "Error webserver request error: "+ www.error;
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);

					Validation1.UserDetail userDetail = JsonUtility.FromJson<Validation1.UserDetail> (www.downloadHandler.text);
					//reponse details			
					if (userDetail.status == 1) 
					{
						errorfield.text = userDetail.message;
					txtstudent_id.text = "";
					txtfname.text = "";
					txtmname.text = "";
					txtlname.text = ""; 
					txtlname.text = "";
					txtpassword.text = "";
					txtretype.text = ""; 
					txtusername.text = "";

					     
					       
					} 
					else
					{
						errorfield.text = www.downloadHandler.text;
					}



				}

			}


		}
	}	
}