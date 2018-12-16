using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;

[Serializable]

public class ControladorDatosJuego
{
    public Tiempo tiempoSobra;
    public GestionDias dia;

    public List<Items> myItems;

    public GameObject[] objetosActivos;
    public GameObject[] zombiesActivos;

    public Pausa volumenSlider;
    public Pausa volumenSliderAmbiente;
    public Pausa volumenSliderEfectos;
    public Pausa volumenGeneralMixer;
}
//Aqui tengo los datos que hay que guardar a disco (y cargar de)
