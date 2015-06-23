using UnityEngine;
using System.Collections;

public class CubeValues : MonoBehaviour {
    public float value;
    private Color defaultColor;
	private Shader defaultShader;

	// Use this for initialization
	void Start () {
        defaultColor = gameObject.GetComponent<Renderer>().material.color;
		defaultShader=gameObject.GetComponent<Renderer>().material.shader;
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
	public Shader getShader()
	{
		return defaultShader;
	}
}
