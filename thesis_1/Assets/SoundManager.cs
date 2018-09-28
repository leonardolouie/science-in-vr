using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


	public static AudioClip correctAnswer, wrongAnswer;
	static AudioSource audiosrc;
	// Use this for initialization
	void Start ()
	{
		correctAnswer = Resources.Load<AudioClip> ("correctAnswer");
		wrongAnswer = Resources.Load<AudioClip> ("wrongAnswer");

		audiosrc = GetComponent<AudioSource> ();

	}


	public static void Playsound(string clip)
	{
		switch (clip) {

		case "correctAnswer":
			audiosrc.PlayOneShot (correctAnswer);
			break;

		case "wrongAnswer":
			audiosrc.PlayOneShot (wrongAnswer);
			break;

		}
	}
	

}