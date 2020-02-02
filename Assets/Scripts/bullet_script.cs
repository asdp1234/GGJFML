using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{

    public float speed = 200;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        GameObject.Destroy(this.gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        GameObject.Destroy(this.gameObject,0);
        if(col.gameObject.tag == "enemy") {
            GameObject.Destroy(col.gameObject,0);
        }
    }
}
