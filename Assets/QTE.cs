using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    [SerializeField]
    string[] qte;
    int[] choose;
    int level;
    bool qteloop;
    float currenttime;
    [SerializeField]
    float[] neededtime;
    [SerializeField]
    int qtestate;

    // Start is called before the first frame update
    void Start()
    {
        choice();
        qtestate = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.anyKey)
        {

            if (Input.GetKeyUp(qte[choose[qtestate]]))
            {

                qtestate++;
            }
            else
            {
                //loose
                Destroy(this);
            }
        }

        if (qtestate >= 4)
        {
            Destroy(this);
            //win
        }
        Loose();
          
           
        
    }

    void Loose()
    {
        currenttime += Time.deltaTime;

        if (currenttime >= neededtime[level])//time elapstd
        {
            //loose
            Destroy(this);
        }
    }


    void choice()
    {
        for (int i = 0; i < 4; i++)
        {

            choose[i] = Random.Range(0, 5);
        }
        
    }
}