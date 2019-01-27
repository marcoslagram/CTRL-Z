using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Prueba : MonoBehaviour {

    public Transform cosa;

    Image[] slots;

    // Use this for initialization
    void Start()
    {
        slots = cosa.GetComponentsInChildren<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(slots.Length);
	}
}
