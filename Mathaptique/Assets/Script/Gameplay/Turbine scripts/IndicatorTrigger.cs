using UnityEngine;
using System.Collections;

/**
 * Detection des pales dans la zone d'indication (la ou il faut placer les pales)
 * */
public class IndicatorTrigger : MonoBehaviour {
    private bool isValid; //condition de reussite remplie
    public GameObject matchingTrigger; //objet qui doit rentrer dans le trigger 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == matchingTrigger)
        {
            isValid = true;
            Debug.Log(col.gameObject.name + " is in the indicator");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == matchingTrigger)
        {
            isValid = false;
            Debug.Log(col.gameObject.name + " has left the indicator");
        }
    }

    public bool getIsValid()
    {
        return isValid;
    }
}
