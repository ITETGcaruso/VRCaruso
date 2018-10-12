using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour {
    public static List<GameObject> trees;
    OVRGrabbable grab;
    Rigidbody rb;
    [SerializeField]
    Transform anchorTransform;
    [SerializeField]
    GameObject tree;
    Collider collider;
    public float scale;
    public float time;
    float intervals;
    float increment;
    int index;
    bool spawning = false;
    float actualScale;
    // Use this for initialization
    void Start () {
        if(trees == null)
        {
            trees = new List<GameObject>();
        }
        grab = GetComponent<OVRGrabbable>();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        Physics.IgnoreLayerCollision(0, 18);
	}
	void resetSphere()
    {
        gameObject.layer = 18;
        transform.SetParent(anchorTransform, true);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }
	// Update is called once per frame
	void Update () {
        if (!grab.isGrabbed)
        {
            float dist = (transform.position - anchorTransform.position).magnitude;
            if(dist < .2 && transform.localPosition != Vector3.zero)
            {
                resetSphere();
            }
        }
        else
        {
            if (transform.parent != null)
            {
                transform.parent = null;
                gameObject.layer = 0;
            }
        }
        if(spawning)
        {
            if (index < intervals)
                try {
                    Increment(trees[trees.Count - 1]);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    EndSpawn();
                }
            else
                EndSpawn();
            index++;
        }
        
	}
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 point = Vector3.zero;
        if (collision.collider.gameObject.layer == 0)
        {//touching ground!
            foreach(ContactPoint cp in collision.contacts)
            {
                if(cp.otherCollider.gameObject.layer == 0)
                {
                    point = cp.point;
                    break;
                }
            }
        }
        if(point != Vector3.zero)
        {
            StartSpawn(point);
        }
    }

    private void StartSpawn(Vector3 point) 
    {
        trees.Add(GameObject.Instantiate(tree, point, Quaternion.identity));
        resetSphere();
        collider.enabled = false;
        intervals = Mathf.Floor(time / Time.fixedDeltaTime);
        increment = scale / intervals;
        actualScale = 0;
        index = 0;
        spawning = true;
    }
    void Increment(GameObject t)
    {
        actualScale += increment;
        Vector3 scale = t.transform.localScale;
        scale.Set(actualScale, actualScale, actualScale);
        Vector3 pos = t.transform.position;
        pos.y = 0;
        t.transform.position = pos;
        t.transform.localScale = scale;
    }
    void EndSpawn()
    {
        collider.enabled = true;
        spawning = false;
    }

    static public void ResetTrees()
    {
        foreach(GameObject t in trees)
        {
            Destroy(t);
        }
        trees = new List<GameObject>();
    }
}
