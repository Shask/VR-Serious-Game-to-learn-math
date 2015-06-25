using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject[] Lights;
	private GameObject Light1;

	private GameObject[] Effects2;
	private GameObject Effect2;

	private GameObject[] Effects3;
	private GameObject Effect3;

	private GameObject[] Effects4;
	private GameObject Effect4;

	private QuestReader Stannis;



	public bool lvl1Succes=false;
	public bool lvl2Succes=false;
	public bool lvl3Succes=false;
	public bool lvl4Succes=false;

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

		Effects3 = GameObject.FindGameObjectsWithTag ("Level3");
		foreach (GameObject Effect3 in Effects3) {
			Effect3.SetActive(false);
		}

		Effects4 = GameObject.FindGameObjectsWithTag ("Level4");
		foreach (GameObject Effect4 in Effects4) {
			Effect4.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FirstStageSucces(bool succes)
	{
		if (succes) {
			lvl1Succes=true;
			foreach (GameObject Light1 in Lights) {
				Light1.SetActive(true);
			}
		} else {
		

		}
		}

	public void SecondStageSucces(bool succes)
	{
		if (succes) {
			lvl2Succes=true;
			Stannis.BurnDaughter();
			foreach (GameObject Effect2 in Effects2) {
				Effect2.SetActive(true);

			}
		} else {
			Stannis.BurnDaughterFail();
			
		}
	}

	public void ThridStageSucces(bool succes)
	{
		if (succes) {
			lvl3Succes=true;
			foreach (GameObject Effect3 in Effects3) {
				Effect3.SetActive (true);

			}
		}
	}
	public void FourthStageSucces(bool succes)
	{
		if (succes) {
			lvl4Succes = true;
			foreach (GameObject Effect4 in Effects4) {
				Effect4.SetActive (true);
				
			}
		}

	}
}
