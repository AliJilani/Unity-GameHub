using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeleteUserScript : MonoBehaviour {

	public Canvas duCanvas;
	public InputField username;
	public string usernameInput;
	public Text error;
	// Use this for initialization
	void Start () {
		username.characterLimit = 10;
		username.characterValidation = InputField.CharacterValidation.Alphanumeric; // ensure only numbers and letters
		error.enabled = false;
		duCanvas.enabled = false;
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
		duCanvas.enabled = false;
	}

	public void confirmBtn()
	{
		Manager.instance.btnClick();
		Debug.Log (usernameInput);
		User tempUser = new User ();
		tempUser.username = usernameInput;
		if (Manager.instance.users.Contains (tempUser)) { // find user
			if (usernameInput == "admin") { //admin cannot be deleted
				error.enabled = true;
			} else { //Delete selected user
				Manager.instance.users.Remove (tempUser);
				duCanvas.enabled = false;
			}
		} else { 
			error.enabled = true;
		}

		Manager.instance.Save();
		Debug.Log (Manager.instance.users.Count + "");
	}
}
