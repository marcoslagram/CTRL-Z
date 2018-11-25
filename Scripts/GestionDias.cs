using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDias : MonoBehaviour {

    
    public static int dia = 1;

    private Inventory inventarioDia;

    public static bool respuesta = false;

	// Use this for initialization
	void Start () {

        inventarioDia = GameObject.Find("Inventory").GetComponent<Inventory>();

        if (dia == 1)
        {
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);

            inventarioDia.usosControl = 2;
            

        }

        if (dia == 2)
        {
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);

            GameObject.Find("LataConserva").transform.position = new Vector3(91.2f, 0.894f, 0.5f);
            GameObject.Find("Tarta").transform.position = new Vector3(20.7f, 0.894f, -59.4f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(-14.6f, 0.5f, 129f);

            if (respuesta)
            {
                inventarioDia.usosControl=0;
            }

            else
            {
                inventarioDia.usosControl = 1;
            }

            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl++;
            }

            inventarioDia.myInventory = Inventory.inventarioEstatico;
        }

        if (dia == 3)
        {
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);


            GameObject.Find("LataConserva").transform.position = new Vector3(-52.7f, 0.894f, -43.1f);
            GameObject.Find("Tarta").transform.position = new Vector3(-45f, 0.5f, 145.3f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(100.74f, 0.894f, -44f);

            if (respuesta)
            {
                inventarioDia.usosControl = 1;
            }

            else
            {
                
            }


            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl++;
            }

            inventarioDia.myInventory = Inventory.inventarioEstatico;
        }

        if (dia == 4)
        {
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);

            GameObject.Find("LataConserva").transform.position = new Vector3(-58.8f, 0.5f, 67.4f);
            GameObject.Find("Tarta").transform.position = new Vector3(120.5f, 0.894f, 25.4f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(-81.1f, 0.894f, -23.8f);

            if (respuesta)
            {
               
            }

            else
            {
                inventarioDia.usosControl = 1;
            }




            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl++;
            }

            inventarioDia.myInventory = Inventory.inventarioEstatico;

        }
        
        
        if (dia == 5)
        {
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            

            GameObject.Find("LataConserva").transform.position = new Vector3(133.3f, 0.894f, -85.2f);
            GameObject.Find("Tarta").transform.position = new Vector3(-73.8f, 0.894f, -89.6f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(103.5f, 0.5f, 157.7f);

            if (respuesta)
            {
               
            }

            else
            {
                inventarioDia.usosControl = 1;
            }




            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl++;
            }

            inventarioDia.myInventory = Inventory.inventarioEstatico;
        }
    }
	
	/*// Update is called once per frame
	void Update () {
        
	}*/
}
