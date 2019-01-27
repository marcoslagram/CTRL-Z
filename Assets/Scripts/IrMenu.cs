using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrMenu : MonoBehaviour {

    private Scene scene;

    private Inventory invetarioDia;

    // Use this for initialization
    void Start () {

        scene = SceneManager.GetActiveScene();
        invetarioDia = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {

      /*  if (Input.GetKeyDown(KeyCode.B))
        {
            GestionDias.dia++;
            Inventory.inventarioEstatico = invetarioDia.myInventory;
            //  Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(scene.name);
        }*/

       if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("Menu");
            //  Application.Quit();


        }

    }
}
