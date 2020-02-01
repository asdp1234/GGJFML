using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField]
    int move;
    [SerializeField]
    GameObject go;
    [SerializeField]
    Transform f1, f2, f3, f4, f5;
    [SerializeField]
    bool floor1, floor2, floor3, floor4, floor5;
    [SerializeField]
    bool canmove = true;
    // Update is called once per frame
    private void Start()
    {
        canmove = true;
        floor1 = true;
    }

    void Update()
    {

        switch (move)
        {
        case 1:

        if (floor1 && canmove && (go.transform.position.y + 0.05f) >= f1.position.y)
        {
            Moveup(go.transform.position, f2.position);
                    floor1 = false;
                    floor2 = true;
                    
        }
        if (floor2  && canmove && (go.transform.position.y + 0.05f) >= f2.position.y)
        {
             Moveup(go.transform.position, f3.position);
                    floor2 = false;
                    floor3 = true;
        }
        if (floor3  && canmove && (go.transform.position.y + 0.05f) >= f3.position.y)
        {
            Moveup(go.transform.position, f4.position);
                    floor3 = false;
                    floor4 = true;
        }
       if (floor4  && canmove && (go.transform.position.y + 0.05f) >= f4.position.y)
        {
           Moveup(go.transform.position, f5.position);
                    floor4 = false;
                    floor5 = true;
        }
                canmove = true;
        break;

            case 2:

                if (floor1  && canmove && (go.transform.position.y) <= f1.position.y)
                {
                    
                }
                if (floor2 && canmove)
                {
                    //if ((go.transform.position.y) <= f2.position.y)
                    //{

                        Debug.Log("pos1" + go.transform.position.y);
                        Debug.Log("pos2" + f2.position.y);

                        Movedown(go.transform.position, f1.position);

                        Debug.Log("pos1" + go.transform.position.y);
                        Debug.Log("pos2" + f2.position.y);

                        floor2 = false;
                        floor1 = true;
                    //}
                }
                if (floor3  && canmove)
                {
                    Movedown(go.transform.position, f2.position);
                    floor3 = false;
                    floor2 = true;
                }
                if (floor4  && canmove)
                {
                    Movedown(go.transform.position, f3.position);
                    floor4 = false;
                    floor3 = true;
                }
                if (floor5  && canmove)
                {
                    Movedown(go.transform.position, f4.position);
                    floor5 = false;
                    floor4 = true;
                }
                canmove = true;

                break;



            case 3:


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
}
