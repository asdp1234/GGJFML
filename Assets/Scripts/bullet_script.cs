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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter() {
        GameObject.Destroy(this.gameObject,0);
    }
    void OnCollisionEnter(Collision col) {
        GameObject.Destroy(this.gameObject,0);
    }
}
