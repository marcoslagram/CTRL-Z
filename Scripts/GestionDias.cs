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
                inventarioDia.usosControl += Salida.cantidad;
            }

            inventarioDia.myInventory = Inventory.inventarioEstatico;

            DialogoNPC.conversacionGatoTerminada = false;
            Salida.usosMas = false;
            Salida.cantidad = 0;
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
                inventarioDia.usosControl += Salida.cantidad;
            }

            inventarioDia.myInventory = Inventory.inventarioEstatico;

            DialogoNPC.conversacionGatoTerminada = false;
            Salida.usosMas = false;
            Salida.cantidad = 0;
        }

        if (dia == 4)
        {
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);

            GameObject.Find("LataConserva").transform.position = new Vector3(-51.9f, 0.5f, 51f);
            GameObject.Find("Tarta").transform.position = new Vector3(120.5f, 0.894f, 25.4f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(121.4f, 0.5f, -117.5f);

            if (respuesta)
            {
               
            }

            else
            {
                inventarioDia.usosControl = 1;
            }




            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl+=Salida.cantidad;
            }

            inventarioDia.myInventory = Inventory.inventarioEstatico;

            DialogoNPC.conversacionGatoTerminada = false;
            Salida.usosMas = false;
            Salida.cantidad = 0;
        }
        
        
        if (dia == 5)
        {
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            

            GameObject.Find("LataConserva").transform.position = new Vector3(63.6f, 0.894f, -130.2f);
            GameObject.Find("Tarta").transform.position = new Vector3(-50f, 0.5f, 126.2f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(103f, 0.5f, 120.4f);

            if (respuesta)
            {
               
            }

            else
            {
                inventarioDia.usosControl = 1;
            }




            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl += Salida.cantidad;
            }

            inventarioDia.myInventory = Inventory.inventarioEstatico;
            Salida.usosMas = false;
            Salida.cantidad = 0;
        }
    }
	
	/*// Update is called once per frame
	void Update () {
        
	}*/
}
