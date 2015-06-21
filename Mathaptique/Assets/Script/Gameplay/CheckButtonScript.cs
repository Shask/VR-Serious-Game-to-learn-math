using UnityEngine;
using System.Collections;

/**
 * Script gérant la detection du joueur et l'appui sur le bouton de validation d'une question
 * */
public class CheckButtonScript : MonoBehaviour {
    private Color defaultColor, rangedColor;
    private bool playerInRange;
    private bool buttonPressed;
    public GameObject checkZone; //checkzone matching this button

	// Use this for initialization
	void Start () {
        defaultColor = gameObject.GetComponent<Renderer>().material.color;
        rangedColor = new Color(0, 255, 0);
        playerInRange = false;
        buttonPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void push()
    {
        if(checkZone != null)
        {
            checkZone.GetComponent<CheckZoneScript>().checkAnswer();
            //gameObject.GetComponent<Animator>().Play("button_pushed");
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            playerInRange = true;
            col.gameObject.GetComponent<Player>().setButtonInRange(this.gameObject);
            gameObject.GetComponent<Renderer>().material.color = rangedColor;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            playerInRange = false;
            col.gameObject.GetComponent<Player>().setButtonInRange(null);
            gameObject.GetComponent<Renderer>().material.color = defaultColor;
        }
    }

    public bool getPlayerInRange()
    {
        return playerInRange;
    }

    public bool getButtonPressed()
    {
        return buttonPressed;
    }
}
