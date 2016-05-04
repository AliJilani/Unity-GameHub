using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangePasswordScript : MonoBehaviour {

	public Canvas cpCanvas;
	public InputField newPass;
	public InputField newPass1;
	public string password;
	public string password1;
	public Text sameError;
	public Text oldError;
	// Use this for initialization
	void Start () {
		newPass.characterLimit = 24;
		newPass.characterValidation = InputField.CharacterValidation.Alphanumeric; //make sure just numbers and letters allouwed
		newPass1.characterLimit = 24;
		newPass1.characterValidation = InputField.CharacterValidation.Alphanumeric;
		cpCanvas.enabled = false;
		sameError.enabled = false;
		oldError.enabled = false;

		User temp = Manager.instance.users.Find (x => x.username == Manager.instance.userLoggedIn);
		if (temp.status == 0) { //Open automatically for new user
			cpCanvas.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PassEntered()
	{
		password = newPass.GetComponent<InputField> ().text;
	}

	public void Pass2Entered()
	{
		password1 = newPass1.GetComponent<InputField> ().text;
	}

	public void CancelBtn()
	{
		Manager.instance.btnClick();
		sameError.enabled = false;
		oldError.enabled = false;
		cpCanvas.enabled = false;
	}

	public void ConfirmBtn()
	{
		Manager.instance.btnClick();
		User temp = Manager.instance.users.Find (x => x.username == Manager.instance.userLoggedIn); //Find user
		if (temp.checkPassword (password)) { //check to see if he's using the same password
			oldError.enabled = true; //old password error
		} else {
			if ((password == password1) && (password != "")) {
				temp.changePassword (password); //change password
				temp.status = 1;
				sameError.enabled = false;
				oldError.enabled = false;
				cpCanvas.enabled = false;
				Manager.instance.Save();
			} else {
				sameError.enabled = true; //not matching passwords error
			}
		}
	}
}
