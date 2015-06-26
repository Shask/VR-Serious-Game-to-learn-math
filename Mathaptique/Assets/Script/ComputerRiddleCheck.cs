using UnityEngine;
using System.Collections;
using System;

public class ComputerRiddleCheck : MonoBehaviour {
	private TextMesh Result;
	private TextMesh Enonce;
	public double result = 0.9;

	private float timerClic = 1.0f;
	private bool canClic = true;

	private GameController gamectrl;

	private bool succeded = false;

	// Use this for initialization
	void Start () {
		Result = GameObject.Find ("Result").GetComponent<TextMesh>();
		Enonce = GameObject.Find ("Enoncé").GetComponent<TextMesh>();
		gamectrl = GameObject.Find ("GameManager").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		timerClic -= Time.deltaTime;
		if (timerClic <= 0.0f && !succeded)
			canClic = true;
	}

	public void checkResult()
	{

		if (canClic) {
			if (Convert.ToDouble (Result.text) == result) {
				succeded=true;
				Debug.Log ("Succes");
				Enonce.text="Bravo !\r\n"+"Merci pour votre participation a\r\n" + 
					"la destruction de la race humaine";
				Enonce.characterSize=2;
				Result.gameObject.transform.GetComponentInChildren<Renderer>().material=Resources.Load("3dTextVert",typeof(Material)) as Material;
				gamectrl.ThridStageSucces(true);
			//	GameObject instance = Instantiate(Resources.Load("Fireworkslvl3", typeof(GameObject))) as GameObject;

			} else {
				gameObject.GetComponent<AudioSource>().Play();
				Debug.Log("Failed");

			}
			canClic=false;
			timerClic=1.0f;
			

		}
	}
}
