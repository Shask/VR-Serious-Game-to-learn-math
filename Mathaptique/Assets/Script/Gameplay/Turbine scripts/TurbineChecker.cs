using UnityEngine;
using System.Collections;

/**
 * Checker pour valider les conditions pour les turbines (les indicators sont tous valides)
 * */
public class TurbineChecker : MonoBehaviour {

    private bool allValid;
    private Color originalColor;
    private int numberOfValidators; //nombre d'objets (indicators) qui doivent servir à valider la condition finale

	private GameController gameController;
	public GameObject[] ListBoxResult;

	public GameObject[] ListFan;
	

	// Use this for initialization
	void Start () {
        allValid = false;
		numberOfValidators = 4; 
		if (ListBoxResult == null)
			ListBoxResult = GameObject.FindGameObjectsWithTag("ResultBoxFan");
		gameController= GameObject.Find ("GameManager").GetComponent<GameController> ();
		ListFan = GameObject.FindGameObjectsWithTag("Fan");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!allValid)
        checkAllIndicators();
	
	}

    /**
     * Verifier si tous les indicators ont leur booléen valide à vrai
     * */
    public void checkAllIndicators()
    {
        int currentValidIndicators = 0;
       /* foreach (Transform child in transform)
        {
            if(child.gameObject.GetComponent<IndicatorTrigger>().getIsValid())
            {
                currentValidIndicators++;     
            }         
        }*/
		foreach (GameObject BoxResult1 in ListBoxResult) {
			if(BoxResult1.GetComponent<IndicatorTrigger>().getIsValid())
				currentValidIndicators++; 
		}

	

        if(currentValidIndicators == numberOfValidators)
        {
            allValid = true;
            //gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
			gameController.FourthStageSucces(true);
            Debug.Log("All conditions are OK");
			succededLevel();
        }


        else
        {
            allValid = false;
            
        }
    }
	public void succededLevel()
	{
		foreach (GameObject Fan in ListFan) {
			Animation FanAnim;
			FanAnim = Fan.GetComponent<Animation> ();
			foreach (AnimationState state in FanAnim) {
				state.speed = 20F;
			}
			FanAnim.Play ();

			for(int i=0; i< Fan.transform.childCount; i++)
			{
				GameObject child = Fan.transform.GetChild(i).gameObject;
				if(child != null)
					child.SetActive(false);
			} 

		}
	}
}
