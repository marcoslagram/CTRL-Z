using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour {

    public float tiempo;
    // float tiempomensaje;
    private Scene scene;
    private Inventory invetarioDia;
    private GameObject[] enemigos;
    private bool acaboPartida = false;
    private Economia salud;
    public Image saludH;
    public Image tiempoH;

    DebugText debugg;
	// Use this for initialization
	void Start () {
        enemigos = GameObject.FindGameObjectsWithTag("Zombie");
        tiempo = 300f;
        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
invetarioDia = GameObject.Find("Inventory").GetComponent<Inventory>();
        scene = SceneManager.GetActiveScene();
        salud= GameObject.Find("Enemigo").GetComponent<Economia>();
        //   tiempomensaje = 5f;
    }
	
	// Update is called once per frame
	void Update () {

        saludH.fillAmount = salud.salud / 100f;

        tiempoH.fillAmount = tiempo / 300f;
        //tiempo = SaberTiempo(tiempo);
        tiempo = tiempo - 1 * Time.deltaTime;
       // DialogoNPC.dia++;
        if (tiempo <= 0f)
        {
            /*   tiempomensaje = tiempomensaje - 1 * Time.deltaTime;
               debugg.DebuggingText("Has sobrevivido");
               if (tiempomensaje <= 0)
               {*/
            SceneManager.LoadScene(scene.name);
            // }



        }
    
    /*    else if (Input.GetKeyDown(KeyCode.B))
        {
            GestionDias.dia++;
            Inventory.inventarioEstatico = invetarioDia.myInventory;
            //  Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(scene.name);
        }*/

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            
                Application.Quit();
            

        }

        acaboPartida = true;

        for(int i = 0; i < enemigos.Length; i++)
        {

            if (enemigos[i].activeInHierarchy)
            {
                acaboPartida = false;
                break;
            }

        }


        if (acaboPartida)
        {
            Application.Quit();
        }


        





    }

    public float SaberTiempo(float tiempo)
    {
        return tiempo;
    }
}
