using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour {

	// Use this for initialization
    public Light light;

    Color clr;

    private void Start()
    {
        clr = Random.ColorHSV();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Color Change");
            light.color = clr;
        }
    }
}
