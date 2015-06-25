using UnityEngine;
using System.Collections;

/**
 * Detection du joueur dans les trigger zones des turbines
 * */
public class TurbineTrigger : MonoBehaviour {
    private bool canRotateItem;
    public GameObject rotatingItem; //objet à rotater qui est vise

	private Shader OutlineSelection;
	private Shader DefaultShader;

	// Use this for initialization
	void Start () {
        canRotateItem = false;
		OutlineSelection= Shader.Find ("Toon/Basic Outline");
		DefaultShader = rotatingItem.GetComponent<Renderer> ().material.shader;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(rotatingItem != null)
            {
				col.gameObject.GetComponentInChildren<HapticPlayer>().currentTriggerZoneIn = gameObject;
				col.gameObject.GetComponentInChildren<HapticPlayer>().setCanRotate(true);
				OutlineFan(true);
            }
            
            else
            {
                Debug.Log("This triggerBox has no matching rotating item");
            }
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
			col.gameObject.GetComponentInChildren<HapticPlayer>().currentTriggerZoneIn = null;
			col.gameObject.GetComponentInChildren<HapticPlayer>().setCanRotate(false);
            rotatingItem.GetComponent<Rotator>().setRotateClockWise(false);
            rotatingItem.GetComponent<Rotator>().setRotateCounterClockWise(false);
			OutlineFan(false);
        }

    }

	public void OutlineFan(bool isOutlined)
	{
		if (isOutlined) {
			rotatingItem.GetComponent<Renderer> ().material.shader=OutlineSelection;
		} else {
			rotatingItem.GetComponent<Renderer> ().material.shader=DefaultShader;
		}
	}
}
