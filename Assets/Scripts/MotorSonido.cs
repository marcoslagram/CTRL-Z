using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSonido : MonoBehaviour
{
    public AudioClip sonidoAndar;
    public AudioClip sonidoCorrer;
    public AudioClip controlZ;
    public AudioClip abrirInven;
    public AudioClip selItem;
    public AudioClip come;
    public AudioClip radioSoni;
    public AudioClip perder;
    public AudioClip pegar;
    public AudioClip danoZ;
    public AudioClip recogerObjeto;
    public AudioClip cueva;


    AudioSource fuenteAudio;

    AudioSource control;

    AudioSource invent;

    AudioSource radio;
    AudioSource radio2;

    AudioSource vida;
    AudioSource recibirZ;

    AudioSource ambienteAudio;

    private Pausa saberPausa;
    private Control usoCtrl;
    private Tiempo tiempo;
    private Inventory inventario;
    private Atacar atacar;
    private Entrada entrada;

    private int x = 0;
    public GameObject distractor;
    public GameObject distractor2;

    private float tiempoSonido = 0f;
    private float tiempoSonido2 = 0f;

    public bool perdiendo = false;
    public bool reproduciendo = false;
    //private GameObject[] enemigos;
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
        fuenteAudio = this.gameObject.GetComponent<AudioSource>();
        invent = GameObject.Find("Inventory").GetComponent<AudioSource>();
        control = GameObject.Find("Player").GetComponent<AudioSource>();
        vida = GameObject.Find("chica 2").GetComponent<AudioSource>();
        recibirZ = GameObject.Find("PegarZ").GetComponent<AudioSource>();
        ambienteAudio = GameObject.Find("AmbienteCiudad").GetComponent<AudioSource>();
        radio = distractor.GetComponent<AudioSource>();
       // radio2 = distractor2.GetComponent<AudioSource>();
        usoCtrl = GameObject.Find("Player").GetComponent<Control>();
        tiempo = GameObject.Find("Player").GetComponent<Tiempo>();
        saberPausa = GameObject.Find("PausaController").GetComponent<Pausa>();
        inventario = GameObject.Find("Inventory").GetComponent<Inventory>();
        atacar = GameObject.Find("Cube").GetComponent<Atacar>();
        entrada = GameObject.Find("EntradaCueva").GetComponent<Entrada>();

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


        //Andar
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && (!Input.GetButton("Correr") || !inventario.correr))  //FUNCIONA
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
        else if (Input.GetButton("Correr") && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && inventario.correr) //FUNCIONA
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


        //Control
        if (usoCtrl.usoControl)
        {
            control.PlayOneShot(controlZ);
            usoCtrl.usoControl = false;
        }

        //Inventario


        if (inventario.recogerOb || invent.isPlaying)
        {
            if ((!invent.isPlaying))//&& (fuenteAudio.clip != sonidoCorrer)
            {
                inventario.recogerOb = false;
                invent.clip = recogerObjeto;
                invent.Play();
            }
        }


        if (inventario.inventAbierto || invent.isPlaying)
        {
            if ((!invent.isPlaying))//&& (fuenteAudio.clip != sonidoCorrer)
            {
                inventario.inventAbierto = false;
                invent.clip = abrirInven;
                invent.Play();
            }


        }

        else if (inventario.seleccionarIt || invent.isPlaying)
        {
            if ((!invent.isPlaying))//&& (fuenteAudio.clip != sonidoCorrer)
            {
                inventario.seleccionarIt = false;
                invent.clip = selItem;
                invent.Play();
            }

        }


        else if (inventario.comer || invent.isPlaying)
        {
            inventario.comer = false;
            invent.clip = come;
            invent.Play();
        }

        else
        {
            invent.Stop();
            invent.clip = null;

        }

        //Radio
       
    if (GameObject.FindGameObjectWithTag("Distractor") !=null && GameObject.FindGameObjectWithTag("Distractor").activeInHierarchy && x< GameObject.FindGameObjectsWithTag("Distractor").Length)
        {
            radio2 = GameObject.FindGameObjectWithTag("Distractor").GetComponent<AudioSource>();
             tiempoSonido2 = tiempoSonido2 + 1 * Time.deltaTime;

            if (tiempoSonido2 <= 20f && !radio2.isPlaying)
            { Debug.Log("CosaAcriva");
                radio2.clip = radioSoni;
                radio2.Play();
            }
            else if (tiempoSonido2 > 20f)
            {
                // inventario.sonidoRadio = false;
                radio2.Stop();
                radio2.clip = null;
                x++;
                tiempoSonido2 = 0f;
            }
        }
        
        
      /*  if (distractor2.activeInHierarchy)
        {
            tiempoSonido2 = tiempoSonido2 + 1 * Time.deltaTime;

            if (tiempoSonido2 <= 20f && !radio2.isPlaying)
            {
                radio2.clip = radioSoni;
                radio2.Play();
            }
            else if (tiempoSonido2 > 20f)
            {
                // inventario.sonidoRadio = false;
                radio2.Stop();
                radio2.clip = null;
            }


        }

        else if (distractor.activeInHierarchy)
        {
            tiempoSonido = tiempoSonido + 1 * Time.deltaTime;

            if (tiempoSonido <= 20f && !radio.isPlaying)
            {
                radio.clip = radioSoni;
                radio.Play();
            }
            else if (tiempoSonido > 20f)
            {
                //inventario.sonidoRadio = false;
                radio.Stop();
                radio.clip = null;
            }

        }*/

        //Vida

        if(atacar.pegar || vida.isPlaying)
        {
            if ((!vida.isPlaying))//&& (fuenteAudio.clip != sonidoCorrer)
            {
                atacar.pegar = false;
                vida.clip = pegar;
                vida.Play();
            }

            if (!recibirZ.isPlaying)
            {
                atacar.pegar = false;
                recibirZ.clip = danoZ;
                recibirZ.Play();
            }
        }

        else if(perdiendo || vida.isPlaying)
        {
            if ((!vida.isPlaying))//&& (fuenteAudio.clip != sonidoCorrer)
            {
                perdiendo = false;
                vida.clip = perder;
                vida.Play();
            }
        }


        else
        {
            vida.Stop();
            vida.clip = null;
            recibirZ.Stop();
            recibirZ.clip = null;
          
        }

        //Ambiente cueva
        if (entrada.dentroCueva)
        {
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
        }

        


        //Pausa activada

            if (saberPausa.pausaActiva)
            {
                vida.Stop();
                vida.clip = null;
                recibirZ.Stop();
                recibirZ.clip = null;
                fuenteAudio.Stop();
                fuenteAudio.clip = null;
                radio.Stop();
                radio.clip = null;
                radio2.Stop();
                radio2.clip = null;
                invent.Stop();
                invent.clip = null;
                control.Stop();
                control.clip = null;
            }





    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.tag == "Zombie")
        {
            perdiendo = true;
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Zombie")
        {
            perdiendo = false;
            atacar.pegar = false;

        }
    }
}
