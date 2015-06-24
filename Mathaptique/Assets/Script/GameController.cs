using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject[] Lights;
	private GameObject Light1;


	// Use this for initialization
	void Start () {

		Lights = GameObject.FindGameObjectsWithTag ("Level1");
		foreach (GameObject Light1 in Lights) {
			Light1.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FirstStageSucces(bool succes)
	{
		if (succes) {
		
			foreach (GameObject Light1 in Lights) {
				Light1.SetActive(true);
			}
		} else {
		

		}

	

}
}
