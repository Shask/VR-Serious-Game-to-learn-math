using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject[] Lights;
	private GameObject Light1;

	private GameObject[] Effects2;
	private GameObject Effect2;

	private QuestReader Stannis;


	// Use this for initialization
	void Start () {

		Stannis = GameObject.FindWithTag ("Stannis").GetComponent<QuestReader>();

		Lights = GameObject.FindGameObjectsWithTag ("Level1");
		foreach (GameObject Light1 in Lights) {
			Light1.SetActive(false);
		}


		Effects2 = GameObject.FindGameObjectsWithTag ("Level2");
		foreach (GameObject Effect2 in Effects2) {
			Effect2.SetActive(false);
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

	public void SecondStageSucces(bool succes)
	{
		if (succes) {
			Stannis.BurnDaughter();
			foreach (GameObject Effect2 in Effects2) {
				Effect2.SetActive(true);

			}
		} else {
			Stannis.BurnDaughterFail();
			
		}
	}
}
