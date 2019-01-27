using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesTurista : MonoBehaviour {

    private Animator animaciones;


    private PausaTurista pausa;

    // Use this for initialization
    void Start()
    {
        animaciones = this.transform.GetChild(1).gameObject.GetComponent<Animator>();

        pausa = GameObject.Find("PausaController").GetComponent<PausaTurista>();
  
    }

    // Update is called once per frame
    void Update()
    {

        //Movimiento
        if ((Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) && (!Input.GetButton("Correr")) && !pausa.pausaActivada)
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


        else if (Input.GetButton("Correr") && (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0) && !pausa.pausaActivada)
        {
            animaciones.SetInteger("correr", 1);
            animaciones.SetInteger("caminar", 0);
            animaciones.SetInteger("moverse", 1);
        }






        else
        {
            animaciones.SetInteger("moverse", 0);
            animaciones.SetInteger("correr", 0);
            animaciones.SetInteger("caminar", 0);
            animaciones.SetInteger("saltar", 0);
        }
        

    }
}
