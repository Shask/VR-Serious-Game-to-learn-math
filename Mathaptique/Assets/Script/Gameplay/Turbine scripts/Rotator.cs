using UnityEngine;
using System.Collections;

/**
 * Rotation du rotor
 * */
public class Rotator : MonoBehaviour {
    private Quaternion originalRotation;
    private Vector3 originalPosition;
    private bool rotateClockWise, rotateCounterClockWise;
    private float rotateSpeed = 30;

	// Use this for initialization
	void Start () {
        originalRotation = gameObject.transform.rotation;
        originalPosition = gameObject.transform.position;
        rotateCounterClockWise = false;
        rotateClockWise = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        //sens horaire
        if(rotateClockWise)
        {
             transform.Rotate (0,0,rotateSpeed * Time.deltaTime);
        }

        else if (rotateCounterClockWise)
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime); 
        }

	
	}

    public void resetAllRotations()
    {
         rotateClockWise = false;
         rotateCounterClockWise = false;
         gameObject.transform.rotation = originalRotation;
         gameObject.transform.position = originalPosition;
    }


    //Rotation sens aiguilles d'une montre
    public void setRotateClockWise(bool val)
    {
        rotateClockWise = val;
    }

    //Rotation sens inverse aiguilles d'une montre
    public void setRotateCounterClockWise(bool val)
    {
        rotateCounterClockWise = val;
    }


}
