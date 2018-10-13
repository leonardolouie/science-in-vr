using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SpeechLib;
using System.Xml;
using System.IO;


public class TTSscript : MonoBehaviour {

	// Use this for initialization

	private SpVoice voice;


	public void speak()
	{

		voice = new SpVoice();

		voice.Rate = -2;
		Debug.Log (anatomyDialogue.textToBeSpeech);

		if (anatomyDialogue.textToBeSpeech != null) {
			voice.Speak (anatomyDialogue.textToBeSpeech, SpeechVoiceSpeakFlags.SVSFlagsAsync);
		} else {

			voice.Pause ();
		}


	}




	/// CODE FOR LOAD XML OR OTHER TEXT FILES IN THE SISTEM FROM THE FOLDER RESOURCE

	string loadXMLStandalone (string fileName) {

		string path  = Path.Combine("Resources", fileName);
		path = Path.Combine (Application.dataPath, path);
		Debug.Log ("Path:  " + path);
		StreamReader streamReader = new StreamReader (path);
		string streamString = streamReader.ReadToEnd();
		Debug.Log ("STREAM XML STRING: " + streamString);
		return streamString;
	}

}
