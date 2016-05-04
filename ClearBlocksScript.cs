using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearBlocksScript : MonoBehaviour {

	public InputField usernameInput;
	public string username;
	public Canvas cbCanvas;
	public Text error;

	// Use this for initialization
	void Start () {
		usernameInput.characterValidation = InputField.CharacterValidation.Alphanumeric; //only letters and numbers
		usernameInput.characterLimit = 10;
		cbCanvas.enabled = false;
		error.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void usernameEntered()
	{
		username = usernameInput.GetComponent<InputField> ().text;
	}

	public void submitBtn()
	{
		Manager.instance.btnClick();
		User temp = new User ();
		temp.username = username;
		if (Manager.instance.users.Contains (temp)) { //check to see if user exists
			User temp1 = Manager.instance.users.Find (x => x.username == username);
			temp1.status = 0; //set as new
			temp1.changePassword (username); //reset password
			error.enabled = false;
			cbCanvas.enabled = false;
		} else
			error.enabled = true;

		Manager.instance.Save(); //Save
	}

	public void cancelBtn()
	{
		Manager.instance.btnClick();
		cbCanvas.enabled = false;
	}
}
