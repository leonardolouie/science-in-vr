using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Sectionadd : MonoBehaviour {

	public  InputField txtcode;
	public  Text errorfield;







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





	public void SectionAdd()
	{
		string username = PlayerPrefs.GetString ("name");
		Debug.Log (username);

		if (txtcode.text != "")
		{


			StartCoroutine (Changepass (txtcode.text, username));


		}

		else 
		{

			errorfield.text = "All fields are required";
		}

	}


	IEnumerator  Changepass(string section_code, string username)
	{


		string SectionCodeUrl="https://scivre.herokuapp.com/api/webscivreapisectioncode";

		canvasLoad.SetActive (true);
		lblLoader.text = "Sending Request to webserver";

		//	first if checking internet connection ang web serve response pare
		if (Validation1.checkConnectionfail() == true) 
		{

			errorfield.text = "Error: Internet Connection";
			canvasLoad.SetActive(false);
		} 
		else 

		{
			//Checking web server response
			WWWForm form = new WWWForm ();

			form.AddField ("section_code", section_code);
			form.AddField ("name", username );



			using (UnityWebRequest www = UnityWebRequest.Post (SectionCodeUrl, form)) 
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
						lblLoader.text = userDetail.message;
						yield return new WaitForSeconds (2f); 
						canvasLoad.SetActive(false);

						txtcode.text = "";





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
