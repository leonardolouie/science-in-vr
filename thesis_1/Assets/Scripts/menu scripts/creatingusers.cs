using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class creatingusers : MonoBehaviour {
	
	//site
<<<<<<< HEAD
	public Animator anim;
	public GameObject loadPanel,logSuccessPanel,logInPanel,registerPanel;
	string CreateUserUrl="http://192.168.0.31:81/superweb/webscivre/public/api/webscivreapiregister";
=======
	string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapiregister";


>>>>>>> e7a5340293d5c932f02fefa06fdaf264de8a3acf
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
<<<<<<< HEAD
			errorfield.text = "*All fields are required";
=======
		{

			errorfield.text = "All fields are required";
		}



>>>>>>> e7a5340293d5c932f02fefa06fdaf264de8a3acf
	}
		

	IEnumerator  CreateUser(string student_id, string password, string fname, string mname, string lname, string username)
	{

		errorfield.text = "";




<<<<<<< HEAD
		//loading screen goes here
		loadPanel.SetActive(true);
		yield return www;
		//	first if checking internet connection ang web serve response pare
		if (checkConnectionfail()) {
			errorfield.text = "*Error: Failed to connect to the internet";
=======
		//	first if checking internet connection ang web serve response pare
		if (Validation1.checkConnectionfail() == true) 
		{
			
			errorfield.text = "Error: Internet Connection";
>>>>>>> e7a5340293d5c932f02fefa06fdaf264de8a3acf
		} 
		else 
		
		{
			//Checking web server response
<<<<<<< HEAD
			if (www.error == null) {
				if (www.text == "Successfully Registered") 
				{
					//go back to login panel
					registerPanel.SetActive (false);
					logSuccessPanel.SetActive (true);
					logInPanel.SetActive (true);
					anim.SetTrigger ("regSucc");


				} else
					errorfield.text = www.text;
			} 
			else 
				errorfield.text = "Cannot connect to web server"/*www.error*/;
		}
		loadPanel.SetActive (false);
=======
			WWWForm form = new WWWForm ();


			form.AddField ("id", student_id);
			form.AddField ("password", password);
			form.AddField ("fname", fname);
			form.AddField ("mname", mname);
			form.AddField ("lname", lname);
			form.AddField ("name", username);

			//WWW www = new WWW(CreateUserUrl,form);

				using (UnityWebRequest www = UnityWebRequest.Post (CreateUserUrl, form)) 
				    {

							yield return www.SendWebRequest();


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
												
								} 
								else
								{
									errorfield.text = www.downloadHandler.text;
								}
						
						
				
							}
		
					}
		

			}
>>>>>>> e7a5340293d5c932f02fefa06fdaf264de8a3acf
	}
}		
	