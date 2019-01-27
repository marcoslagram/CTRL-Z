using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntradaTurista : MonoBehaviour {

    public Material noche;
    public GameObject luz;

    public GameObject jugador;

    public bool dentroCueva = false;
    public bool salirCine = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Cube" )
        {
            salirCine = true;
            /*RenderSettings.skybox = noche;
            RenderSettings.ambientIntensity = 0;
            RenderSettings.reflectionIntensity = 0;
            luz.SetActive(false);*/
            GameObject.Find("Cube").GetComponent<NavMeshAgent>().enabled = false;
            jugador.transform.position = new Vector3(211.27f, 53f, 46.7f);
            dentroCueva = true;

            //GameObject.Find("Cube").GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    
}
