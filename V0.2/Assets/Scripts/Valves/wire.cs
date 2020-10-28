using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
    public List<GameObject> ends;
    public bool receiveSignal = false;


    void Update()
    {
        if (ends[0].GetComponent<wireEnds>().signal)
        {
            ends[1].GetComponent<wireEnds>().runTimeFctns(0);
        }       
        if (ends[1].GetComponent<wireEnds>().signal)
        {
            ends[0].GetComponent<wireEnds>().runTimeFctns(0);
        }
        
    }

}
