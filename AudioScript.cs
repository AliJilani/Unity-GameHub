using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour {

	public Slider volumeSlider;
	public Dropdown musicSelect;
	public AudioSource audio;
	public AudioClip[] songs = new AudioClip[3];
	public Canvas audioCanvas;

	// Use this for initialization
	void Start () {
		audio.Play ();
		audioCanvas.enabled = false;
		volumeSlider.value = audio.volume; // set slider to where the volume is
		//add actionlisteners to detect changes
		volumeSlider.onValueChanged.AddListener (delegate{backgroundSliderCalled();});
		musicSelect.onValueChanged.AddListener (delegate{backgroundSongChange();});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void backgroundSliderCalled()
	{
		audio.volume = volumeSlider.value; //change the actual volume with the slider
	}

	public void backgroundSongChange()
	{
		//Based on what is selected in the Dropdown, change the song
		if (musicSelect.value == 0) {
			audio.clip = songs[0];
		}
		else if(musicSelect.value == 1){
			audio.clip = songs[1];
		}
		else if(musicSelect.value == 2){
			audio.clip = songs[2];
		}
		audio.Play ();

	}

	public void closeBtn()
	{
		Manager.instance.btnClick();
		audioCanvas.enabled = false;
	}
}
