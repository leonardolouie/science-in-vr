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
	public GameObject loadingScreen;
	public Slider slider;
	public Text progresskoto;



	private void Awake(){
		Application.targetFrameRate = 60;
	}


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
			if (PlayerPrefs.GetInt ("isLogged", 0) == 0) {
				carousel.SetActive (true);
			} else
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
        if (MainMenu.load == null)
        {
            SceneManager.LoadScene(loadLevel);
        }
        else
        {  
			//if quiz is selected
			if (PlayerPrefs.GetInt("isQuiz") == 1) {


				StartCoroutine (LoadAsynchronously (MainMenu.load));
				//SceneManager.LoadScene (MainMenu.load);

			} else {
				StartCoroutine (LoadAsynchronously (MainMenu.load));
				//SceneManager.LoadScene (MainMenu.load);

			}


		
		}



	}



	IEnumerator LoadAsynchronously(string SceneName)
	{

		AsyncOperation operation = SceneManager.LoadSceneAsync (SceneName);

		loadingScreen.SetActive (true);
		while (!operation.isDone) {

			float progress = Mathf.Clamp01 (operation.progress / .9f);
			Debug.Log (progress);
			slider.value = progress;
			progresskoto.text = progress * 100f + "%";

			yield return null;
		}

	}



}
