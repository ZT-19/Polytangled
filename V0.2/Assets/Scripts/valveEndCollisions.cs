using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;

public class valveEndCollisions : MonoBehaviour
{
    public bool activated = false;
    public bool receiveWire = false;
    private Valve parentRef;
    private SpriteRenderer rend;
    private wireEnds wireRef;
    private bool found = false;
    private void Start()
    {
        
        parentRef = GetComponentInParent<Valve>();
        rend = GetComponent<SpriteRenderer>();
      //  parentRef.vActivated = true;
        Color c = rend.color;
        c = ColorThemes.backgroundColor;
        rend.color = c;
    }
    private void Update()
    {
        

        if (activated)
        {
            if (found)
            {
                wireRef.runTimeFctns(1);
            }
        }
        if (receiveWire)
        {
            Debug.Log("re");
            ReceiveFWire();
            receiveWire = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<ToggleSwitch>())//gameObject ref
        {
            parentRef.vActivated = true;
            activated = true;
        }
        if (collision.gameObject.GetComponent<wireEnds>())//gameObject ref
        {
            Debug.Log("Found!");
            found = true;
            wireRef = collision.GetComponent<wireEnds>();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        parentRef.vActivated = false;
        activated = false;
        if (collision.gameObject.GetComponent<wireEnds>())//gameObject ref
        {
            Debug.Log("Left!");
            wireRef = null;
            found = false;
        }
    }
   /* public void runNumer()
    {
        forNow += 5;
        activated = true;
        Debug.Log("Run Num");
       // StartCoroutine(recieverSig());
    }
    IEnumerator recieverSig()
    {
        activated = true;
        yield return new WaitForSeconds(0.25f);
        activated = false;
    }*/

    public IEnumerator ReceiveFWire()
    {
        parentRef.vActivated = true;
        activated = true;
        Debug.Log("WORX");
        yield return new WaitForSeconds(5.25f);
        activated = false;
        parentRef.vActivated = true;
    }
}
