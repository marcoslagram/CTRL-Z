using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSonido : MonoBehaviour
{
    public AudioClip sonidoAndar;
    public AudioClip sonidoAterrizar;
    public AudioClip sonidoCorrer;

    AudioSource fuenteAudio;

    MovimientoJugador andar;
    MovimientoJugador correr;
    Saltar salto;

    // Use this for initialization
    void Start()
    {

        fuenteAudio = GetComponent<AudioSource>();

        MovimientoJugador andar = GetComponent<MovimientoJugador>();
        //MovimientoJugador correr = GetComponent<MovimientoJugador>();
        Saltar salto = GetComponent<Saltar>();

    }

    // Update is called once per frame
    void Update()

    //podria entrar en los ifs tambien cuando se activen las animaciones
    {
        //if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)))//prueba con 0, aqui deberia ser if(se esta desplazando) -> ...
        //if(andar.GetComponent<MovimientoJugador>().DesplazamientoNormal())
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0 )
        {
            fuenteAudio.clip = sonidoAndar;
            fuenteAudio.Play();
        }
        else
        {
            fuenteAudio.Stop();
        }
        //if(salto.tocaSuelo == true)

        //if (Input.GetKey(KeyCode.Alpha1)) //prueba con 1, aqui deberia ser if(tocaSuelo==true) de la clase saltar -> ...
        if (gameObject.CompareTag("Terrain"))
        {
            fuenteAudio.clip = sonidoAterrizar;
            fuenteAudio.Play();
        }

        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && Input.GetButton("Correr")) //prueba con 2, aqui deberia ser if(corre) -> ...
        {
            Debug.Log("111");
            fuenteAudio.clip = sonidoCorrer;
            fuenteAudio.Play();
        }
    }

}
