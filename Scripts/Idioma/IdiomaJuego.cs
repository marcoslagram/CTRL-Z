using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdiomaJuego : MonoBehaviour {


    public Text salud;
    public Text energia;
    public Text tiempo;
    public Text usos;
    public Text siguienteTutorial;
    public Text siguienteDialogo;
    public Text pausa;
    public Text volumenG;
    public Text volumenA;
    public Text volumenE;
    public Text salir;
    public Text Inventario;
    public Text armas;
    public Text consumibles;


    // Use this for initialization
    void Start () {
        //Dentro de cada condición se metería el texto que quieres cambiar por ejemplo
        //en la condición ==1 se podría poner salir.text="Sair";

        //0=castellano 1=galego 2=inglés

        if (Menu.idiomaElegido == 0)
        {
            //Aqui se meterían los textos de los botones en español
        }

        else if (Menu.idiomaElegido == 1)
        {
            //Aqui se meterían los textos de los botones en gallego
        }

        else if (Menu.idiomaElegido == 2)
        {
            //Aqui se meterían los textos de los botones frases en inglés
        }

    }
	
	// Update is called once per frame
	void Update () {

        //Dentro de cada condición se metería el texto que quieres cambiar por ejemplo
        //en la condición ==1 se podría poner salir.text="Sair";

        //0=castellano 1=galego 2=inglés

        if (Menu.idiomaElegido == 0)
        {
            //Aqui se meterían los textos de los botones en español
        }

        else if (Menu.idiomaElegido == 1)
        {
            //Aqui se meterían los textos de los botones en gallego
        }

        else if (Menu.idiomaElegido == 2)
        {
            //Aqui se meterían los textos de los botones frases en inglés
        }

    }
}
