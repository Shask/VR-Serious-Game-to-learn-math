using UnityEngine;
using System.Collections;

public class CubeValues : MonoBehaviour {
    public float value;
    private Color defaultColor;

	// Use this for initialization
	void Start () {
        defaultColor = gameObject.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float getValue()
    {
        return value;
    }

    public Color getDefaultColor()
    {
        return defaultColor;
    }
}
