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
    void Update()
    {

        switch (move)
        {
        case 1:

        if (floor1 = true && canmove && (go.transform.position.y + 0.05f) >= f1.position.y)
        {
            Move(go.transform.position, f2.position);
                    floor1 = false;
                    floor2 = true;
                    
        }
        if (floor2 = true && canmove && (go.transform.position.y + 0.05f) >= f2.position.y)
        {
             Move(go.transform.position, f3.position);
                    floor2 = false;
                    floor3 = true;
        }
        if (floor3 = true && canmove && (go.transform.position.y + 0.05f) >= f3.position.y)
        {
            Move(go.transform.position, f4.position);
                    floor3 = false;
                    floor4 = true;
        }
       if (floor4 = true && canmove && (go.transform.position.y + 0.05f) >= f4.position.y)
        {
           Move(go.transform.position, f5.position);
                    floor4 = false;
                    floor5 = true;
        }
                canmove = false;
        break;

            case 2:

                if ((go.transform.position.y + 0.05f) >= f1.position.y)
                {
                    
                }
                else if ((go.transform.position.y + 0.05f) >= f2.position.y)
                {
                    Move(go.transform.position, f1.position);
                }
                else if ((go.transform.position.y + 0.05f) >= f3.position.y)
                {
                    Move(go.transform.position, f2.position);
                }
                else if ((go.transform.position.y + 0.05f) >= f4.position.y)
                {
                    Move(go.transform.position, f3.position);
                }
                else if ((go.transform.position.y + 0.05f) >= f5.position.y)
                {
                    Move(go.transform.position, f4.position);
                }
                break;



            case 3:


            break;
    }
}

    public void Move(Vector3 liftpos, Vector3 liftdest)
    {
        while (((liftdest.y - transform.position.y) >= 0.01))
        {

            transform.position = Vector3.Lerp(transform.position, (liftdest + new Vector3(0,0.02f,0)), 0.5f);
            canmove = false;
            move = 3;
        }


    }

}
