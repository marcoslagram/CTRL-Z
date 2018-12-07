using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    /*public bool empezar = false;
    public bool salir = false;*/
    public GameObject menu;

    // public AudioListener volumen;
    public Slider volumenSlider;
    public Slider volumenSliderAmbiente;
    public Slider volumenSliderEfectos;
    public AudioMixer volumenGeneralMixer;
   /* private AudioMixer volumenAmbiente;
    private AudioMixer volumenEfectos;*/

    // Use this for initialization
    void Start () {
        menu.transform.GetChild(7).gameObject.SetActive(false);
        menu.transform.GetChild(8).gameObject.SetActive(false);
        menu.transform.GetChild(9).gameObject.SetActive(false);
        menu.transform.GetChild(10).gameObject.SetActive(false);
        menu.transform.GetChild(11).gameObject.SetActive(false);

       // volumenGeneral.SetFloat("Master", float volumenEfectos);
    }
	
	// Update is called once per frame
	void Update () {


        /*if (empezar)
        {
            empezar = false;
            
        }*/
        SetVolumenGeneral(volumenSlider.value);
        SetVolumenAmbiente(volumenSliderAmbiente.value);
        SetVolumenEfectos(volumenSliderEfectos.value);
    }

    public void PulsarEmpezar()
    {
       // empezar = true;
        SceneManager.LoadScene("Urbanizacion");
    }

    public void PulsarModoTurista()
    {
        // empezar = true;
        SceneManager.LoadScene("UrbanizacionTurista");
    }



    public void PulsarSalir()
    {
       // salir= true;
        Application.Quit();
    }

    public void PulsarOpciones()
    {
        menu.transform.GetChild(2).gameObject.SetActive(false);
        menu.transform.GetChild(3).gameObject.SetActive(false);
        menu.transform.GetChild(4).gameObject.SetActive(false);
        menu.transform.GetChild(5).gameObject.SetActive(false);
        menu.transform.GetChild(6).gameObject.SetActive(false);

        menu.transform.GetChild(7).gameObject.SetActive(true);
        menu.transform.GetChild(8).gameObject.SetActive(true);
        menu.transform.GetChild(9).gameObject.SetActive(true);
        menu.transform.GetChild(10).gameObject.SetActive(true);
        menu.transform.GetChild(11).gameObject.SetActive(true);
    }

    public void PulsarGuardar()
    {
        menu.transform.GetChild(2).gameObject.SetActive(true);
        menu.transform.GetChild(3).gameObject.SetActive(true);
        menu.transform.GetChild(4).gameObject.SetActive(true);
        menu.transform.GetChild(5).gameObject.SetActive(true);
        menu.transform.GetChild(6).gameObject.SetActive(true);

        menu.transform.GetChild(7).gameObject.SetActive(false);
        menu.transform.GetChild(8).gameObject.SetActive(false);
        menu.transform.GetChild(9).gameObject.SetActive(false);
        menu.transform.GetChild(10).gameObject.SetActive(false);
        menu.transform.GetChild(11).gameObject.SetActive(false);
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

}
