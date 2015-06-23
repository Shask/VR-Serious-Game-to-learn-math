using UnityEngine;
using System.Collections;

/**
 * Script associé aux checkzones
 * */
public class CheckZoneScript : MonoBehaviour {
    public float expectedValue; //Valeur de résultat attendue
    private float inputValue; //Valeur correspondant à une réponse choisie (un cube posé sur la zone)
    private float defaultValue; //valeur par défaut quand aucun input valide
    private bool inputExists;
    private string interactiveTag = "Interactive";
    private int nbInputs; //nombre d'objets posés dans la zone
    private int maxInputs; //nombre d'inputs max, 1
    private GameObject currentInputObject;
	private GameController gamectrl;

	// Use this for initialization
	void Start () {
        inputExists = true;
        maxInputs = 1;
        defaultValue = float.MinValue;
        inputValue = defaultValue; // valeur par défaut
		gamectrl = GameObject.Find ("GameManager").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Verification des valeurs des cubes
     * */
    public void checkAnswer()
    {
      //  Debug.Log("prout");
            if(inputValue != defaultValue)
            {
                if(inputValue == expectedValue)
                {
                    Debug.Log("Succès !");
					gamectrl.FirstStageSucces(true);
                }
        
                else
                {
                    Debug.Log("Echec : Mauvaise valeur !");
					gamectrl.FirstStageSucces(false);
                }
            }

        else
        {
            Debug.Log("Echec : Il faut un cube de reponse");
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        //Regarder si objet dans le trigger = objet interactif (cube de réponse)
        if (col.gameObject.tag == interactiveTag)
        {
            nbInputs++;

            if(nbInputs == maxInputs)
            {
                currentInputObject = col.gameObject;
                inputValue = currentInputObject.GetComponent<CubeValues>().getValue();
                Debug.Log("received a new value : " + inputValue);
            }

            //Si trop d'objets dans la zone de réponse, aucun input accepté
            else
            {
                currentInputObject = null;
                inputValue = float.MinValue;
                Debug.Log("too many values !");
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == interactiveTag)
        {
            nbInputs--;
            if(nbInputs < maxInputs)
            {
                currentInputObject = null;
                inputValue = float.MinValue;
                Debug.Log("input value left the zone");
            }
        }
    }
}
