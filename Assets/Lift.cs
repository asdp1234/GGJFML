using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField]
    int move;
    [SerializeField]
    GameObject go, doorgo;
    [SerializeField]
    Transform f1, f2, f3, f4, f5;
    [SerializeField]
    bool floor1, floor2, floor3, floor4, floor5;
    [SerializeField]
    bool canmove = true;
    int level;


    
    // Update is called once per frame
    private void Start()
    {
        canmove = true;
        floor1 = true;
        level = 0;

        
    }

    void Update()
    {

        switch (move)
        {
        case 1:

        if (floor1 && canmove && (go.transform.position.y + 0.05f) >= f1.position.y)
        {
            Moveup(go.transform.position, f2.position);
            Moveup(doorgo.transform.position, f2.position);
                    floor1 = false;
                    floor2 = true;
                    level = 1;
                    
        }
        if (floor2  && canmove && (go.transform.position.y + 0.05f) >= f2.position.y)
        {
             Moveup(go.transform.position, f3.position);
             Moveup(doorgo.transform.position, f3.position);
                    floor2 = false;
                    floor3 = true;
                    level = 0;
                }
        if (floor3  && canmove && (go.transform.position.y + 0.05f) >= f3.position.y)
        {
            Moveup(go.transform.position, f4.position);
            Moveup(doorgo.transform.position, f4.position);
                    floor3 = false;
                    floor4 = true;
                    level = 1;
        }
       if (floor4  && canmove && (go.transform.position.y + 0.05f) >= f4.position.y)
        {
           Moveup(go.transform.position, f5.position);
                    Moveup(doorgo.transform.position, f5.position);
                    floor4 = false;
                    floor5 = true;
                    level = 2;
                }
                canmove = true;
        break;

            case 2:

                if (floor1  && canmove && (go.transform.position.y) <= f1.position.y)
                {
                    
                }
                if (floor2 && canmove)
                {
                    

                       

                        Movedown(go.transform.position, f1.position);
                    Movedown(doorgo.transform.position, f1.position);



                    floor2 = false;
                        floor1 = true;
                        level = 2;
                }
                if (floor3  && canmove)
                {
                    Movedown(go.transform.position, f2.position);
                    Movedown(doorgo.transform.position, f2.position);
                    floor3 = false;
                    floor2 = true;
                    level = 1;
                }
                if (floor4  && canmove)
                {
                    Movedown(go.transform.position, f3.position);
                    Movedown(doorgo.transform.position, f3.position);
                    floor4 = false;
                    floor3 = true;
                    level = 0;
                }
                if (floor5  && canmove)
                {
                    Movedown(go.transform.position, f4.position);
                    Movedown(doorgo.transform.position, f4.position);
                    floor5 = false;
                    floor4 = true;
                    level = 1;
                }
                canmove = true;

                break;



            case 3:

                
                if (doorgo.transform.position.z <= -145)
                {
                    doorgo.transform.Translate(new Vector3(0,0,-30) * Time.deltaTime);
                }
                if (true)
                {
                    //item check true close door 
                }
                
                break;
    }
}

    public void Moveup(Vector3 liftpos, Vector3 liftdest)
    {
        while (((liftdest.y - transform.position.y) >= 0.01f))
        {

            transform.position = Vector3.Lerp(transform.position, (liftdest + new Vector3(0,0.02f,0)), 0.5f);
            canmove = false;
            move = 3;
        }


    }

    public void Movedown(Vector3 liftpos, Vector3 liftdest)
    {
        while (((transform.position.y - liftdest.y) >= 0.1f))
        {
            transform.position = Vector3.Lerp(transform.position, liftdest, 0.5f);
        }

        canmove = false;
        move = 3;
    }

    public int getlevel()
    {

        return level;
    }


    void setmove(int index)
    {
        move = index;

    }

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            other.transform.parent = go.transform;
            Debug.Log("works");
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }


}
