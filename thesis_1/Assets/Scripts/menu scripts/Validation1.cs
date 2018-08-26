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



}
