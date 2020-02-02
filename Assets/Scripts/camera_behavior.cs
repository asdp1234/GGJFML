using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_behavior : MonoBehaviour {
 
    public Transform player;
     
    void Start () {
        player = GameObject.Find ("Player").transform;
    }

    void Update () {
        transform.position = new Vector3 (player.position.x, player.position.y+150, player.position.z+100);
    }
 }