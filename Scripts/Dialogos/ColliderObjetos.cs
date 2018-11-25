using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObjetos : MonoBehaviour {


    public bool colliderLata = false;
    public bool dentroColl = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name == "LataConserva")
        {

            Debug.Log("1");
            colliderLata = false;
            dentroColl=false;
           // Debug.Log(dentroColl);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.name == "LataConserva")
        {
          //  Debug.Log("3");
            colliderLata = true;
            dentroColl = true;
        }
    }
}
