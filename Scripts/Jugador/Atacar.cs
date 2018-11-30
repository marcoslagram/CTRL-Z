using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : Interactable
{
    public GameObject[] enemy;
    public GameObject player;

    private DebugText debugg;
    private bool compro;
    private int s;
    private int saludEnemigo;

    public int salud;

    // Use this for initialization
    void Start()
    {

        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
        player = GameObject.Find("Cube");
        enemy = GameObject.FindGameObjectsWithTag("Zombie");
        saludEnemigo = 100;

    }

    // Update is called once per frame
    void Update()
    {
        compro = false;

        /*float distancia = Vector3.Distance(enemy.transform.position, player.transform.position);
        
        if (distancia <= maxdistance)
        {
            
            debugg.DebuggingText("Puedes matar al enemigo");
            s = 0;
            compro = true;

            if (Input.GetKeyDown(KeyCode.Mouse0))         //Input.GetMouseButton(0), con esto no funciona
             {
                saludEnemigo = saludEnemigo - 25;
                if (saludEnemigo == 0) {

                    enemy.SetActive(false);
                 }

             }
        }
       

        if (compro == false && s == 0)
        {
            debugg.DebuggingText("");
            compro = false;
            s++;
        }

    }*/

        for (int i = 0; i < enemy.Length; i++)
        {

            if (enemy[i] == null)
            {

                continue;
            }
            

            //Distancia del jugador al objecto
            float distancia = Vector3.Distance(enemy[i].transform.position, GameObject.Find("Cube").transform.position);

            //Si es menor que la máxima distancia de interaccion puede interactuar

            if (distancia <= maxdistance)
            {
                //mensaje debug
                debugg.DebuggingText("Puede matar Zombie");
                s = 0;
                compro = true;


                if (Input.GetKeyDown(KeyCode.Mouse0) && GestionDias.dia==5)         //Input.GetMouseButton(0), con esto no funciona
                {
                    saludEnemigo = saludEnemigo - 25;
                    if (saludEnemigo == 0)
                    {
                       // Destroy(enemy[i]);
                        enemy[i].SetActive(false);
                        saludEnemigo = 100;
                    }

                }
            }

        }

        if (compro == false && s == 0)
        {
            debugg.DebuggingText("");
            s++;
        }





    }

}