using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class creatingusers : MonoBehaviour {


	string CreateUserUrl = "https://scivre.herokuapp.com/api/webscivreapiregister";


		public InputField txtstudent_id;
		public  InputField txtfname;
		public  InputField txtmname;
		public  InputField txtlname;
		public  InputField txtusername;
		public  InputField txtpassword;
		public  InputField txtretype;
		public  Text errorfield;


		public GameObject loginPanel, registerPanel,mainMenuPanel;
		public Text Hello;
		public Text fullname;
		//public Text student_id;
		public Text user;

	 

		public GameObject canvasLoad;
		public Text lblLoader;
		public RectTransform main;
		public float timeStep;
		public float oneStepAngle;

		
		float startTime;






		//public GameObject button, canvasLoad;


	void Update(){
		if (Time.time - startTime >= timeStep) {
			Vector3 angle = main.localEulerAngles;
			angle.z += oneStepAngle;

			main.localEulerAngles = angle;

			startTime = Time.time;
		}
	}
		

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


		//	first if checking internet connection ang web serve response pare
		if (Validation1.checkConnectionfail() == true) 
		{

			errorfield.text = "Error: Internet Connection";
			canvasLoad.SetActive (false);
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
					canvasLoad.SetActive (false);
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);

					Validation1.UserDetail userDetail = JsonUtility.FromJson<Validation1.UserDetail> (www.downloadHandler.text);
					//reponse details			
					if (userDetail.status == 1) 
					{
					canvasLoad.SetActive (false);
					errorfield.text = userDetail.message;
					StartCoroutine (loadaftercreate ());

					

					     
					       
					} 
					else
					{
						errorfield.text = www.downloadHandler.text;
						canvasLoad.SetActive (false);
					}



				}

			}


		}
	}




	IEnumerator loadaftercreate()
	{




		loginPanel.SetActive (false);
		registerPanel.SetActive (false);
		canvasLoad.SetActive (true);
		lblLoader.text = "SUCCESSULLY CREATED USER, LOADING DATA...";
		yield return new WaitForSeconds (5f);
		canvasLoad.SetActive (false);
		mainMenuPanel.SetActive (true);

		Hello.text = "WELCOME " + txtfname.text;
		fullname.text = txtfname.text + " " + txtmname.text + " " + txtlname.text;
		//student_id.text = txtstudent_id.text;
		user.text = txtusername.text;



		PlayerPrefs.SetString ("id", txtstudent_id.text);
		PlayerPrefs.SetString ("first_name",txtfname.text);
		PlayerPrefs.SetString ("middle_name", txtmname.text);
		PlayerPrefs.SetString ("last_name", txtlname.text);
		PlayerPrefs.SetString ("name", txtusername.text);
		PlayerPrefs.SetInt ("isLogged", 1);

		Debug.Log (PlayerPrefs.GetInt ("isLogged").ToString () +"qweqeqeqqe");



	}

}