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
						lblLoader.text = "Credentials Found!....";
						yield return new WaitForSeconds (2f);

						checkPanel.SetActive (false);
						changePanel.SetActive (true);


					
						canvasLoad.SetActive (false);


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


}
