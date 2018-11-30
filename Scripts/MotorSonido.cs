using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSonido : MonoBehaviour
{
    public AudioClip sonidoAndar;
    public AudioClip sonidoAterrizar;
    public AudioClip sonidoCorrer;

    AudioSource fuenteAudio;

    //bool enSuelo;

    //public float Volumen = 1.0f;
    //public Transform Posicion = null;

    //MovimientoJugador andar;
    //MovimientoJugador correr;
    //Saltar salto;


    // Use this for initialization
    void Start()
    {
        //Posicion = transform;
        fuenteAudio = GetComponent<AudioSource>();

        //MovimientoJugador andar = GetComponent<MovimientoJugador>();
        //MovimientoJugador correr = GetComponent<MovimientoJugador>();
        //Saltar salto = GetComponent<Saltar>();

    }

    /* void OnCollisionEnter(Collision collision)
     {
         if (sonidoAterrizar) AudioSource.PlayClipAtPoint(sonidoAterrizar, Posicion.position, Volumen);
     }*/


    // Update is called once per frame
    void Update()

    //podria entrar en los ifs tambien cuando se activen las animaciones
    {

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)  //FUNCIONA
        {
            if ((!fuenteAudio.isPlaying) && (fuenteAudio.clip != sonidoAndar))
            {
                fuenteAudio.clip = sonidoAndar;
                fuenteAudio.Play();

            }
        }
        else if ((fuenteAudio.isPlaying) && (fuenteAudio.clip == sonidoAndar))
        {
            fuenteAudio.Stop();
            fuenteAudio.clip = null;
        }

        //SALTO
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //if ((!fuenteAudio.isPlaying) && (fuenteAudio.clip != sonidoAterrizar))
            //{
            fuenteAudio.clip = sonidoAterrizar;
            fuenteAudio.Play();
            //}
        }
        /*if((fuenteAudio.isPlaying) && (fuenteAudio.clip == sonidoAterrizar))
            {
                fuenteAudio.Stop();
                fuenteAudio.clip = null;
          
            }*/
        //ARREGLADO



        //Correr
        if (Input.GetButton("Correr")) //FUNCIONA
        {
            if ((!fuenteAudio.isPlaying) && (fuenteAudio.clip != sonidoCorrer))
            {
                Debug.Log("111");
                fuenteAudio.clip = sonidoCorrer;
                fuenteAudio.Play();
            }
        }
        else if ((fuenteAudio.isPlaying) && (fuenteAudio.clip == sonidoCorrer))
        {
            fuenteAudio.Stop();
            fuenteAudio.clip = null;
        }
    }

}
