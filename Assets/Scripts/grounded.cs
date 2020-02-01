using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start() {
        Player = gameObject.transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnCollisionEnter(Collision col) {
        Debug.Log("Collision Detected");
        if(col.collider.tag == "ground") {
            Debug.Log("On Ground");
            Player.GetComponent<movement>().is_grounded = true;
        }
    }
    private void OnCollisionExit(Collision col) {
        Debug.Log("Collision Exited");
        if(col.collider.tag == "ground") {
            Debug.Log("Off Ground");
            Player.GetComponent<movement>().is_grounded = false;
        }
    }
}
