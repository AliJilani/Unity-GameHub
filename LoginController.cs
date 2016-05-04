using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginController : MonoBehaviour {

	public InputField username;
	public InputField password;
	public Text usernameError;
	public Text passwordError;
	public Text blockedError;
	public string usernameInput;
	public string passwordInput;
	public int passwordTrials = 0;
	//string blockedUser;
	//public User user;


	// Use this for initialization
	void Start () {
		Screen.SetResolution (1200,900,false);
		username.characterValidation = InputField.CharacterValidation.Alphanumeric;
		password.characterValidation = InputField.CharacterValidation.Alphanumeric;
		username.characterLimit = 10;
		password.characterLimit = 24;
		usernameError.enabled = false;
		passwordError.enabled = false;
		blockedError.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void usernameEntered()
	{
		//MainScript.instance.clickSound ();
		usernameInput = username.GetComponent<InputField> ().text;
	}
	public void passwordEntered()
	{
		//MainScript.instance.clickSound ();
		passwordInput = password.GetComponent<InputField> ().text;

	}
	public void loginBtn()
	{
		Manager.instance.btnClick();
		User check = new User ();
		check.username = usernameInput;
		if (Manager.instance.users.Contains (check)) { //Is the User in the List?
			User temp = Manager.instance.users.Find (x => x.username == usernameInput);
			if (passwordTrials == 3 && usernameInput != "admin") { //Blocked for 3 failed trials
				temp.status = 2;
				passwordTrials = 0;
				Manager.instance.Save();
			}
			if (temp.status == 2)
			{
				blockedError.enabled = true;
				usernameError.enabled = false;
				passwordError.enabled = false;
			}
			else if (temp.checkPassword (passwordInput)) {
				Manager.instance.user = temp;
				if (usernameInput == "admin") {
					Manager.instance.userLoggedIn = usernameInput;
					Application.LoadLevel ("MainMenu");
				} else {
					Manager.instance.userLoggedIn = usernameInput;
					Application.LoadLevel ("MainMenuNonAdmin");
				}
			} else {
				usernameError.enabled = false;
				passwordError.enabled = true;
				blockedError.enabled = false;
				passwordTrials++;
			}
			
		} else {
			usernameError.enabled = true;
			passwordError.enabled = false;
			blockedError.enabled = false;
			passwordTrials = 0;
		}
	}

	public void exitBtn()
	{
		Manager.instance.btnClick();
		Debug.Break ();
		Application.Quit ();
	}
}
