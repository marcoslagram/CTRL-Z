using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour {

    private Animator animaciones;


    private Inventory inventario;
    // Use this for initialization
    void Start () {
        animaciones = this.transform.GetChild(1).gameObject.GetComponent<Animator>();
        inventario = GameObject.Find("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        
        //Movimiento
        if ((Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) && (!Input.GetButton("Correr") || inventario.correr == false))
        {
            animaciones.SetInteger("caminar", 1);
            animaciones.SetInteger("moverse", 1);
            animaciones.SetInteger("correr", 0);
            Debug.Log("Puls");
        }


     /*   else if (Input.GetButton("Correr") && (Input.GetAxis("Vertical") < 0 ||  Input.GetAxis("Horizontal") < 0))
        {
            animaciones.SetInteger("correr", 2);
            animaciones.SetInteger("caminar", 0);
            animaciones.SetInteger("moverse", 1);
        }*/


        else if(Input.GetButton("Correr") && (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0) && inventario.correr==true)
        {
            animaciones.SetInteger("correr", 1);
            animaciones.SetInteger("caminar", 0);
            animaciones.SetInteger("moverse", 1);
        }

       
        else if (Input.GetButton("Jump"))
        {
            animaciones.SetInteger("saltar", 1);
            animaciones.SetInteger("caminar", 0);
            animaciones.SetInteger("moverse", 1);
            animaciones.SetInteger("correr", 0);
        }




        else
        {
            animaciones.SetInteger("moverse", 0);
            animaciones.SetInteger("correr", 0);
            animaciones.SetInteger("caminar", 0);
            animaciones.SetInteger("saltar", 0);
        }



        //Objetos

        /* if (inventario.recoger == true && Input.GetKey(KeyCode.E))
         {
             animaciones.SetInteger("objeto", 1);
             animaciones.SetInteger("recoger", 1);

         }
         
        if (inventario.tirarRadio == true)
        {
            animaciones.SetInteger("objeto", 1);
            animaciones.SetInteger("tirar", 1);
        }*/

        if (inventario.recoger == true)
        {
            animaciones.SetInteger("objeto", 1);
            if (Input.GetKey(KeyCode.E))
            {
                animaciones.SetInteger("recoger", 1);
            }

            else if(inventario.tirarRadio == true)
            {
                animaciones.SetInteger("tirar", 1);
            }

            else if (inventario.consumirObjeto == true)
            {
                animaciones.SetInteger("consumir", 1);
            }

            else
            {
                animaciones.SetInteger("objeto", 0);
            }
        }

        else
        {
            animaciones.SetInteger("objeto", 0);
            animaciones.SetInteger("recoger", 0);
            animaciones.SetInteger("consumir", 0);
            animaciones.SetInteger("tirar", 0);
        }



        //atacar

       if(Input.GetKeyDown(KeyCode.Mouse0) && GestionDias.dia == 5)
        {
            animaciones.SetInteger("atacar", 1);
        }


        else
        {
            animaciones.SetInteger("atacar", 0);
        }

	}
    /*
    private void col(Collider other)
    {
        
    }*/

   /* private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Escalera")
        {
            //animaciones.SetInteger("subir", 1);
        }
    }
    */
}
