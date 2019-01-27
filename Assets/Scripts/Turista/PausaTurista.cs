using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.AI;

public class PausaTurista : MonoBehaviour {

    public GameObject pausaCanvas;
    // public AudioListener volumen;
    public Slider volumenSlider;
    public Slider volumenSliderAmbiente;
    public Slider volumenSliderEfectos;
    public AudioMixer volumenGeneralMixer;
    public float volumenGeneral;
    public float volumenAmbiente;
    public float volumenEfectos;


    public bool pausaActivada = false;



   
    private MovimientoTurista movePlayer;
    private CamaraCont moveCamara;
    private Saltar salto;
    
   
  //  private SonidoTurista sonido;

   

    // private Menu volumenMenu;

    /* private AudioMixer volumenAmbiente;
     private AudioMixer volumenEfectos;*/

    // Use this for initialization
    void Start()
    {

        volumenGeneral = GetVolumenGeneral();
        volumenAmbiente = GetVolumenAmbiente();
        volumenEfectos = GetVolumenEfectos();
        volumenSlider.value = volumenGeneral;
        volumenSliderAmbiente.value = volumenAmbiente;
        volumenSlider.value = volumenEfectos;

        // volumenGeneral.SetFloat("Master", float volumenEfectos);







        
        //sonido = GameObject.Find("Cube").GetComponent<SonidoTurista>();
        
        movePlayer = GameObject.Find("Cube").GetComponent<MovimientoTurista>();
        moveCamara = GameObject.Find("Camera").GetComponent<CamaraCont>();
        salto = GameObject.Find("Cube").GetComponent<Saltar>();


    }

    // Update is called once per frame
    void Update()
    {

      

        if (Input.GetKeyDown(KeyCode.P))
        {
            // debugg.DebuggingText("Inventario abierto");
            pausaCanvas.SetActive(!pausaCanvas.activeInHierarchy);


        }

        if (!pausaCanvas.activeInHierarchy)
        {
            pausaActivada = false;
            movePlayer.enabled = true;
            moveCamara.enabled = true;
            salto.enabled = true;
            //sonido.enabled = true;
        }

        else if (pausaCanvas.activeInHierarchy)
        {
            pausaActivada = true;
            movePlayer.enabled = false;
            moveCamara.enabled = false;
            salto.enabled = false;
            //sonido.enabled = false;

           
        }

        SetVolumenGeneral(volumenSlider.value);
        SetVolumenAmbiente(volumenSliderAmbiente.value);
        SetVolumenEfectos(volumenSliderEfectos.value);
    }





    public void PulsarSalir()
    {
        //Debug.Log(AudioListener.volume);
        // AudioListener.volume = volumenSlider.value;

        pausaCanvas.SetActive(false);

        /* volumenAmbiente.SetFloat("Ambiente", volumenSliderAmbiente.value);
         volumenEfectos.SetFloat("Movimiento", volumenSlider.value);*/

    }

    public void SetVolumenGeneral(float volumenGeneral)
    {
        volumenGeneralMixer.SetFloat("VolumenGeneral", volumenGeneral);

    }

    public void SetVolumenAmbiente(float volumenAmbiente)
    {
        volumenGeneralMixer.SetFloat("VolumenAmbiente", volumenAmbiente);

    }
    public void SetVolumenEfectos(float volumenEfectos)
    {
        volumenGeneralMixer.SetFloat("VolumenEfectos", volumenEfectos);

    }
    public float GetVolumenGeneral()
    {
        volumenGeneralMixer.GetFloat("VolumenGeneral", out volumenGeneral);

        return volumenGeneral;
    }

    public float GetVolumenAmbiente()
    {
        volumenGeneralMixer.GetFloat("VolumenAmbiente", out volumenAmbiente);

        return volumenAmbiente;
    }

    public float GetVolumenEfectos()
    {
        volumenGeneralMixer.GetFloat("VolumenEfectos", out volumenEfectos);

        return volumenEfectos;
    }
}
