using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSonido : MonoBehaviour {
    public AudioClip sonidoAndar;
    public AudioClip sonidoCorrer;
    public AudioClip controlZ;

    AudioSource fuenteAudio;

   
    


    // Use this for initialization
    void Start()
    {

        //Posicion = transform;
        fuenteAudio = this.gameObject.GetComponent<AudioSource>();
        

        /*  if(tiempo.tiempo<299.5f || GestionDias.dia > 1)
          {

          }*/

    }




    // Update is called once per frame
    void Update()

    {
        /* if (tiempo.tiempo < 299.5f && GestionDias.dia == 1)
         {
             control = GameObject.Find("Player").GetComponent<AudioSource>();
         }*/
        //enemigos = GameObject.FindGameObjectsWithTag("Zombie");

/*
        //Andar
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !Input.GetButton("Correr"))  //FUNCIONA
        {
            if ((!fuenteAudio.isPlaying))//) && (fuenteAudio.clip != sonidoAndar)
            {
                fuenteAudio.clip = sonidoAndar;
                fuenteAudio.Play();

            }

            else if ((fuenteAudio.isPlaying) && (fuenteAudio.clip != sonidoAndar))
            {
                fuenteAudio.clip = sonidoAndar;
                fuenteAudio.Play();
            }



        }




        //Correr
        else if (Input.GetButton("Correr") && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)) //FUNCIONA
        {
            if ((!fuenteAudio.isPlaying))//&& (fuenteAudio.clip != sonidoCorrer)
            {
                //
                fuenteAudio.clip = sonidoCorrer;
                fuenteAudio.Play();
            }


            else if ((fuenteAudio.isPlaying) && (fuenteAudio.clip != sonidoCorrer))
            {
                fuenteAudio.clip = sonidoCorrer;
                fuenteAudio.Play();
            }
        }

        else
        {
            fuenteAudio.Stop();
            fuenteAudio.clip = null;

        }



        if (usoCtrl.usoControl)
        {
            control.PlayOneShot(controlZ);
            usoCtrl.usoControl = false;
        }






        //Pausa activada

        if (saberPausa.pausaActiva)
        {

            fuenteAudio.Stop();
            fuenteAudio.clip = null;
        }
        */




    }
}
