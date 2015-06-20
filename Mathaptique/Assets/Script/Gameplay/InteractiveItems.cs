using UnityEngine;
using System.Collections;

public class InteractiveItems : MonoBehaviour {
	private string itemTag = "Interactive";

	// Use this for initialization
	void Start () {

		//Set a tag "interactive" to all the childs of this object
		foreach (Transform child in transform)
		{
			Debug.Log(child.name);
			child.gameObject.tag = itemTag;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
