﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public static string load;
	public void SolarSystem(){
		SceneManager.LoadScene ("Splash");
		load = "SolarSystem";
	}
	public void Home(){
		SceneManager.LoadScene("Splash");
		load = "MainForm";
	}
}