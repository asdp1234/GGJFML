using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    [SerializeField]
    string[] qte;
    [SerializeField]
    int[] choose;
    [SerializeField]
    int level;
    [SerializeField]
    bool qteloop;
    float currenttime;
    [SerializeField]
    float[] neededtime;
    [SerializeField]
    int qtestate;
    [SerializeField]
    GameObject go;
    new Vector3 startpos;
    [SerializeField]
    bool on,restart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (on)
        {

            if (restart)
            {
                choice();
                qtestate = 0;
                startpos = go.transform.position;
                restart = false;
            }



            go.transform.Translate(new Vector3(0, 60, 0) * Time.deltaTime);



            if (Input.anyKey)
            {

                if (Input.GetKeyUp(qte[choose[qtestate]]))
                {

                    qtestate++;
                }
                else
                {
                    //loose
                    go.transform.position = go.transform.position;
                    on = false;
                }
            }

            if (qtestate >= 4)
            {
                go.transform.position = go.transform.position;
                on = false;

                //win
            }
            Loose();

        }
        else
        {
            restart = true;
        }
    }

    void Loose()
    {
        currenttime += Time.deltaTime;

        if (currenttime >= neededtime[level])//time elapstd
        {
            //loose
            go.transform.position = go.transform.position;
            on = false;

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