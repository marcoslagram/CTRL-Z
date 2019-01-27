using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesZombie : MonoBehaviour
{


    private Animator animaciones;

    private Atacar ataque;

    private float distancia=0f;

    // Use this for initialization
    void Start()
    {
        animaciones = this.gameObject.GetComponent<Animator>();
        ataque = GameObject.Find("Cube").GetComponent<Atacar>();
    }

    // Update is called once per frame
    void Update()
    {

        /*
        for (int i = 0; i < enemigos.Length; i++)
        {
            float distancia = Vector3.Distance(enemigos[i].transform.position, GameObject.Find("Cube").transform.position);
            // Debug.Log(distancia);
            if (distancia >= 10.7f && distancia <= 11.5f)
            {
                dentro = true;
            }
            if (distancia >= 0f && distancia <= 10.7f)
            {
                //  Debug.Log("11111");
           
            }




        }
        */


        //Recibir

       if (ataque.recibirDa)
           {
               animaciones.SetBool("recibir", true);
               animaciones.SetBool("movimiento", false);
               animaciones.SetBool("atacar", false);
        }

       
        /*     else
           {
               animaciones.SetBool("recibir", false);
               animaciones.SetBool("movimiento", true);
           }*/

    }

    //Atacar
    void OnTriggerStay(Collider other)
    {

        
    if (other.gameObject.transform.name == "Cube" && !ataque.recibirDa)
        {
            animaciones.SetBool("movimiento", false);
            animaciones.SetBool("atacar", true);
            

        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name == "Cube")
        {

            animaciones.SetBool("atacar", false);
            animaciones.SetBool("movimiento", true);
        }

    }/**/




}