using UnityEngine;
using System.Collections;

public class ObjectDetection : MonoBehaviour {
    GameObject player;
    private int nbCollisions, maxCollisions;
    private string interactiveTag = "Interactive";

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == interactiveTag)
        {
            nbCollisions++;
            if (!player.GetComponent<Player>().getIsGrabbingItem())
            {
                player.GetComponent<Player>().setcanGrabItem(true);
                player.GetComponent<Player>().setItemInRange(col.gameObject);
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
            player.GetComponent<Player>().setcanGrabItem(false);
            player.GetComponent<Player>().setItemInRange(null);
            col.gameObject.GetComponent<Renderer>().material.color = col.gameObject.GetComponent<CubeValues>().getDefaultColor();
            Debug.Log("can't grab item anymore");
        }
        
    }
}
