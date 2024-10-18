using UnityEngine;
using System.Collections;

public class myscript : MonoBehaviour {

	public Material dress2;
	public GameObject item;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
			transform.Find("dress").gameObject.GetComponent<SkinnedMeshRenderer>().material=dress2;

		//if(item==null)
			//Debug.Log("disappeared");

		if(Input.GetMouseButtonDown(0)){
		var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(Ray,out hit)){
			if(hit.collider.gameObject.tag=="Player"){
					Debug.Log("woman hit");
					if(hit.collider.transform.parent!=null)
						Debug.Log(hit.collider.transform.parent.gameObject.name);}
			}
			}
	}
}
