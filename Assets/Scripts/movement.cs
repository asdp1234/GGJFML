using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float move_speed = 5f;
    public float jump_height = 5f;
    public Rigidbody rb;
    public bool item_state = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
	Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
	transform.position += movement * Time.deltaTime * move_speed;

    }

    void Jump(){
        if (Input.GetButtonDown("Jump")){
	        rb.AddForce(new Vector3(0f,jump_height,0f), ForceMode.Impulse);
	    }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "item") {
            item_state = true;
            Debug.Log("Collision Detected");
            GameObject.Destroy(col.gameObject,1);
        }
    }
}
