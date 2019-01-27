using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class SaveDatos{

    public int salud;
    public int energia;
    public int usos;
    public float tiempo;

  //  public bool sigue;

    public List<Items> myItems;
  //  public Image[] consumibles;
   // public Image[] armas;

    public Vector3 positionj;
    public Quaternion rotacionj;

    public Vector3[] positionz;
    public Quaternion[] rotacionz;

    public Vector3 positionc;
    public Quaternion rotacionc;

    public GameObject[] objetosActivos;
    public GameObject[] zombiesActivos;





}
