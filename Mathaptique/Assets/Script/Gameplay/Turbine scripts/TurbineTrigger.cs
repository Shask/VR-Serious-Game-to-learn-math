using UnityEngine;
using System.Collections;

/**
 * Detection du joueur dans les trigger zones des turbines
 * */
public class TurbineTrigger : MonoBehaviour {
    private bool canRotateItem;
    public GameObject rotatingItem; //objet à rotater qui est vise

	// Use this for initialization
	void Start () {
        canRotateItem = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            if(rotatingItem != null)
            {
                GameObject.Find("Player").GetComponent<PlayerTurbine>().currentTriggerZoneIn = gameObject;
                GameObject.Find("Player").GetComponent<PlayerTurbine>().setCanRotate(true);
            }
            
            else
            {
                Debug.Log("This triggerBox has no matching rotating item");
            }
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerTurbine>().currentTriggerZoneIn = null;
            GameObject.Find("Player").GetComponent<PlayerTurbine>().setCanRotate(false);
            rotatingItem.GetComponent<Rotator>().setRotateClockWise(false);
            rotatingItem.GetComponent<Rotator>().setRotateCounterClockWise(false);
        }

    }
}
