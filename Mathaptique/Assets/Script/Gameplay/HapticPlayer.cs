using UnityEngine;
using System.Collections;

public class HapticPlayer : MonoBehaviour {
	private bool canGrabItem, isGrabbingItem;
	private float yPos;
	private GameObject itemInRange, grabbedItem, buttonInRange;
	private GameObject interButtonInRange;
	private int nbCollisions;
	private string interactiveTag = "Interactive"; //tag for grabbable items (must be defined into the inspector)
	private SphereManipulator SM;

	private float CooldownTimerGrab = 1.0f;


	// Use this for initialization
	void Start () {
		canGrabItem = false;
		isGrabbingItem = false;
		yPos = gameObject.transform.position.y;
		itemInRange = null;
		grabbedItem = null;
		nbCollisions = 0;
		buttonInRange = null;
		SM = GameObject.Find ("Falcon").GetComponent<SphereManipulator>();

		interButtonInRange=null;
	}
	
	// Update is called once per frame
	void Update () {

		CooldownTimerGrab -= Time.deltaTime;
		//Grab items
		//
		//Input.GetMouseButtonDown(0)
		if (SM.button_states[0] && CooldownTimerGrab<=0) 
		{
			GrabItem();
		}
		
		if(!SM.button_states[0] && isGrabbingItem)
		{
			DropItem();
		}
		
		//Right click = click on validation button
		if (SM.button_states[1])
		{
			if(buttonInRange != null)
			{
				Debug.Log("pressing button ");
				checkPlayerAnswer();
			}
			
			if(interButtonInRange!= null)
			{
				if(interButtonInRange.tag=="ValidationButton")
				{
					interButtonInRange.GetComponent<ComputerRiddleCheck>().checkResult();
				}
				else{
					interButtonInRange.GetComponent<ComputerRiddleButton>().press();
				}
			}
			
		}

		
		//if the player is grabbing something, keep the item above him
		if (isGrabbingItem) {
			Quaternion orient;
			FalconRigidBody FalRigidBod = grabbedItem.GetComponent<FalconRigidBody>();
			Vector3 dec ;
			FalconUnity.getDynamicShapePose(FalRigidBod.bodyId,out dec,out orient);
			dec= new Vector3(0,0,0.5f);
			FalconUnity.setDynamicShapePose (FalRigidBod.bodyId, transform.position + dec , orient);
		}
	}
	
	//Verify the answer of the player
	public void checkPlayerAnswer()
	{
		buttonInRange.GetComponent<CheckButtonScript>().push();
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
				putItemAbovePlayer();
				
				isGrabbingItem = true;
				grabbedItem.GetComponent<FalconRigidBody>().isGrabbed=true;
				grabbedItem.GetComponent<FalconRigidBody>().StopFlippinShit();
				//Debug.Log("Grabbing item");
			}
			
			else
			{
				//Debug.Log("nothing to grab");
			}
		}
	}
	
	public void DropItem()
	{
		CooldownTimerGrab = 1.0f;
		if (isGrabbingItem) 
		{
			if(grabbedItem != null)
			{
				Quaternion orient;
				FalconRigidBody FalRigidBod = grabbedItem.GetComponent<FalconRigidBody>();
				Vector3 dec ;
				FalconUnity.getDynamicShapePose(FalRigidBod.bodyId,out dec,out orient);
				dec= new Vector3(0,0,0.5f);
			

				FalconUnity.setDynamicShapePose (FalRigidBod.bodyId, transform.position + dec , orient);


				grabbedItem.transform.parent = null;

				grabbedItem.GetComponent<FalconRigidBody>().DropItem(transform);
				grabbedItem.GetComponent<FalconRigidBody>().LetsFlippinShit();



			//	Vector3 NewPosItem = transform.position;
			//	NewPosItem.z-=10;
			//	grabbedItem.transform.position= NewPosItem;
				//grabbedItem.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward  *1.5f , ForceMode.Impulse);
				isGrabbingItem = false;
				//Debug.Log("Dropping item");
			}
		}
	}
	
	public void putItemAbovePlayer()
	{
		/*Vector3 newPos = gameObject.transform.position +( gameObject.transform.forward * 2 + Vector3.up)/4;
		grabbedItem.transform.position = newPos;*/
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
	
	public void setButtonInRange(GameObject button)
	{
		buttonInRange = button;
	}
	public bool isItGrabbedItem(GameObject go)
	{
		if (grabbedItem == go)
			return true;
		return false;
	}

	//BUTTONS

	

	
	public void setInterracButtonInRange(GameObject button)
	{
		interButtonInRange = button;
	}




}
