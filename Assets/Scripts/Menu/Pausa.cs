using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.AI;

public class Pausa : MonoBehaviour {
   // public GameObject menu;
   public GameObject pausaCanvas;
    // public AudioListener volumen;
    public Slider volumenSlider;
    public Slider volumenSliderAmbiente;
    public Slider volumenSliderEfectos;
    public AudioMixer volumenGeneralMixer;
    public float volumenGeneral;
    public float volumenAmbiente;
    public float volumenEfectos;


    public bool pausaActiva = false;


    private Tiempo tiempoDia;
    private Inventory invetarioDia;
    private MovimientoJugador movePlayer;
    private CamaraCont moveCamara;
    private Saltar salto;
    private Control miControl;
    private MotorSonido sonido;
    private Economia economiaSalud;

    private GameObject[] zombies;

    int[] salude;
    int salud;
    // private Menu volumenMenu;

    /* private AudioMixer volumenAmbiente;
     private AudioMixer volumenEfectos;*/

    // Use this for initialization
    void Start()
    {

        volumenGeneral=GetVolumenGeneral();
        volumenAmbiente = GetVolumenAmbiente();
        volumenEfectos = GetVolumenEfectos();


        volumenSlider.value = volumenGeneral;
        volumenSliderAmbiente.value = volumenAmbiente;
        volumenSliderEfectos.value = volumenEfectos;

        // volumenGeneral.SetFloat("Master", float volumenEfectos);

        zombies = GameObject.FindGameObjectsWithTag("Zombie");

        for (int i = 0; i < zombies.Length; i++)
        {

            salud = zombies[i].GetComponent<Economia>().salud;

        }



        tiempoDia = GameObject.Find("Player").GetComponent<Tiempo>();
        miControl = GameObject.Find("Player").GetComponent<Control>();
        sonido = GameObject.Find("Cube").GetComponent<MotorSonido>();
        invetarioDia = GameObject.Find("Inventory").GetComponent<Inventory>();
        movePlayer = GameObject.Find("Cube").GetComponent<MovimientoJugador>();
        moveCamara = GameObject.Find("Camera").GetComponent<CamaraCont>();
        salto = GameObject.Find("Cube").GetComponent<Saltar>();
        economiaSalud = GameObject.Find("Player").GetComponent<Economia>();

    }

    // Update is called once per frame
    void Update()
    {

        zombies = GameObject.FindGameObjectsWithTag("Zombie");

     
        

        if (Input.GetKeyDown(KeyCode.P))
        {
            // debugg.DebuggingText("Inventario abierto");
            pausaCanvas.SetActive(!pausaCanvas.activeInHierarchy);

            for (int i = 0; i < zombies.Length; i++)
            {

                zombies[i].GetComponent<NavMeshAgent>().enabled = true;
                zombies[i].GetComponent<Zombi>().enabled = true;
                zombies[i].GetComponent<Caza>().enabled = true;
                zombies[i].GetComponent<Economia>().enabled = true;
                   Debug.Log(zombies[i].GetComponent<Economia>().salud);
            }

        }

        if (!pausaCanvas.activeInHierarchy)
        {
            Time.timeScale = 1f;
        }

        if (!pausaCanvas.activeInHierarchy && DialogoNPC.salieronDialog)
        {
            Time.timeScale = 1f;
          //  Debug.Log("Activoo");
            tiempoDia.enabled = true;
            miControl.enabled = true;
            invetarioDia.enabled = true;
            movePlayer.enabled = true;
            moveCamara.enabled = true;
            salto.enabled = true;
            //sonido.enabled = true;
            pausaActiva = false;
            economiaSalud.enabled = true;
        }

        else if (pausaCanvas.activeInHierarchy)
        {
            
            pausaActiva = true;
            tiempoDia.enabled = false;
            miControl.enabled = false;
            invetarioDia.enabled = false;
            movePlayer.enabled = false;
            moveCamara.enabled = false;
            salto.enabled = false;
            economiaSalud.enabled = false;
            // sonido.enabled = false;


            for (int i = 0; i < zombies.Length; i++)
            {

                zombies[i].GetComponent<NavMeshAgent>().enabled = false;
                zombies[i].GetComponent<Zombi>().enabled = false;
                zombies[i].GetComponent<Caza>().enabled = false;
                zombies[i].GetComponent<Economia>().enabled = false;
                //salud = zombies[i].GetComponent<Economia>().salud;
            }
            Time.timeScale = 0f;
        }

        SetVolumenGeneral(volumenSlider.value);
        SetVolumenAmbiente(volumenSliderAmbiente.value);
        SetVolumenEfectos(volumenSliderEfectos.value);

    
    }



  

    public void PulsarSalir()
    {
        //Debug.Log(AudioListener.volume);
        // AudioListener.volume = volumenSlider.value;

        Time.timeScale = 1f;

        pausaCanvas.SetActive(false);

        if (DialogoNPC.salieronDialog)
        {


            for (int i = 0; i < zombies.Length; i++)
            {

                zombies[i].GetComponent<NavMeshAgent>().enabled = true;
                zombies[i].GetComponent<Zombi>().enabled = true;
                zombies[i].GetComponent<Caza>().enabled = true;
                zombies[i].GetComponent<Economia>().enabled = true;

            }

            Debug.Log("Activoo");
            tiempoDia.enabled = true;
            miControl.enabled = true;
            invetarioDia.enabled = true;
            movePlayer.enabled = true;
            moveCamara.enabled = true;
            salto.enabled = true;
            sonido.enabled = true;
            economiaSalud.enabled = true;
            /* volumenAmbiente.SetFloat("Ambiente", volumenSliderAmbiente.value);
             volumenEfectos.SetFloat("Movimiento", volumenSlider.value);*/
        }

       

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
       // Debug.Log(volumenEfectos);
        return volumenEfectos;
    }
}
