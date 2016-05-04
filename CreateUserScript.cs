using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateUserScript : MonoBehaviour {

	public Canvas cuCanvas;
	public InputField username;
	public string usernameInput;
	public Text error;

	// Use this for initialization
	void Start () {
		username.characterLimit = 10;
		username.characterValidation = InputField.CharacterValidation.Alphanumeric; // ensure only letters and numbers
		cuCanvas.enabled = false;
		error.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void usernameEntered()
	{
		usernameInput = username.GetComponent<InputField> ().text;
	}

	public void cancelBtn()
	{
		Manager.instance.btnClick();
		cuCanvas.enabled = false;
	}

	public void submitBtn()
	{
		Manager.instance.btnClick();
		Debug.Log (usernameInput);
		if (username) 
		{
			User newUser = new User ();
			newUser.username = usernameInput;
			newUser.changePassword (usernameInput); //set password as username
			newUser.status = 0;
			if (!Manager.instance.users.Contains (newUser)) { // check to see if user exists
				Manager.instance.users.Add (newUser); //add to list 'users'
				cuCanvas.enabled = false;
				error.enabled = false;
			} else {
				error.enabled = true;
			}
		}

		Manager.instance.Save();

		Debug.Log (Manager.instance.users.Count + "");
	}
}
