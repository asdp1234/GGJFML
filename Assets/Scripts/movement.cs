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

    public Transform gunpoint;
    public GameObject e_gun;
    public GameObject bullet;

    //Object to determine if the item has been collected yet.
    public bool item_state = false;
    public bool is_grounded = false;

    private bool gun_equipped = false;
    public float aim_direction = 1;
    public int bullet_delay = 35;
    public int click = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Used to reference the Rigidbody of the player game object
        rb = gameObject.GetComponent<Rigidbody>();

        e_gun.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Jump function to make player jump, need to ensure it requires the player to be on the ground
    	Jump();
        float dir = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(-dir, 0f, 0f);
        if (Mathf.Abs(aim_direction+dir) < 1) {
            aim_direction = dir/(Mathf.Abs(dir));
            Flip();
        }
	    transform.position += movement * Time.deltaTime * move_speed;

        if(Input.GetMouseButton(0) && click > bullet_delay-1) {
            click = 0;
            Instantiate(bullet, gunpoint.position, gunpoint.rotation);
            //Needs to fire bullets now
        }

        if(click < bullet_delay) {
            click++;
        }        
        //aim_direction = Input.mousePosition.x - WorldToScreenPoint(transform.position).x;// - transform.position.y)/(Mathf.Abs(Input.mousePosition.y - transform.position.y));
    }

    void Flip(){
        transform.Rotate(0f, -1*180f*aim_direction, 0f);
        // Camera.main.transform.Rotate(0f, 180f, 0f);
        
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
        else if (col.gameObject.name == "gun") {
            gun_equipped = false;
            e_gun.gameObject.SetActive(true);

            GameObject.Destroy(col.gameObject,0);
        }
        else if (col.gameObject.tag == "ground") {
            is_grounded = true;
            Debug.Log(transform.position);
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "ground") {
            is_grounded = false;
        }
    }
}
