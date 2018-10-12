using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInteract : MonoBehaviour {
    [SerializeField]
    List<Collider> handColliders;
    PlateScript plateScript;
    // Use this for initialization
    void Start () {

	}

    private void OnTriggerEnter(Collider other)
    {
         if((plateScript = other.GetComponent<PlateScript>())!= null)
        {
            plateScript.ToggleInfo();
        }
    }
}
