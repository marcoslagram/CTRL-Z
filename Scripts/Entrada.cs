using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrada : MonoBehaviour {

    Inventory lista;
    public GameObject jugador;
    public bool palo = false;
    public bool piedra = false;
    public bool clavos = false;
    public bool cuerda = false;

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

            if (lista.myInventory[i].itemName == "Piedra")
            {
                piedra = true;
            }

            if (lista.myInventory[i].itemName == "Clavos")
            {
                clavos = true;
            }

            if (lista.myInventory[i].itemName == "Cuerda")
            {
                cuerda = true;
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Cube" && ((palo && GestionDias.dia==1) || (piedra && GestionDias.dia == 2) || (clavos && GestionDias.dia == 3) || (cuerda && GestionDias.dia == 4)))
        {
            jugador.transform.position = new Vector3(97.34f, -0.1f, 97.18f);
        }
    }
}
