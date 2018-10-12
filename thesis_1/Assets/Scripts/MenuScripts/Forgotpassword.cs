using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Forgotpassword : MonoBehaviour {





	public InputField lrn;
	public InputField username;

	public GameObject loginPanel, changePanel, checkPanel;

	public Text errorfield;
	public Text errorfieldchange;
	public Text accountname;




	public GameObject canvasLoad;
	public Text lblLoader;
	public RectTransform main;
	public float timeStep;
	public float oneStepAngle;


	float startTime;





	void Update(){
		if (Time.time - startTime >= timeStep) {
			Vector3 angle = main.localEulerAngles;
			angle.z += oneStepAngle;

			main.localEulerAngles = angle;

			startTime = Time.time;
		}
	}


	public void checkLrn()
	{
		 

		if(lrn.text != "" && username.text != "")
		{

			StartCoroutine(check(lrn.text, username.text));

		}


		else{

			errorfield.text = "Empty field/s is not allowed";
		}


	}


	IEnumerator check(string lrn, string username)
	{

		string CheckingUrl="https://scivre.herokuapp.com/api/webapichecklrn";
		canvasLoad.SetActive (true);
		lblLoader.text = "Checking Credentials";

		errorfield.text = "";
		if (Validation1.checkConnectionfail() == true)
		{
			errorfield.text = "Error: Internet Connection";
			canvasLoad.SetActive (false);

		} 
		else 
		{	WWWForm form = new WWWForm ();

			form.AddField ("name", username);
			form.AddField ("student_id", lrn);

			using (UnityWebRequest www = UnityWebRequest.Post (CheckingUrl, form)) 
			{
				www.chunkedTransfer = false;
				//loading for accessing web kung existing ba accoutn    VALIDATING

				yield return www.SendWebRequest();

				if (www.error != null)
				{
					errorfield.text = "Error webserver request error: "+ www.error;
					canvasLoad.SetActive (false);

				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);
					Validation1.UserDetail userDetail = JsonUtility.FromJson<Validation1.UserDetail> (www.downloadHandler.text);
					Debug.Log (userDetail.status.ToString());


					//reponse details			
					if (userDetail.status == 1) 
					{    
						StartCoroutine (fetch (lrn));



					} 
					else
					{
						errorfield.text = "Account does not exist!";
						canvasLoad.SetActive (false);

					}
				}
			}
		}



	}



	IEnumerator fetch(string lrn)
	{

		string SetUrl = "https://scivre.herokuapp.com/api/webapifetchname";

		if(Validation1.checkConnectionfail() == true)
		{
			Debug.Log ("Error: Internet Connection");
			canvasLoad.SetActive (false);

		} 
		else 
		{
			WWWForm form = new WWWForm ();
			form.AddField ("id", lrn);

			using (UnityWebRequest www = UnityWebRequest.Post (SetUrl, form)) 
			{
				canvasLoad.SetActive (true);
				lblLoader.text = "Checking Credentials";
				www.chunkedTransfer = false;
				yield return www.SendWebRequest();

				if (www.error != null)
				{
					Debug.Log("Error webserver request error: "+ www.error);
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);
					Validation1.UserData userData= JsonUtility.FromJson<Validation1.UserData> (www.downloadHandler.text);
					//reponse detail

					accountname.text = "Account Name: " + userData.first_name + " " + userData.last_name;

					lblLoader.text = "Credentials Found!....";
					yield return new WaitForSeconds (3f);

					checkPanel.SetActive (false);
					loginPanel.SetActive (false);
					changePanel.SetActive (true);
					canvasLoad.SetActive (false);


				}
			}
		}
	}







	public InputField retype;
	public InputField password;





	public void Change()
	{


		if (retype.text != "" && password.text != "")
		{

			if (Validation1.CheckPasswordMatch (password.text, retype.text) == true) {

				StartCoroutine (Changepass (password.text, username.text));
			} else {

				errorfieldchange.text = "Password did not match";
			}

		}

		else 
		{

         	errorfieldchange.text = "All fields are required";
		}

	}


	IEnumerator  Changepass(string password, string name)
	{


		string ChangepassUrl="https://scivre.herokuapp.com/api/webapichangepass";

		canvasLoad.SetActive (true);
		lblLoader.text = "Sending Request to webserver";

		//	first if checking internet connection ang web serve response pare
		if (Validation1.checkConnectionfail() == true) 
		{

			errorfieldchange.text = "Error: Internet Connection";
			canvasLoad.SetActive(false);
		} 
		else 

		{
			//Checking web server response
			WWWForm form = new WWWForm ();
			Debug.Log (password);
			form.AddField ("password", password);
			form.AddField ("name", name);



			using (UnityWebRequest www = UnityWebRequest.Post (ChangepassUrl, form)) 
			{
				www.chunkedTransfer = false;
				yield return www.SendWebRequest();

				Debug.Log (www.error+" ");
				if (www.error != null)
				{
					errorfieldchange.text = "Error webserver request error: "+ www.error;
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);

					Validation1.UserDetail userDetail = JsonUtility.FromJson<Validation1.UserDetail> (www.downloadHandler.text);
					//reponse details			
					if (userDetail.status == 1) 
					{   
						
						lblLoader.text = "Password Successfully Updated";
						yield return new WaitForSeconds (3f);
						errorfieldchange.text = userDetail.message;
						canvasLoad.SetActive(false);
					  


					
						changePanel.SetActive (false);

						loginPanel.SetActive (true);







					} 
					else
					{
						errorfieldchange.text = www.downloadHandler.text;
						changePanel.SetActive (false);
					}



				}

			}


		}
	}	




}
