using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class PreferenciasJugador
{
    //para las preferencias, las vamos a guardar en PlayerController tambien y quitaremos el script PreferenciasJugador
    public Menu volumenSlider;
    public Menu volumenSliderAmbiente;
    public Menu volumenSliderEfectos;
    public Menu volumenGeneralMixer;

    //public Dropdown idioma;
    public Menu idioma;
}

//aqui esto esta bien
