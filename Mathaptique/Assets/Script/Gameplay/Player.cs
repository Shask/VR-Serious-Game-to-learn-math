using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private bool canGrabItem, isGrabbingItem;
	private float yPos;
	private GameObject itemInRange, grabbedItem;
	private int nbCollisions;
    private string interactiveTag = "Interactive"; //tag for grabbable items (must be defined into the inspector)


	// Use this for initialization
	void Start () {
		canGrabItem = false;
		isGrabbingItem = false;
		yPos = gameObject.transform.position.y;
		itemInRange = null;
		grabbedItem = null;
		nbCollisions = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		//Keep the object on its original y position
		if (gameObject.transform.position.y > yPos+0.1 || gameObject.transform.position.y < yPos - 0.1) 
		{
			Vector3 fixedPos = new Vector3(gameObject.transform.position.x,yPos,gameObject.transform.position.z);
			gameObject.transform.position = fixedPos;
		}
						

		if (Input.GetKey("z"))
		{
			gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward , ForceMode.Impulse);
		}

		if (Input.GetKey("s"))
		{
			gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * -1 , ForceMode.Impulse);
		}

		if (Input.GetKey("q"))
		{
			gameObject.transform.Rotate(gameObject.transform.up * -10);
		}

		if (Input.GetKey("d"))
		{
			gameObject.transform.Rotate(gameObject.transform.up * 10);
		}

		if (Input.GetMouseButtonDown(0) ||Input.GetKey("e") ) 
		{
			GrabItem();
		}

		if(Input.GetMouseButtonUp(0)||Input.GetKey("r"))
	 	{
			DropItem();
		}

		//if the player is grabbing something, keep the item above him
		if(isGrabbingItem && grabbedItem != null)
			putItemAbovePlayer();
	
	}

	//Grab an item
	public void GrabItem()
	{
		if (!isGrabbingItem) 
		{
			if(itemInRange != null)
			{
				//put the item above the player
				grabbedItem = itemInRange;
				grabbedItem.transform.parent = gameObject.transform;
				grabbedItem.GetComponent<Rigidbody>().useGravity = false;
                grabbedItem.GetComponent<Rigidbody>().freezeRotation = true;
                grabbedItem.GetComponent<Rigidbody>().mass = 0;
				putItemAbovePlayer();

				isGrabbingItem = true;
				Debug.Log("Grabbing item");
			}

			else
			{
				Debug.Log("nothing to grab");
			}
		}
	}

	public void DropItem()
	{
		if (isGrabbingItem) 
		{
			if(grabbedItem != null)
			{
				grabbedItem.transform.parent = null;
				grabbedItem.GetComponent<Rigidbody>().useGravity = true;
                grabbedItem.GetComponent<Rigidbody>().freezeRotation = false;
                grabbedItem.GetComponent<Rigidbody>().mass = 1;
				//grabbedItem.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward  *1.5f , ForceMode.Impulse);
				isGrabbingItem = false;
				Debug.Log("Dropping item");
			}
		}
	}

	public void putItemAbovePlayer()
	{
        Vector3 newPos = gameObject.transform.position + gameObject.transform.forward * 2 + Vector3.up;
        grabbedItem.transform.position = newPos;
	}


	public void OnCollisionEnter(Collision col)
	{
        /*if (col.gameObject.tag == interactiveTag) 
		{
			nbCollisions++;
			if(!isGrabbingItem)
			{
				canGrabItem = true;
				Debug.Log("can grab item");
				itemInRange = col.gameObject;
			}
		} */
	}

	public void OnCollisionExit(Collision col)
	{
		/*nbCollisions--;
        if (col.gameObject.tag == interactiveTag) 
		{
			canGrabItem = false;
			Debug.Log("can't grab item anymore");
			itemInRange = null;
		} */
	} 

    public void setcanGrabItem(bool val)
    {
        canGrabItem = val;
    }

    public bool getIsGrabbingItem()
    {
        return isGrabbingItem;
    }

    public void setItemInRange(GameObject item)
    {
        itemInRange = item;
    }
}
