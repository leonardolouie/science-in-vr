using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class splashScript : MonoBehaviour {

	public Image splashImage;
	public TextMesh a;
	public string loadLevel;

	IEnumerator Start()
	{
		splashImage.canvasRenderer.SetAlpha (0.0f);

		FadeIn ();
		yield return new WaitForSeconds (2.5f);
		FadeOut ();
		yield return new WaitForSeconds (2.5f);
		if (MainMenu.load == null)
			SceneManager.LoadScene (loadLevel);
		else
			SceneManager.LoadScene (MainMenu.load);
	}
	void FadeIn()
	{
		splashImage.CrossFadeAlpha (1.0f, 1.5f, false);
	}
	void FadeOut()
	{
		splashImage.CrossFadeAlpha (0.0f, 2.5f, false);
	}
}
