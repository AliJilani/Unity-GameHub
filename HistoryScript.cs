using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HistoryScript : MonoBehaviour {

	public Canvas hisCanvas;
	public GameObject text;

	// Use this for initialization
	void Start () {
		hisCanvas.enabled = false;
		printUsers ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void printUsers()
	{
		text.GetComponent<Text> ().text = "";
		//iterate through the users list
		foreach (User user in Manager.instance.users) {

			string newString = "";
			//print the entry logs from each user
			foreach (Entry entry in user.logs) {
				newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n";
			}

			//add that info to the text box on the screen
			text.GetComponent<Text> ().text += user.username +" -- Status:" + statusDecode(user.status) + " : \n" + newString+"\n";
		}
	}

	public void printUsersSS()
	{
		text.GetComponent<Text> ().text = "";
		foreach (User user in Manager.instance.users) {

			string newString = "";
			foreach (Entry entry in user.logsSS) {
				newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n" + "Score:" + entry.score + " GameLevel: " + entry.rank;
			}

			text.GetComponent<Text> ().text += user.username +" -- Status:" + statusDecode(user.status) + " : \n" + newString+"\n";
		}
	}

	public void printUsersApple()
	{
		text.GetComponent<Text> ().text = "";
		foreach (User user in Manager.instance.users) {

			string newString = "";
			foreach (Entry entry in user.logsApple) {
				newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n" + "Score:" + entry.score;
			}

			text.GetComponent<Text> ().text += user.username +" -- Status:" + statusDecode(user.status) + " : \n" + newString+"\n";
		}
	}

	public void printUsersMem()
	{
		text.GetComponent<Text> ().text = "";
		foreach (User user in Manager.instance.users) {

			string newString = "";
			foreach (Entry entry in user.logsMem) {
				newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n" + "Score:" + entry.score;
			}

			text.GetComponent<Text> ().text += user.username +" -- Status:" + statusDecode(user.status) + " : \n" + newString+"\n";
		}
	}

	public void printUsersRPS()
	{
		text.GetComponent<Text> ().text = "";
		foreach (User user in Manager.instance.users) {

			string newString = "";
			foreach (Entry entry in user.logsRPS) {
				newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n" + "Wins:" + entry.score;
			}

			text.GetComponent<Text> ().text += user.username +" -- Status:" + statusDecode(user.status) + " : \n" + newString+"\n";
		}
	}

	public string statusDecode(int status)
	{
		if (status == 0) {
			return "NEW";
		} else if (status == 1) {
			return "NORMAL";
		} else {
			return "BLOCKED";
		}
	}

	public void exitBtn()
	{
		Manager.instance.btnClick();
		hisCanvas.enabled = false;
	}
}
