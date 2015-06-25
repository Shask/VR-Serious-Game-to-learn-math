using UnityEngine;
using System.Collections;
using System;

public class ComputerRiddleButton : MonoBehaviour {

	public bool isPlus;
	private TextMesh Result;
	private float timerClic = 0.2f;

	private bool canClic = true;
	// Use this for initialization
	void Start () {
		Result = GameObject.Find ("Result").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		timerClic -= Time.deltaTime;
		if (timerClic <= 0.0f)
			canClic = true;

	}
	public void press()
	{
		if (canClic) {
			double TempRes = Convert.ToDouble (Result.text);
			if (isPlus) {
				TempRes += 0.1;
			} else {
				TempRes -= 0.1;
			}
			Result.text = Convert.ToString (TempRes);
			canClic=false;
			timerClic=1.0f;
		}
	}
}
