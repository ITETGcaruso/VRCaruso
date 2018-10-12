using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class PlateScript : MonoBehaviour {
    [SerializeField]
    GameObject toToggle;
    [SerializeField]
    GameObject Pannello;
    public void ToggleInfo()
    {
        if (Pannello.activeInHierarchy==true) {
            Pannello.SetActive(false);
        }
        toToggle.SetActive(!toToggle.activeInHierarchy);
        
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
