using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation1 : MonoBehaviour {

	public static bool checkConnectionfail()
	{

		if (Application.internetReachability == NetworkReachability.NotReachable) {
			return true;
		} 
		else 
		{
			return false;
		}


	}

	//Getting Data


	[System.Serializable]

	public class UserDetail
	{
		//ang variable na ito ay dapat katulad sa Json na nireponse
		public string message="";
		public int status;
		Data data;

	}

	[System.Serializable]

	public class Data
	{



	}




}
