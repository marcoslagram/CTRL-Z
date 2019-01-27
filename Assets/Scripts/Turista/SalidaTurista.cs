using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalidaTurista : MonoBehaviour {

    public Material dia;

    public GameObject luz;

    public GameObject jugador;

    private EntradaTurista entrada;

    // Use this for initialization
    void Start () {
        entrada = GameObject.Find("EntradaCueva").GetComponent<EntradaTurista>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Cube")
        {

            RenderSettings.skybox = dia;
            RenderSettings.ambientIntensity = 1;
            RenderSettings.reflectionIntensity = 1;
            luz.SetActive(true);
            entrada.dentroCueva = false;
            GameObject.Find("Cube").GetComponent<NavMeshAgent>().enabled = false;
            jugador.transform.position = new Vector3(91.86f, 0f, 56.2f);
            GameObject.Find("Cube").GetComponent<NavMeshAgent>().enabled = true;
        }
        
    }


}
