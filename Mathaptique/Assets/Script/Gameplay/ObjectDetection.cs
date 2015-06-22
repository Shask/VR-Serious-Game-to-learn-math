using UnityEngine;
using System.Collections;

public class ObjectDetection : MonoBehaviour {
    GameObject player;
    private int nbCollisions, maxCollisions;
    private string interactiveTag = "Interactive";

	// Use this for initialization
	void Start () {
        player = GameObject.Find("GodObject");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
		int q = 1;
        if (col.gameObject.tag == interactiveTag)
        {
            nbCollisions++;
            if (!player.GetComponent<HapticPlayer>().getIsGrabbingItem())
            {
                player.GetComponent<HapticPlayer>().setcanGrabItem(true);
				player.GetComponent<HapticPlayer>().setItemInRange(col.gameObject);
                col.gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                Debug.Log("can grab item");
            }
               
        }
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == interactiveTag)
        {
            nbCollisions--;
            player.GetComponent<HapticPlayer>().setcanGrabItem(false);
			player.GetComponent<HapticPlayer>().setItemInRange(null);
            col.gameObject.GetComponent<Renderer>().material.color = col.gameObject.GetComponent<CubeValues>().getDefaultColor();
            Debug.Log("can't grab item anymore");
        }
        
    }
}
