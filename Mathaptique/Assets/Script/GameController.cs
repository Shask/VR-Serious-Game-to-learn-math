using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject Lights;


	// Use this for initialization
	void Start () {

		Lights = GameObject.FindGameObjectWithTag ("Level1");
		Lights.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FirstStageSucces(bool succes)
	{
		if (succes) {
		
			Lights.SetActive(true);
		} else {
		

		}

	

}
}
