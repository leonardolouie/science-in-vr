using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class splashScript : MonoBehaviour {
	public GameObject carousel;
	public Image splashImage;
	public string loadLevel;
	IEnumerator Start()
	{
		splashImage.canvasRenderer.SetAlpha (0.0f);

		FadeIn ();
		yield return new WaitForSeconds (2.5f);
		FadeOut ();
		yield return new WaitForSeconds (2.5f);
		carousel.SetActive (true);
	}
	void FadeIn()
	{
		splashImage.CrossFadeAlpha (1.0f, 1.5f, false);
	}
	void FadeOut()
	{
		splashImage.CrossFadeAlpha (0.0f, 2.5f, false);
	}
	public void loadScenes(){
		//animation goes here before loading the scenes
		if (MainMenu.load == null)
			SceneManager.LoadScene (loadLevel);
		else
			SceneManager.LoadScene (MainMenu.load);
	}
}
