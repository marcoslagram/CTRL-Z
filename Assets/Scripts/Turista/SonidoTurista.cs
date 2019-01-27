using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoTurista : MonoBehaviour {

    public AudioClip sonidoAndar;
    public AudioClip sonidoCorrer;
    public AudioClip cueva;
    public AudioClip ciudad;

    AudioSource fuenteAudio;
    AudioSource ambienteAudio;

    private PausaTurista pausa;
    private EntradaTurista entrada;

    public bool reproduciendo = false;
    public bool reproduciendoCiudad = false;

    // Use this for initialization
    void Start () {

        fuenteAudio = this.gameObject.GetComponent<AudioSource>();

        ambienteAudio = GameObject.Find("AmbienteCiudad").GetComponent<AudioSource>();

        pausa = GameObject.Find("PausaController").GetComponent<PausaTurista>();
        entrada = GameObject.Find("EntradaCueva").GetComponent<EntradaTurista>();
    }
	
	// Update is called once per frame
	void Update () {

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


        //Ambiente cueva
        if (entrada.dentroCueva)
        {
            reproduciendoCiudad = false;
            if (!reproduciendo)
            {
                ambienteAudio.clip = cueva;
                ambienteAudio.Play();
                reproduciendo = true;
            }

        }

        else
        {
            reproduciendo = false;
            if (!reproduciendoCiudad)
            {
                ambienteAudio.clip = ciudad;
                ambienteAudio.Play();
                reproduciendoCiudad = true;
                
            }
            
        }







        //Pausa activada

        if (pausa.pausaActivada)
        {
            fuenteAudio.Stop();
            fuenteAudio.clip = null;
        }

    }
}
