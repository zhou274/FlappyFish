using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	static bool sawOnce = false;
	public GameObject startText;

	// Use this for initialization
	void Start () {
		if(!sawOnce) {
			startText.SetActive(true);
			//GetComponent<SpriteRenderer>().enabled = true;
			Time.timeScale = 0;
		}

		sawOnce = true;
	}
	
	//Update is called once per frame
	void Update () {
		if(Time.timeScale==0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) ) {
			Time.timeScale = 1;
			startText.SetActive(false);
			//GetComponent<SpriteRenderer>().enabled = false;
			sawOnce=false;
		}
	}
}
