using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour {

    // public GameObject jugador;
    private Scene scene;

    private Inventory invetarioDia;

    public static bool usosMas = false;

   
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        invetarioDia = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(Inventory.inventarioEstatico.Count + " 1");
    //    Debug.Log(invetarioDia.myInventory.Count + " 2");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Cube" && DialogoNPC.conversacionGatoTerminada)
        {
            for (int i = 0;i< invetarioDia.myInventory.Count; i++)
            {
                if (invetarioDia.myInventory[i].itemName.ToString() == "LataConserva")
                {
                    usosMas = true;
                }
                else
                {
                    usosMas = false;
                }
            }
            GestionDias.dia++;
            Inventory.inventarioEstatico = invetarioDia.myInventory;
            //  Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(scene.name);
        }
    }
}
