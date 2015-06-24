using UnityEngine;
using System.Collections;

/**
 * Checker pour valider les conditions pour les turbines (les indicators sont tous valides)
 * */
public class TurbineChecker : MonoBehaviour {

    private bool allValid;
    private Color originalColor;
    private int numberOfValidators; //nombre d'objets (indicators) qui doivent servir à valider la condition finale

	// Use this for initialization
	void Start () {
        allValid = false;
        originalColor = new Color(255, 0, 0);
        foreach (Transform child in transform)
        {
            numberOfValidators++; //les indicateurs doivent être enfants de cet objet, on les compte
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        checkAllIndicators();
	
	}

    /**
     * Verifier si tous les indicators ont leur booléen valide à vrai
     * */
    public void checkAllIndicators()
    {
        int currentValidIndicators = 0;
        foreach (Transform child in transform)
        {
            if(child.gameObject.GetComponent<IndicatorTrigger>().getIsValid())
            {
                currentValidIndicators++;     
            }         
        }

        if(currentValidIndicators == numberOfValidators)
        {
            allValid = true;
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            Debug.Log("All conditions are OK");
        }


        else
        {
            allValid = false;
            if (gameObject.GetComponent<Renderer>().material.color != originalColor)
            {
                gameObject.GetComponent<Renderer>().material.color = originalColor;
            }
        }
    }
}
