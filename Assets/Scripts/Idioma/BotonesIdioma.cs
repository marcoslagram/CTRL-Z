using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesIdioma : MonoBehaviour {

    public Text empezar;
    public Text continuar;
    public Text turista;
    public Text opcion;
    public Text salir;
    public Text idioma;
    public Text volumenG;
    public Text volumenA;
    public Text volumenE;
    public Text guardar;
    public Text aviso;
    public Text confirmar;


    public Dropdown opciones; //Se pondría opciones.options[0,1 y 2].text = ".."; para cambiarlos textos del dropdown

    

    // Use this for initialization
    void Start () {
        //Dentro de cada condición se metería el texto que quieres cambiar por ejemplo
        //en la condición ==1 se podría poner salir.text="Sair";

        //0=castellano 1=galego 2=inglés

        if (Menu.idiomaElegido == 0)
        {
            //Aqui se meterían los textos de los botones en español
            //Se pondría opciones.options[0,1 y 2].text = ".."; para cambiarlos textos del dropdown
        }

        else if (Menu.idiomaElegido == 1)
        {
            //Aqui se meterían los textos de los botones en gallego
            //Se pondría opciones.options[0,1 y 2].text = ".."; para cambiarlos textos del dropdown
        }

        else if (Menu.idiomaElegido == 2)
        {
            //Aqui se meterían los textos de los botones frases en inglés
            //Se pondría opciones.options[0,1 y 2].text = ".."; para cambiarlos textos del dropdown
        }


    }

	
	// Update is called once per frame
	void Update () {

        if (Menu.idiomaElegido == 0)
        {
            //Aqui se meterían los textos de los botones en español
            //Se pondría opciones.options[0,1 y 2].text = ".."; para cambiarlos textos del dropdown
        }

        else if (Menu.idiomaElegido == 1)
        {
            //Aqui se meterían los textos de los botones en gallego
            //Se pondría opciones.options[0,1 y 2].text = ".."; para cambiarlos textos del dropdown
        }

        else if (Menu.idiomaElegido == 2)
        {
            //Aqui se meterían los textos de los botones frases en inglés
             //Se pondría opciones.options[0,1 y 2].text = ".."; para cambiarlos textos del dropdown
        }

    }




}
