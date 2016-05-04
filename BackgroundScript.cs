using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour {

	public Dropdown backgroundImg;
	public Canvas bgCanvas;
	public GameObject backgroundObject;

	// Use this for initialization
	void Start () {
		backgroundObject.GetComponent<Image> ().sprite = Manager.instance.backgroundImg; //get the image from Manager and set the bgimg
		bgCanvas.enabled = false;
		backgroundImg.onValueChanged.AddListener (delegate{backgroundChange();});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void backgroundChange()
	{
		//Based on what is Selected change the background
		if (backgroundImg.value == 0) {
			Manager.instance.backgroundImg = Manager.instance.backImages [0];
		}
		else if(backgroundImg.value == 1){
			Manager.instance.backgroundImg = Manager.instance.backImages [1];	
		}
		else if(backgroundImg.value == 2){
			Manager.instance.backgroundImg = Manager.instance.backImages [2];
		}

		backgroundObject.GetComponent<Image> ().sprite = Manager.instance.backgroundImg;

	}

	public void closeBtn()
	{
		Manager.instance.btnClick();
		bgCanvas.enabled = false;
	}
}
