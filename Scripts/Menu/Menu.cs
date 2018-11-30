using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    /*public bool empezar = false;
    public bool salir = false;*/
    public GameObject menu;

    // Use this for initialization
    void Start () {
        menu.transform.GetChild(7).gameObject.SetActive(false);
        menu.transform.GetChild(8).gameObject.SetActive(false);
        menu.transform.GetChild(9).gameObject.SetActive(false);
        menu.transform.GetChild(10).gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {


        /*if (empezar)
        {
            empezar = false;
            
        }*/

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
    }


}
