using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
public class splashScript : MonoBehaviour {
	public GameObject carousel;
	public Image splashImage;
	public Text a;
	public string loadLevel;
	public Toggle carouselToggle;

	IEnumerator Start()
	{
		splashImage.canvasRenderer.SetAlpha (0.0f);
		a.canvasRenderer.SetAlpha (0.0f);
		FadeIn ();
		yield return new WaitForSeconds (2.5f);
		gameObject.GetComponent<Animator> ().SetTrigger ("shine");
		yield return new WaitForSeconds (1f);
		FadeOut ();
		yield return new WaitForSeconds (2.5f);
		if ((PlayerPrefs.GetInt ("show", 0) == 0))
			carousel.SetActive (true);
		else
			loadScenes ();
	}
	void FadeIn()
	{
		a.CrossFadeAlpha (1.0f,1.5f,false);
		splashImage.CrossFadeAlpha (1.0f, 1.5f, false);
	}
	void FadeOut()
	{
		a.CrossFadeAlpha (0.0f,1.5f,false);
		splashImage.CrossFadeAlpha (0.0f, 2.5f, false);
	}

	public void loadScenes(){
		//animation goes here before loading the scenes
        //meaning the carousel has been loaded
		if(carouselToggle.isOn){
			PlayerPrefs.SetInt ("show", 1);
		}
	

        if (MainMenu.load == null)
        {
            SceneManager.LoadScene(loadLevel);
        }
        else
        {
            SceneManager.LoadScene(MainMenu.load);
        }
	}
}
