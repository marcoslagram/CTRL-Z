using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cinematica : MonoBehaviour {

    public GameObject camara;
    public GameObject camaraCinematica;
    private Entrada cinematica;
    private PlayableDirector director;

    public Material noche;
    public GameObject luz;

    // Use this for initialization
    void Start () {
        cinematica = GameObject.Find("EntradaCueva").GetComponent<Entrada>();
      //  director = GameObject.Find("CamaraAni").GetComponent<PlayableDirector>();
	}
	
	// Update is called once per frame
	void Update () {

     /*   if (GameObject.Find("CamaraAni") != null)
        {
            
        }*/
// Debug.Log(director.time);
       
       // Debug.Log(director.state== PlayState.Playing);
        // Debug.Log(this.transform.collider);
        if (cinematica.salirCine)
        {
            camaraCinematica.SetActive(true);
            director = GameObject.Find("CamaraAni").GetComponent<PlayableDirector>();
            if (director.time >= 4.6)
            {
                RenderSettings.skybox = noche;
                RenderSettings.ambientIntensity = 0;
                RenderSettings.reflectionIntensity = 0;
                luz.SetActive(false);
            }

            if(director.state != PlayState.Playing)
            {
                cinematica.salirCine = false;
                camaraCinematica.SetActive(false);
            }
           
            
        }
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.name == "cueva_interior")
        {
            camara.SetActive(false);
        }
        
    }*/
}
