using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class studentdata : MonoBehaviour {


    public void FetchStudentData(string name)
	{
		

		StartCoroutine(fetch (name));

	}


	 IEnumerator fetch(string name)
	{
		
		string SetUrl = "localhost:81/superweb/webscivre/public/api/webscivreapifetch";

		if (Validation1.checkConnectionfail() == true)
		{

			Debug.Log ("Error: Internet Connection");


		} 
		else 
		{


			WWWForm form = new WWWForm ();
			form.AddField ("name", name);
		



			using (UnityWebRequest www = UnityWebRequest.Post (SetUrl, form)) 
			{

				yield return www.SendWebRequest();


				if (www.error != null)
				{
					Debug.Log("Error webserver request error: "+ www.error);
				}
				else
				{ 
					Debug.Log ("Response" + www.downloadHandler.text);

					Validation1.UserData userData= JsonUtility.FromJson<Validation1.UserData> (www.downloadHandler.text);
					//reponse details	
					PlayerPrefs.SetInt("id", userData.id);


				}

			}



		}
	}
}
