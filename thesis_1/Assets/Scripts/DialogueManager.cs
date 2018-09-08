using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	// Use this for initialization
	public float delay = .2f;
	public Text nameText;
	public Text dialogueText;
	public static bool flag = true;
	public void StartDialogue(Dialogue dialogue)
	{
		nameText.text = dialogue.name;
		string sentence = dialogue.sentences;
		StopAllCoroutines ();
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
}