using UnityEngine;
using System.Collections;

public class CubeValues : MonoBehaviour {
    public float value;
    private Color defaultColor;
	private Shader defaultShader;
	private CapsuleCollider CPSCollider;
	public bool HitBoxOnly;

	// Use this for initialization
	void Start () {
		if (!HitBoxOnly) {
			defaultColor = gameObject.GetComponent<Renderer> ().material.color;
			defaultShader = gameObject.GetComponent<Renderer> ().material.shader;
		}
			CPSCollider = GetComponent<CapsuleCollider> ();
		
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
