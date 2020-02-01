using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //Setting for move speed, can be edited from unity 
    public float move_speed = 5f;

    //Setting for jump height, can be edited from unity 
    public float jump_height = 5f;

    //Object to get Rigidbody into, can be edited from unity
    public Rigidbody rb;

    //Object to determine if the item has been collected yet.
    public bool item_state = false;
    public bool is_grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        //Used to reference the Rigidbody of the player game object
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump function to make player jump, need to ensure it requires the player to be on the ground
    	Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
	    transform.position += movement * Time.deltaTime * move_speed;

    }

    void Jump(){
        if (Input.GetButtonDown("Jump") && is_grounded){
	        rb.AddForce(new Vector3(0f,jump_height,0f), ForceMode.Impulse);
	    }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "item") {
            item_state = true;
            
            GameObject.Destroy(col.gameObject,1);
        }
        else if (col.gameObject.tag == "ground") {
            is_grounded = true;
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "ground") {
            is_grounded = false;
        }
    }
}
