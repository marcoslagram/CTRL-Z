using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDias : MonoBehaviour {

    public PlayerController carga;
    public PlayerController guarda;

    private ControladorDatosDisco guardado;
    //public PrefsController cargaPrefs;
    
    public static int dia = 1;

    private Inventory inventarioDia;

    public static bool respuesta = false;

    public static int cantidadControlZ;
	// Use this for initialization
	void Start () {

        inventarioDia = GameObject.Find("Inventory").GetComponent<Inventory>();
        guardado = GameObject.Find("ControllerGameData").GetComponent<ControladorDatosDisco>();


        if(Menu.continuar == true)
        {
            guardado.LoadPlayerDataFromDisk();
            //carga.LoadPlayerDataFromDisk();
                        //cargaPrefs.LoadPreferencesFromDisk();
        }

        if (dia == 1)
        {
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);

            inventarioDia.usosControl = 2;
            //  guarda.SavePlayerDataToDisk();

            guardado.SaveDatosDisco();
        }

        if (dia == 2)
        {

            /*if (Menu.continuar == true)
            {

               
                //carga.LoadPlayerDataFromDisk();
                //cargaPrefs.LoadPreferencesFromDisk();
            }*/
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);

            GameObject.Find("LataConserva").transform.position = new Vector3(91.2f, 0f, 0.5f);
            GameObject.Find("Tarta").transform.position = new Vector3(20.7f, 0.5f, -53.9f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(-14.6f, 0.5f, 129f);
            GameObject.Find("Radio").transform.position = new Vector3(1.887f, 3.79f,2.29f);

            if (respuesta)
            {
                inventarioDia.usosControl=0;
            }

            else
            {
            
                inventarioDia.usosControl = cantidadControlZ-1;

                if (inventarioDia.usosControl < 0)
                {
                    inventarioDia.usosControl = 0;
                }
               
                
            }

            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl = Salida.cantidad + inventarioDia.usosControl;
            }


            inventarioDia.myInventory = new List<Items>();

            for (int i = 0; i < Inventory.inventarioEstatico.Count; i++)
            {
                inventarioDia.myInventory.Add(Inventory.inventarioEstatico[i]);
            }
            //inventarioDia.myInventory = Inventory.inventarioEstatico;



            //Guardar aquí
            guardado.SaveDatosDisco();


            DialogoNPC.conversacionGatoTerminada = false;
           // Salida.usosMas = false;
           // Salida.cantidad = 0;
          //  guarda.SavePlayerDataToDisk();
        }

        if (dia == 3)
        {
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);


            GameObject.Find("LataConserva").transform.position = new Vector3(-52.7f, 0f, -50.1f);
            GameObject.Find("Tarta").transform.position = new Vector3(4.432f, 3.79f, -1.927f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(100.74f, 0.894f, -44f);
            GameObject.Find("Radio").transform.position = new Vector3(-45f, 0.5f, 145.3f);

            if (respuesta)
            {
                inventarioDia.usosControl = cantidadControlZ - 1;

                if (inventarioDia.usosControl < 0)
                {
                    inventarioDia.usosControl = 0;
                }
                
            }

            else
            {
                inventarioDia.usosControl = cantidadControlZ + 2;
                
            }


            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl += Salida.cantidad;
            }

            inventarioDia.myInventory = new List<Items>();

            for (int i = 0; i < Inventory.inventarioEstatico.Count; i++)
            {
                inventarioDia.myInventory.Add(Inventory.inventarioEstatico[i]);
            }

          //  inventarioDia.myInventory = Inventory.inventarioEstatico;
            guardado.SaveDatosDisco();
            DialogoNPC.conversacionGatoTerminada = false;
            //Salida.usosMas = false;
            //Salida.cantidad = 0;
           // guarda.SavePlayerDataToDisk();
        }

        if (dia == 4)
        {
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Hacha").SetActive(false);

            GameObject.Find("LataConserva").transform.position = new Vector3(2.78f, 4.626f,-1.927f);
            GameObject.Find("Tarta").transform.position = new Vector3(120.5f, 0.894f, 25.4f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(121.4f, 0.5f, -117.5f);
            GameObject.Find("Radio").transform.position = new Vector3(-51.9f, 0.5f, 51f);
            if (respuesta)
            {
               

                inventarioDia.usosControl = cantidadControlZ - 1;

                if (inventarioDia.usosControl < 0)
                {
                    inventarioDia.usosControl = 0;
                }
            }

            else
            {
                inventarioDia.usosControl = cantidadControlZ - 2;

                if (inventarioDia.usosControl < 0)
                {
                    inventarioDia.usosControl = 0;
                }
               
            }




            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl+=Salida.cantidad;
            }


            inventarioDia.myInventory = new List<Items>();

            for (int i = 0; i < Inventory.inventarioEstatico.Count; i++)
            {
                inventarioDia.myInventory.Add(Inventory.inventarioEstatico[i]);
            }

            // inventarioDia.myInventory = Inventory.inventarioEstatico;
            guardado.SaveDatosDisco();
            DialogoNPC.conversacionGatoTerminada = false;
           // Salida.usosMas = false;
           // Salida.cantidad = 0;
         //   guarda.SavePlayerDataToDisk();
        }
        
        
        if (dia == 5)
        {
            GameObject.Find("Palo").SetActive(false);
            GameObject.Find("Piedra").SetActive(false);
            GameObject.Find("Cuerda").SetActive(false);
            GameObject.Find("Clavos").SetActive(false);
            

            GameObject.Find("LataConserva").transform.position = new Vector3(63.6f, 0f, -130.2f);
            GameObject.Find("Tarta").transform.position = new Vector3(-50f, 0.5f, 126.2f);
            GameObject.Find("PiedraEspecial").transform.position = new Vector3(1.508f, 0.5f, -11.78f);
            GameObject.Find("Radio").transform.position = new Vector3(103f, 0.5f, 120.4f);

            if (respuesta)
            {
                
                inventarioDia.usosControl = cantidadControlZ + 2;

                if (inventarioDia.usosControl < 0)
                {
                    inventarioDia.usosControl = 0;
                }
            }

            else
            {
                

                inventarioDia.usosControl = cantidadControlZ - 1;

                if (inventarioDia.usosControl < 0)
                {
                    inventarioDia.usosControl = 0;
                }
            }




            if (Salida.usosMas == true)
            {
                inventarioDia.usosControl += Salida.cantidad;
            }

            inventarioDia.myInventory = new List<Items>();

            for (int i = 0; i < Inventory.inventarioEstatico.Count; i++)
            {
                inventarioDia.myInventory.Add(Inventory.inventarioEstatico[i]);
            }

            // inventarioDia.myInventory = Inventory.inventarioEstatico;
            guardado.SaveDatosDisco();

           // Salida.usosMas = false;
           // Salida.cantidad = 0;
          //  guarda.SavePlayerDataToDisk();
        }
        Menu.continuar = false;
    }
	
	/*// Update is called once per frame
	void Update () {
        
	}*/
}
