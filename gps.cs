using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gps : MonoBehaviour {
	Sprite sprite;
	float latitude, longitude;
	string exampleUrl ;
	string key ; //put your own API key here.
	public Text error;

	IEnumerator Start() {

		if(Input.location.isEnabledByUser){
			Input.location.Start();
			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;
		 exampleUrl = "https://maps.googleapis.com/maps/api/staticmap?center=" + latitude + "," + longitude + "&zoom=" + 1 + "&size=720x1280" + "&Scale=" + 1;
		key = "&key=a1a7d1fe118fbf9eb561f063b90e9076";
		WWW www = new WWW(exampleUrl+key);
		yield return www;
		sprite = Sprite.Create(www.texture, new Rect(0.0f, 0.0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 100.0f);
		GetComponent<Image>().sprite = sprite;
		}
		else
			error.text="Sorry, no GPS!";
	}

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {
		
	}
}
