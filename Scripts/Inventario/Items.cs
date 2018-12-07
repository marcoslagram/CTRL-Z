using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]


public class Items{


    public string itemName;
    [SerializeField] public Sprite itemSprite = null;
    public string itemDescription;
    public ItemType itemType = ItemType.SinDefinir;
    public ItemClass itemClass = ItemClass.SinDeterminar;
    public int id;
    public int cantidad;


    public enum ItemType
    {
        Palo,
        PiedraEspecial,
        Clavos,
        Cuerda,
        LataConserva,
        Tarta,
        LataVacia,
        Piedra,
        Radio,
        SinDefinir
    }

    public enum ItemClass
    {
        ContruccionArma,
        Consumibles,
        SinDeterminar
    }



    public Items(string name, string description, ItemType type, ItemClass classes, int cantidad, int id)
    {
        itemName = name;
        //itemSprite = icon;
        itemDescription = description;
        itemType = type;
        itemClass = classes;
        this.id = id;
        this.cantidad = cantidad;
    }

    public Items(string name, string description)
    {
        itemName = name;
        itemDescription = description;
    }
    
    public Items(int id, int cantidad)
    {
        this.id = id;
        this.cantidad = cantidad;
    }

    public void AñadirCantidad(int cantidad)
    {
        this.cantidad += cantidad;
    }

    public Items()
    {
        itemName = "Nombre vacio";
    }

}
