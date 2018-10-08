using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;



	public void VolumeControl(float volumeControl) {
		AudioListener.volume = volumeControl; 
	}


	public void SetVolume(float volume)
	{
		audioMixer.SetFloat ("vfxVolume", volume);

	}

	public void SetQuality(int qualityindex)

	{

		QualitySettings.SetQualityLevel (qualityindex);
	}
}
