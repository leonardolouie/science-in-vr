using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class changepass : MonoBehaviour {


	string ChangepassUrl="";
	public InputField retype;
	public InputField password;

	public Text errorfield;



	public void Change()
	{


		if (retype.text != "" && password.text != "")
		{

			if (Validation1.CheckPasswordMatch (password.text, retype.text) == true) {

				StartCoroutine (Changepass (password.text));
			} else {

				errorfield.text = "Password did not match";
			}

		}

		else 
		{

			errorfield.text = "All fields are required";
		}

	}


	IEnumerator  Changepass(string password)
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


		form.AddField ("password", password);
	     




		using (UnityWebRequest www = UnityWebRequest.Post (ChangepassUrl, form)) 
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
