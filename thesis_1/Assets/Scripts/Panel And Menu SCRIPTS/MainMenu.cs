using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public static string load;
	public void SolarSystem(){
		SceneManager.LoadScene ("Splash");
		PlayerPrefs.SetInt ("isVrOn",0);
		load = "SolarSystem";
	}

	public void Home(){
		SceneManager.LoadScene("Splash");
		load = "SCIVREUI";
	}
	//showAgain the carousel

	public void logOut(){
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Splash");
		load = "SCIVREUI";
	}

	public void Quiz(int a){
		PlayerPrefs.SetInt ("quizNo", a);
		SceneManager.LoadScene ("Splash");
		load = "Quiz";

	}
	public void backFromQuiz(){
		SceneManager.LoadScene (1);
	}

	public void humanAnatomy(int systemNo){
		PlayerPrefs.SetInt ("whatSystem", systemNo);
		SceneManager.LoadScene ("Splash");
		PlayerPrefs.SetInt ("isVrOn",0);
		load = "HumanAnatomy";
	}
}
