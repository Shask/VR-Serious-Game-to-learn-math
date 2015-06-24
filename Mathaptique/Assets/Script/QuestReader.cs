using UnityEngine;
using System.Collections;

public class QuestReader : MonoBehaviour {

	public float timer=15.0f;
	private bool timerStart = false;
	private bool alreadyPlayed = false;

	public string text0;
	public string text1;
	public string text2;
	public string text3;
	public string text4;
	public string textFinal;

	private TextMesh textMesh;
	private Vector3 textMeshInitPos;
	private Vector3 textMeshInitScale;
	private GameObject TextMeshGO;



	// Use this for initialization
	void Start () {
		TextMeshGO = GameObject.Find ("QuestText");
		textMesh = TextMeshGO.GetComponent<TextMesh>();
		textMeshInitPos = TextMeshGO.transform.localPosition;
		textMeshInitScale = TextMeshGO.transform.localScale;

		text1 = text1.Replace("nwl","\r\n");
		text2 = text2.Replace("nwl","\r\n");
		text3 = text3.Replace("nwl","\r\n");
		text4 = text4.Replace("nwl","\r\n");
		textFinal = textFinal.Replace("nwl","\r\n");

	}
	
	// Update is called once per frame
	void Update () {
		if (timerStart) {

			timer -= Time.deltaTime;
			
			if(!alreadyPlayed)
			{
				if (timer > 13.0f) {
					textMesh.text = text1;
				}
				if (timer < 13.0f && timer > 9.0f) {
					textMesh.text = text2;
				}
				if (timer < 9.0f && timer > 3.0f) {
					textMesh.text = text3;
				}
				if (timer < 3.0f && timer > 0.0f) {
					textMesh.text = text4;
				}
				if (timer < 0.0f) {
					timerStart = false;
					alreadyPlayed=true;
					textMesh.text = text0;
					StopTalking();
				}
			}
			else 
			{
				if (timer > 5.0f) {
					textMesh.text = textFinal;
				}
				else
				{
					timerStart = false;
					textMesh.text = text0;
					StopTalking();
				}
			}
		}
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			timerStart=true;
			Talk ();
			timer = 15.0f;
		}

	}

	public void Talk()
	{
		TextMeshGO.transform.localPosition=new Vector3(1.0f,1.2f,0.3f);
		TextMeshGO.transform.localScale= new Vector3(0.05f,0.05f,0.05f);
	}
	public void StopTalking()
	{
		TextMeshGO.transform.localPosition=textMeshInitPos;
		TextMeshGO.transform.localScale= textMeshInitScale;
	}


}
