using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	// Use this for initialization
	public Image label;
	float delay = .05f;
	public Text nameText,labelName;
	public Text dialogueText;
	public static bool flag = true;
	public void StartDialogue(Dialogue dialogue)
	{
		nameText.text = dialogue.name;
		string sentence = dialogue.sentences;
		StopAllCoroutines ();
		labelAnim ();
		StartCoroutine (TypeSentence (sentence));
		EndDialouge ();
		return;
	}
	IEnumerator TypeSentence(string sentence)
	{ 
		flag = false;
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return new WaitForSeconds (delay);
		}
		flag = true;

	}
	void EndDialouge()
	{
		Debug.Log ("END");
	}
	void labelAnim(){
		labelName.text = "";
		labelName.canvasRenderer.SetAlpha (1f);
		label.canvasRenderer.SetAlpha (1f);
		label.fillAmount = 0f;
		StartCoroutine (lblAnim ());
	}

	IEnumerator lblAnim(){
		while (label.fillAmount != 1) {
			label.fillAmount += .08f;
			yield return null;
		}
		yield return new WaitForSeconds (0.7f);
		StartCoroutine (typeName(nameText.text));
		yield return new WaitForSeconds (3f);
		label.CrossFadeAlpha (0f, 1.5f, false);
		labelName.CrossFadeAlpha (0f, 1.5f, false);
	}

	IEnumerator typeName(string sentence)
	{ 
		
		foreach (char letter in sentence.ToCharArray()) {
			labelName.text += letter;
			yield return new WaitForSeconds (.15f);
		}

	}
}