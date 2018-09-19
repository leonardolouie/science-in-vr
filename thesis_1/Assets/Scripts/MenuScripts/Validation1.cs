using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation1 : MonoBehaviour {

	public static bool checkConnectionfail()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable)
			return true;
		else 
			return false;
	}
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
		//
	}
	[System.Serializable]
	public class UserData
	{
		//ang variable na ito ay dapat katulad sa Json na nireponse
		public  int student_id;
		public  string first_name = "";
		public  string middle_name = "";
		public  string last_name = "";
		public string name="";
	}

}
