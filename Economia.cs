using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economia : MonoBehaviour {
    //Vamos a utilizar la variable daño del script Caza para que la salud se decremente según el daño
    private int salud;
    private int energia;
    private Caza daño;
    private Interactable consumible;
    public GameObject jugador;
    

    // Use this for initialization
    void Start () {
        daño = jugador.GetComponent<Caza>();
        consumible = GetComponent<Interactable>();
        energia = 0;    //los consumibles la aumentaran
        salud = 100;    //valor inicial de salud

    }

    // Update is called once per frame
    void Update () {
        if (daño)
        {
            salud = salud - 50;
        }
        if (consumible)
        {
            energia = energia + 50;
        }
        
        Debug.Log("Salud es igual a " + salud);     //Para que la salud se imprima por consola
        Debug.Log("Energia es igual a " + energia); //Para que la energia se imprima por consola
	}
}
