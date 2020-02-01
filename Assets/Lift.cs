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
    // Update is called once per frame
    void Update()
    {

        switch (move)
        {
        case 1:

        if (go.transform.position.y == f1.position.y)
        {
            Move(go.transform.position, f2.position);
        }
        else if (go.transform.position.y == f2.position.y)
        {

        }
        else if (go.transform.position.y == f3.position.y)
        {

        }
        else if (go.transform.position.y == f4.position.y)
        {

        }
        else
        {

        }
        break;

            case 2:

        if (go.transform.position.y == f1.position.y)
        {

        }
        else if (go.transform.position.y == f2.position.y)
        {

        }
        else if (go.transform.position.y == f3.position.y)
        {

        }
        else if (go.transform.position.y == f4.position.y)
        {

        }
        else
        {

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

            transform.position = Vector3.Lerp(transform.position, liftdest, 0.5f);
        }


    }

}
