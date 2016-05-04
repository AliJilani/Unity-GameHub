using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HistoryScriptNonAdmin : MonoBehaviour {

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

			string newString = "";
		//Iterate through the logs of the user
		foreach (Entry entry in Manager.instance.user.logs) {
				newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n";
			}

		//Add that to the textbox
		text.GetComponent<Text> ().text += Manager.instance.user.username +" -- Status:" + statusDecode(Manager.instance.user.status) + " : \n" + newString+"\n";
	}

	public void printUsersSS()
	{
		text.GetComponent<Text> ().text = "";

		string newString = "";
		foreach (Entry entry in Manager.instance.user.logsSS) {
			newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n" + "Score:" + entry.score + " GameLevel: " + entry.rank;
		}

		text.GetComponent<Text> ().text += Manager.instance.user.username +" -- Status:" + statusDecode(Manager.instance.user.status) + " : \n" + newString+"\n";
	}

	public void printUsersApple()
	{
		text.GetComponent<Text> ().text = "";

		string newString = "";
		foreach (Entry entry in Manager.instance.user.logsApple) {
			newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n" + "Score:" + entry.score;
		}

		text.GetComponent<Text> ().text += Manager.instance.user.username +" -- Status:" + statusDecode(Manager.instance.user.status) + " : \n" + newString+"\n";
	}

	public void printUsersMem()
	{
		text.GetComponent<Text> ().text = "";

		string newString = "";
		foreach (Entry entry in Manager.instance.user.logsMem) {
			newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n" + "Score:" + entry.score;
		}

		text.GetComponent<Text> ().text += Manager.instance.user.username +" -- Status:" + statusDecode(Manager.instance.user.status) + " : \n" + newString+"\n";
	}

	public void printUsersRPS()
	{
		text.GetComponent<Text> ().text = "";

		string newString = "";
		foreach (Entry entry in Manager.instance.user.logsRPS) {
			newString += "Date: " + entry.date + " " + "  Duration: " + (entry.duration/60) + " minutes\n" + "Wins:" + entry.score;
		}

		text.GetComponent<Text> ().text += Manager.instance.user.username +" -- Status:" + statusDecode(Manager.instance.user.status) + " : \n" + newString+"\n";
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

