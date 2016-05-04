using UnityEngine;
using System.Collections;
using System;

public class MainMenuController : MonoBehaviour {

	//initialize various Canvases
	public GameObject createCanvas;
	public GameObject deleteCanvas;
	public GameObject cPassCanvas;
	public GameObject releaseCanvas;
	public GameObject audioCanvas;
	public GameObject backgroundCanvas;
	public GameObject historyCanvas;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (1200,900,false);
		//createCanvas.GetComponent<Canvas> ().enabled = false;
		//deleteCanvas.GetComponent<Canvas> ().enabled = false;
		//releaseCanvas.GetComponent<Canvas> ().enabled = false;
		//audioCanvas.GetComponent<Canvas> ().enabled = false;
		//backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		//historyCanvas.GetComponent<Canvas> ().enabled = false;

		//User temp = Manager.instance.users.Find (x => x.username == Manager.instance.userLoggedIn);
		//if (temp.status == 0) {
		//	Debug.Log ("Heyo");
		//	cPassBtn ();
		//} else {
		//	cPassCanvas.GetComponent<Canvas> ().enabled = false;
		//}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SSLaunchBtn()
	{
		Manager.instance.btnClick();
		Application.LoadLevel ("Menu");
	}

	public void AppleLaunchBtn()
	{
		Manager.instance.btnClick();
		Application.LoadLevel ("_Scene_0");
	}

	public void MemLaunchBtn()
	{
		Manager.instance.btnClick();
		Application.LoadLevel ("StartMenu");
	}

	public void RPSLaunchBtn()
	{
		Manager.instance.btnClick();
		Application.LoadLevel ("gameScene");
	}
		
	public void exitBtn()
	{
		Manager.instance.btnClick();
		Manager.instance.user.logs.Add (new Entry(DateTime.Now,Time.timeSinceLevelLoad)); //Record History
		Manager.instance.userLoggedIn = null;
		Manager.instance.user = null;
		Manager.instance.Save();
		Application.LoadLevel ("ProjectLoginScreen");
	}

	// Enable the selected Canvas, disable the rest
	public void createUserBtn()
	{
		Manager.instance.btnClick();
		createCanvas.GetComponent<Canvas> ().enabled = true;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void deleteUserBtn()
	{
		Manager.instance.btnClick();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = true;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void cPassBtn()
	{
		Manager.instance.btnClick();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = true;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void releaseBtn()
	{
		Manager.instance.btnClick();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = true;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void audioBtn()
	{
		Manager.instance.btnClick();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = true;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void backgroundBtn()
	{
		Manager.instance.btnClick();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = true;
		historyCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void historyBtn()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScript> ().printUsers ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historySSBtn()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScript> ().printUsersSS ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historyAppleBtn()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScript> ().printUsersApple ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historyMemBtn()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScript> ().printUsersMem ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historyRPSBtn()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScript> ().printUsersRPS ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historyBtnNonAdmin()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScriptNonAdmin> ().printUsers ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historySSBtnNonAdmin()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScriptNonAdmin> ().printUsersSS ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historyAppleBtnNonAdmin()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScriptNonAdmin> ().printUsersApple ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historyMemBtnNonAdmin()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScriptNonAdmin> ().printUsersMem ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void historyRPSBtnNonAdmin()
	{
		Manager.instance.btnClick();
		this.GetComponent<HistoryScriptNonAdmin> ().printUsersRPS ();
		createCanvas.GetComponent<Canvas> ().enabled = false;
		deleteCanvas.GetComponent<Canvas> ().enabled = false;
		cPassCanvas.GetComponent<Canvas> ().enabled = false;
		releaseCanvas.GetComponent<Canvas> ().enabled = false;
		audioCanvas.GetComponent<Canvas> ().enabled = false;
		backgroundCanvas.GetComponent<Canvas> ().enabled = false;
		historyCanvas.GetComponent<Canvas> ().enabled = true;
	}
}
