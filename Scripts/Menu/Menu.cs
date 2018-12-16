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

    public PlayerController carga;
    public PrefsController cargaPrefs;
    public PrefsController guardaPrefs;
    public PlayerController guardaDatos;

    // public AudioListener volumen;
    public Slider volumenSlider;
    public Slider volumenSliderAmbiente;
    public Slider volumenSliderEfectos;
    public AudioMixer volumenGeneralMixer;

    public Dropdown idioma;
    /* private AudioMixer volumenAmbiente;
     private AudioMixer volumenEfectos;*/


    public float volumenGeneral;
    public float volumenAmbiente;
    public float volumenEfectos;

    public static int idiomaElegido;

    public static bool continuar = false;

//    public List<Dropdown.OptionData> listaOpc = new List<Dropdown.OptionData>();

    // Use this for initialization
    void Start () {

        volumenGeneral = GetVolumenGeneral();
        volumenAmbiente = GetVolumenAmbiente();
        volumenEfectos = GetVolumenEfectos();


        volumenSlider.value = volumenGeneral;
        volumenSliderAmbiente.value = volumenAmbiente;
        volumenSliderEfectos.value = volumenEfectos;



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

        SaberIdioma();
        SetVolumenGeneral(volumenSlider.value);
        SetVolumenAmbiente(volumenSliderAmbiente.value);
        SetVolumenEfectos(volumenSliderEfectos.value);
    }

    public void PulsarEmpezar()
    {
        // empezar = true;
        GestionDias.dia = 1;
        SceneManager.LoadScene("Urbanizacion");
       // cargaPrefs.LoadPreferencesFromDisk();
    }

    public void PulsarModoTurista()
    {
        // empezar = true;
        SceneManager.LoadScene("UrbanizacionTurista");
        //cargaPrefs.LoadPreferencesFromDisk();
    }



    public void PulsarSalir()
    {
       // salir= true;

        //guardaPrefs.SavePreferencesToDisk();
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

      //  guardaPrefs.SavePreferencesToDisk();
        //guardaDatos.SavePlayerDataToDisk();
    }

    //para que cargue los datos
    public void PulsarContinuar()
    {
        SceneManager.LoadScene("Urbanizacion");
        //supongo que habra que hacer un menu.transform.GetChild(num X) o algo asi, no se
        //carga.LoadPlayerDataFromDisk();
        continuar = true;

    }

    public void SaberIdioma()
    {
        //0=Castellano 1=Gallego 2=Inglés
        idiomaElegido = idioma.value;
    }

    public void SetVolumenGeneral(float volumenGeneral)
    {
        volumenGeneralMixer.SetFloat("VolumenGeneral", volumenGeneral);
        Debug.Log("Deslizando0");
    }

    public void SetVolumenAmbiente(float volumenAmbiente)
    {
        volumenGeneralMixer.SetFloat("VolumenAmbiente", volumenAmbiente);
        Debug.Log("Deslizando1");
    }
    public void SetVolumenEfectos(float volumenEfectos)
    {
        volumenGeneralMixer.SetFloat("VolumenEfectos", volumenEfectos);
        Debug.Log("Deslizando2");

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
