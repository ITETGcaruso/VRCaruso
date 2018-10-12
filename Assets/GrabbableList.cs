using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableList : MonoBehaviour {
    public List<GameObject> Grabbables;

    bool ypressed;
    bool bpressed;
    bool resetted;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
            bpressed = true;
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
            ypressed = true;

        if (OVRInput.GetUp(OVRInput.RawButton.B)) {
            bpressed = false;
            resetted = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.Y)) {
            ypressed = false;
            resetted = false;
        }
        if (ypressed && bpressed && !resetted)
            ResetGrabbables();
    }
    void ResetGrabbables()
    {
        foreach(GameObject grabbable in Grabbables)
        {
            grabbable.transform.localPosition = Vector3.zero;
            grabbable.transform.localRotation = Quaternion.identity;
            resetted = true;
        }
        SpawnTree.ResetTrees();
    }
}
