using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaDistractor : MonoBehaviour {

    public GameObject ObjetoDistractor;
    public Transform PosicionDistractor;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Instantiate(ObjetoDistractor, PosicionDistractor);
        }
	}
}
