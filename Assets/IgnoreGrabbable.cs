using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreGrabbable : MonoBehaviour {
    [SerializeField]
    GrabbableList grabbableList;
    [SerializeField]
    List<Collider> handsColliders;
	// Use this for initialization
	void Start () {
        Collider localCollider = gameObject.GetComponent<Collider>();
        foreach (GameObject grabbable in grabbableList.Grabbables)
        {
            foreach(Collider collider in grabbable.GetComponents<Collider>())
            {
                Physics.IgnoreCollision(localCollider, collider);  
            }
        }
        foreach(Collider collider in handsColliders)
        {
            Physics.IgnoreCollision(localCollider, collider);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
