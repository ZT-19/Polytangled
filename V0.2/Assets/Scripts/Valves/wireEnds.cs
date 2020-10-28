using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireEnds : MonoBehaviour
{
    public bool signal = false;
    public bool reciever = false;
    public GameObject referenceEnd;
    private bool every5Sec = true;
    private bool found = false;


    void Start()
    {
        
    }
    private void Update()
    {
        if (reciever)
        {

            if (found)
            {
                if (every5Sec)
                {
                    Debug.Log("Sick");
                    every5Sec = false;
                    //testTrue();
                    referenceEnd.GetComponent<valveEndCollisions>().receiveWire = true;
                    StartCoroutine(wait5Seconds());

                }
            }           
        }
    }

    public void runTimeFctns(int x)
    {
        if (x == 1)
        {
            StartCoroutine(signalTrue());
        }
        if (x == 0)
        {
            StartCoroutine(recieverTrue());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<valveEndCollisions>())//gameObject ref
        {
            //  Debug.Log("valve to wire");
            referenceEnd = collision.gameObject;
            found = true;
        }
    }
    IEnumerator signalTrue()
    {
        signal = true;
        yield return new WaitForSeconds(0.25f);
        signal = false;
    }

    IEnumerator recieverTrue()
    {
        reciever = true;
        yield return new WaitForSeconds(0.25f);
        reciever = false;
    }

    IEnumerator wait5Seconds()
    {
        yield return new WaitForSeconds(5.0f);
        every5Sec = true;

    }
    

}
