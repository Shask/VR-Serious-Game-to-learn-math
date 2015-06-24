using UnityEngine;
using System.Collections;

public class ObjectDetection : MonoBehaviour {
    GameObject player;
    private int nbCollisions, maxCollisions;
    private string interactiveTag = "Interactive";
	private Shader OutlineSelection;




	// Use this for initialization
	void Start () {
		player = GameObject.Find("GodObject");
		OutlineSelection= Shader.Find ("Toon/Basic Outline");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == interactiveTag)
        {
            nbCollisions++;
			if (!player.GetComponent<HapticPlayer>().getIsGrabbingItem())
            {
				player.GetComponent<HapticPlayer>().setcanGrabItem(true);
				player.GetComponent<HapticPlayer>().setItemInRange(col.gameObject);
                //col.gameObject.GetComponent<Renderer>().material.color = new Color(125, 0, 0);

				Renderer TargetRenderer=null;
				try
				{
					TargetRenderer=col.gameObject.GetComponent<Renderer>();
				}catch(UnityException e){}
				if(TargetRenderer.enabled==true)
				{
					col.gameObject.GetComponent<Renderer>().material.shader = OutlineSelection;
				}
				else 
				{
					//col.gameObject.transform.GetChild(0).GetComponentInChildren
					col.gameObject.transform.GetChild(0).GetComponentInChildren<Renderer>().material.shader=OutlineSelection;
				}
				//Color c = col.gameObject.GetComponent<Renderer>().material.GetColor();
               // Debug.Log("can grab item");
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
			Renderer TargetRenderer=null;
			try
			{
				TargetRenderer=col.gameObject.GetComponent<Renderer>();
			}catch(UnityException e){}
			if(TargetRenderer.enabled==true)
			{
				TargetRenderer.material.shader = col.gameObject.GetComponent<CubeValues>().getShader();
			}
			else 
			{
				col.gameObject.transform.GetChild(0).GetComponentInChildren<Renderer>().material.shader=col.gameObject.transform.GetChild(0).GetComponentInChildren<CubeValues>().getShader();
			}
          // Debug.Log("can't grab item anymore");
        }
        
    }
}
