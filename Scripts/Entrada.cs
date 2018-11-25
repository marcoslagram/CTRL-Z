using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrada : MonoBehaviour {

    Inventory lista;
    public GameObject jugador;
    public bool palo = false;
	// Use this for initialization
	void Start () {
        lista = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < lista.myInventory.Count; i++)
        {

            if (lista.myInventory[i].itemName == "Palo")
            {
                palo = true;
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Cube" && (palo && GestionDias.dia==1) )
        {
            jugador.transform.position = new Vector3(97.34f, -0.1f, 97.18f);
        }
    }
}
