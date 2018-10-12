using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class TextTospeech : MonoBehaviour {

	public string words = "Hello qweqeqeqeqeqeqqweqeqeqe";
	public AudioSource audio;

	IEnumerator Start ()
	{

		audio = gameObject.GetComponent<AudioSource> ();
		// Remove the "spaces" in excess
		Regex rgx = new Regex ("\\s+");
		// Replace the "spaces" with "% 20" for the link Can be interpreted
		string result = rgx.Replace (words, "%20");
		string url = "http://translate.google.com/translate_tts?tl=en&q=" + result;
		WWW www = new WWW (url);
		yield return www;
		audio.clip = www.GetAudioClip (false, false, AudioType.MPEG);
		audio.Play ();
	}

	void start()

	{

		     
			StartCoroutine (Start ());

	}

}
