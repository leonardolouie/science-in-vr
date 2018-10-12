using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PanelAnim : MonoBehaviour {


	public GameObject start;
	public Image spr;
	int index = 0;
	public string[] infos;
	public Text textInfo;
	public RectTransform[] locationsAnim;
	public Animator tutorialAnimator;

	public List<GameObject> pages = new List<GameObject>();
	int currentPanelIndex = 0;
	public GameObject currentPanel;
	public CanvasGroup canvasGroup;

	public bool fadeOut = false;
	public bool fadeIn = false;
	public float fadeFactor = 8f;



	void Start(){
		if (PlayerPrefs.GetInt ("tutorial", 0) == 0) {
			tutorialAnim ();
			PlayerPrefs.SetInt ("tutorial", 1);
		}
		else 
			start.transform.parent.gameObject.SetActive (false);
		
	}
	void Update ()
	{
			
			if (fadeOut) {
				canvasGroup.alpha -= fadeFactor * Time.deltaTime;
			}
			if (fadeIn) {
				canvasGroup.alpha += fadeFactor * Time.deltaTime;
			}
	}

	public void tutorialAnim(){
		if (index < 4) {
			StartCoroutine (changePos ());
		} else {
			start.SetActive (true);
			spr.transform.parent.gameObject.SetActive (false);
		}
	}

	IEnumerator changePos(){


		spr.CrossFadeAlpha (0f, .5f,false);
		spr.CrossFadeAlpha (1f, .5f,false);
		tutorialAnimator.SetTrigger ("tap");
		yield return new WaitForSeconds (tutorialAnimator.GetCurrentAnimatorStateInfo (0).length - .15f);
		spr.gameObject.transform.parent.GetComponent<RectTransform> ().anchoredPosition = locationsAnim [index].anchoredPosition;
		textInfo.text = infos [index];
		if (index < 4) {
			newPanel (index);
			index++;
		}
	}




	public void newPanel(int newPage)
	{
		
		if (newPage != currentPanelIndex)
			StartCoroutine (ChangePage(newPage));
	}


	public IEnumerator ChangePage (int newPage)
	{
		canvasGroup = currentPanel.GetComponent<CanvasGroup>();
		canvasGroup.alpha = 1f;
		fadeIn = false;
		fadeOut = true;

		while(canvasGroup.alpha > 0)
		{
			yield return 0;
		}
		currentPanel.SetActive(false);

		fadeIn = true;
		fadeOut = false;
		currentPanelIndex = newPage;
		currentPanel = pages [currentPanelIndex];
		currentPanel.SetActive (true);
		canvasGroup = currentPanel.GetComponent<CanvasGroup>();
		canvasGroup.alpha = 0f;

		while (canvasGroup.alpha <1f)
		{
			yield return 0;
		}

		canvasGroup.alpha = 1f;
		fadeIn = false;

		yield return 0;
	}
}
