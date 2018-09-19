using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class login : MonoBehaviour {

	//string CreateUserUrl="localhost:81/superweb/webscivre/public/api/webscivreapilogin";
	string LoginUrl="https://scivre.herokuapp.com/api/webscivreapilogin";
	public InputField name;
	public InputField password;
	public Text id;
	public Text errorfield;
	public GameObject loginPanel, registerPanel,mainMenuPanel;
	public Text Hello;
	public Text fullname;
	public Text student_id;
	public Text user;




	public GameObject canvasLoad;
	public Text lblLoader;
	public RectTransform main;
	public float timeStep;
	public float oneStepAngle;

	public bool fetching = false;
	float startTime;





	void Update(){
		if (Time.time - startTime >= timeStep && fetching) {
			Vector3 angle = main.localEulerAngles;
			angle.z += oneStepAngle;

			main.localEulerAngles = angle;

			startTime = Time.time;
		}
	}




	IEnumerator loadFetch(){


		loginPanel.SetActive (false);
		registerPanel.SetActive (false);
		canvasLoad.SetActive (true);
		lblLoader.text = "LOADING DATA...";
		fetching = true;
		yield return new WaitForSeconds (5f);
		canvasLoad.SetActive (false);
		fetching = false;
		mainMenuPanel.SetActive (true);
		Hello.text = "WELCOME BACK "+PlayerPrefs.GetString ("first_name");
		fullname.text = PlayerPrefs.GetString ("first_name")+" "+PlayerPrefs.GetString ("middle_name")+" "+PlayerPrefs.GetString ("last_name");
		student_id.text = PlayerPrefs.GetString ("id")+" ";
		user.text = PlayerPrefs.GetString ("name")+" ";
	}



	void Start(){
		if (PlayerPrefs.GetInt ("isLogged") == 1) {
			StartCoroutine (loadFetch ());
			// dito ilalagay ung syncing ng data kung naka save, at nakapag Login na thru internet
		}
	}


	public void Login()
	{
		if (name.text != "" && password.text != "") {
			StartCoroutine (LoginDB (name.text, password.text));
		} 
		else 
 		{

				errorfield.text = "All fields are required";
		}
	}
	IEnumerator LoginDB(string username, string passwordkoto)
	{
		canvasLoad.SetActive (true);
		lblLoader.text = "LOGGING IN...";
		fetching = true;

		errorfield.text = "";
		if (Validation1.checkConnectionfail() == true)
		{
			errorfield.text = "Error: Internet Connection";
			canvasLoad.SetActive (false);
			fetching = false;
		} 
		else 
		{
			WWWForm form = new WWWForm ();
			//Debug.Log ("the username is" r username + password);
			form.AddField ("name", username);
			form.AddField ("password", passwordkoto);
			
			using (UnityWebRequest www = UnityWebRequest.Post (LoginUrl, form)) 
			{
				www.chunkedTransfer = false;
				//loading for accessing web kung existing ba accoutn    VALIDATING
				yield return www.SendWebRequest();

				if (www.error != null)
				{
					errorfield.text = "Error webserver request error: "+ www.error;
					canvasLoad.SetActive (false);
					fetching = false;
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);
					Validation1.UserDetail userDetail = JsonUtility.FromJson<Validation1.UserDetail> (www.downloadHandler.text);
					Debug.Log (userDetail.status.ToString());


					//reponse details			
					if (userDetail.status == 1) 
					{
						errorfield.text = userDetail.message;
						loginPanel.SetActive (false);
						registerPanel.SetActive (false);
						mainMenuPanel.SetActive (true);
						StartCoroutine (fetch (username));


						// animate loading for fetching 
						lblLoader.text = "SYNCING DATA...";
						yield return fetch (username);
						//retrieving data from account info
						Hello.text = "WELCOME " + PlayerPrefs.GetString ("first_name");
						fullname.text = PlayerPrefs.GetString ("first_name")+" "+PlayerPrefs.GetString ("middle_name")+" "+PlayerPrefs.GetString ("last_name");
						student_id.text = PlayerPrefs.GetString ("id")+" ";
						user.text = PlayerPrefs.GetString ("name")+" ";
						canvasLoad.SetActive (false);
						fetching = false;

					} 
					else
					{
						errorfield.text = userDetail.message;
						canvasLoad.SetActive (false);
						fetching = false;
					}
				}
			}
		}
	}


	IEnumerator fetch(string uname)
	{

		string SetUrl = "https://scivre.herokuapp.com/api/webscivreapifetch";

		if(Validation1.checkConnectionfail() == true)
		{
			Debug.Log ("Error: Internet Connection");
			canvasLoad.SetActive (false);
			fetching = false;
		} 
		else 
		{
			WWWForm form = new WWWForm ();
			form.AddField ("name", uname);

			using (UnityWebRequest www = UnityWebRequest.Post (SetUrl, form)) 
			{
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
					PlayerPrefs.SetString ("id", userData.student_id.ToString("(12,0)"));
					PlayerPrefs.SetString ("first_name", userData.first_name);
					PlayerPrefs.SetString ("middle_name", userData.middle_name);
					PlayerPrefs.SetString ("last_name", userData.last_name);
					PlayerPrefs.SetString ("name", userData.name);
					PlayerPrefs.SetInt ("isLogged", 1);

				}
			}
		}
	}
}