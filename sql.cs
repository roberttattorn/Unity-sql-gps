using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sql : MonoBehaviour {
	public Text result;
	// Use this for initialization
	void Start () {
		
		StartCoroutine(downloadWorldRecordGhost());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator downloadWorldRecordGhost() {
		WWW database = new WWW("tattorn.atwebpages.com/getdata.php");
		yield return database;
		if (database.error != null)
		{
			print("There was an error getting the high score: " + database.error);
		}
		else
		{
			string data = database.text;

			result.text = data.Replace("<br>", "\n");
			data= data.Replace("<br>", "\n");
			string[] majorarray = data.Split('\n');

			foreach(string child in majorarray){
			string[] array = child.Split(',');
				if(array.Length==4)
			Debug.Log( array[0]+" "+array[1]+" "+array[2]+" "+array[3]/*+" "+array[4]+" "+array[5]*/ );
			}
		}
	}

}
