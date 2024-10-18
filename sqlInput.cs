using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class sqlInput : MonoBehaviour {
	public InputField UserName; 
	public InputField PassWord;
	public InputField NameField;
	public InputField GamesWon;
	public InputField GamesLost;

	public Button button;

	public static string username;
	public static string password;
	public static string Name;
	public static int gameswon;
	public static int gameslost;

	public Text text;
	string result;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(username!=null && password!=null && Name!=null && gameswon!=null && gameslost!=null)
			button.interactable=true;
		
	}

	public void SetUsername(){
		username = UserName.text;
	}
	public void SetPassword(){
		password = PassWord.text; 
	}
	public void SetName(){
		Name = NameField.text;
	}
	public void SetGamesWon(){
		gameswon = int.Parse(GamesWon.text);
	}
	public void SetGamesLost(){
		gameslost = int.Parse(GamesLost.text);
	}

	public void CreateEntry(){
		StartCoroutine(InputData());
	}

	public IEnumerator InputData() {

		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField("password", password);
		form.AddField("name", Name);
		form.AddField("gameswon", gameswon);
		form.AddField("gameslost", gameslost);
		//UnityWebRequest www = UnityWebRequest.Post("http://tattorn.atwebpages.com/setdata.php",form);
		//yield return www.Send();
		var url = "http://tattorn.atwebpages.com/setdata.php";
		string input_data = url + "?username=" + username + "&password=" + password + "&name=" + Name +"&gameswon=" + gameswon + "&gameslost=" + 
			gameslost;
		WWW entereddata = new WWW (input_data);
		yield return entereddata;
		if(entereddata.text == "failed")
		{
			Debug.LogError(entereddata.error); 
			text.text="failed inputting to database!";
		}
		else if(entereddata.text == "success")
		{
			StartCoroutine(GetTechnicalData());
		}
		else
		{Debug.LogError(entereddata.text);  }
		button.interactable=false;
	}

	public IEnumerator GetTechnicalData() {
		WWW database = new WWW("tattorn.atwebpages.com/getdata.php");
		yield return database;
		if (database.error != null)
		{
			print("There was an error getting the high score: " + database.error);
		}
		else
		{
			string data = database.text;
			Debug.Log(data);
			result = data.Replace("<br>", "\n");
			string[] majorarray = data.Split('\n');

			foreach(string child in majorarray){
				string[] array = child.Split(',');
				//Debug.Log( array[0]+" "+array[1]+" "+array[2]+" "+array[3]/*+" "+array[4]+" "+array[5]*/ );
				text.text += array[0]+"  "+array[1]+"  "+array[2]+"  "+array[3]+"\n"/*+" "+array[4]+" "+array[5]*/;
			}
		}
	}

}
