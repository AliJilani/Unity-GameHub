using UnityEngine;
using System.Collections;
//using UnityEditor;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

	public static Manager instance;
	public List<User> users=new List<User>(); //List of User
	public User admin;
	public string userLoggedIn;
	//public string username;
	//public string password;
	public Sprite backgroundImg;
	public Sprite[] backImages = new Sprite[3];
	public User user;
	public AudioSource audio;

	void Awake()
	{
		if (instance) 
		{
			DestroyImmediate (gameObject); //stays alive all game long
		}
		else 
		{
			DontDestroyOnLoad (transform.gameObject);
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {

		backgroundImg = backImages [0]; // sets background

		Load ();

		User tempUser = new User ();
		tempUser.username = "admin";
		if (!(users.Contains (tempUser))) {
			admin = new User ("admin");
			users.Add (admin);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Save() //Saves users list in a file
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "mainInfo.dat");

		dataStorage data = new dataStorage ();
		data.usersStored = users;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load() //retrieves saved information
	{
		if (File.Exists (Application.persistentDataPath + "mainInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "mainInfo.dat", FileMode.Open);
			dataStorage data = (dataStorage)bf.Deserialize (file);
			file.Close ();

			users = data.usersStored;
		}
	}

	public void btnClick()
	{
		audio.Play ();
	}

	//Manager.instance.btnClick();
}


[Serializable]
class dataStorage
{
	public List<User> usersStored = new List<User>();
}

[System.Serializable]
public class Entry //entry class for time logs, used for History
{
	public DateTime date;
	public float duration;
	public int score;
	public String rank;

	public Entry()
	{
		//date;
		//duration = 0;
		//score = -1;
		//rank = "";
	}
	public Entry(DateTime x, float y)
	{
		date = x;
		duration = y;
		score = -1;
		rank = "";
	}
	public Entry(DateTime x, float y, int gameScore)
	{
		date = x;
		duration = y;
		score = gameScore;
		rank = "";
	}
	public Entry(DateTime x, float y, int gameScore, String gameRank)
	{
		date = x;
		duration = y;
		score = gameScore;
		rank = gameRank;
	}
}

[System.Serializable]
public class User:IEquatable<User> //Custom User class,
{
	public string username = "";
	private string password = "";
	public int status; // 0 is new, 1 is normal, 2 is blocked

	//Stores History
	public List<Entry> logs= new List<Entry>();
	public List<Entry> logsRPS= new List<Entry>();
	public List<Entry> logsApple= new List<Entry>();
	public List<Entry> logsMem= new List<Entry>();
	public List<Entry> logsSS= new List<Entry>();

	public int highScoreRPS=0;
	public int highScoreApple=0;
	public int highScoreMem=0;
	public int highScoreSS=0;

	public User()
	{

	}

	public User(string name)
	{
		username = name;
		password = name;
		status = 0;
	}

	public bool Equals(User other)
	{
		if (this.username == other.username)
			return true;
		else
			return false;
	}
	public bool checkPassword(string guess)
	{
		if (guess==this.password)
			return true;
		else 
			return false;
	}
	public void changePassword(string newPass)
	{
		password = newPass;
	}
}

