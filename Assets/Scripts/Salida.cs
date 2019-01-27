using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour {

    // public GameObject jugador;
    private Scene scene;

    private Inventory invetarioDia;
    private Tiempo tiempo;

    public static bool usosMas = false;
    public static int cantidad = 0;
    public static float tiempoRestante=0f;
    
    private DebugText debugg;


    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        invetarioDia = GameObject.Find("Inventory").GetComponent<Inventory>();
        tiempo = GameObject.Find("Player").GetComponent<Tiempo>();

        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(GestionDias.respuesta);
      //  Debug.Log(Inventory.inventarioEstatico.Count + " 1");
    //    Debug.Log(invetarioDia.myInventory.Count + " 2");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Cube" && DialogoNPC.conversacionGatoTerminada)
        {
            usosMas = false;

            for (int i = 0;i< invetarioDia.myInventory.Count; i++)
            {
                if (invetarioDia.myInventory[i].itemName.ToString() == "LataConserva"  || invetarioDia.myInventory[i].itemName.ToString() == "LataConserva(Clone)")
                {
                    
                    usosMas = true;
                    cantidad = invetarioDia.myInventory[i].cantidad;
                    invetarioDia.myInventory[i].cantidad = 0;
                    invetarioDia.myInventory.Remove(invetarioDia.myInventory[i]);
                }
             
            }
            GestionDias.dia++;

            Inventory.inventarioEstatico = new List<Items>();

            for (int i = 0; i < invetarioDia.myInventory.Count; i++)
            {
                Inventory.inventarioEstatico.Add(invetarioDia.myInventory[i]);
            }
          //  Inventory.inventarioEstatico = invetarioDia.myInventory;
            
            //  Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(scene.name);
        }

        else if (other.gameObject.transform.name == "Cube")
        {
            debugg.DebuggingText("Habla primero con el gato");
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name == "Cube")
        {
            debugg.DebuggingText("");
        }
    }

}
