using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    private SpriteRenderer valveRend;
    //private Color32 tintCancel = new Color32(255, 255, 255, 255);
    public bool vActivated = false;
    private bool coolDown = false;
    private valveEndCollisions[] childRef;
    private Color32 vObjectColor = ColorThemes.objectColor;
    void Start()
    {
        childRef = GetComponentsInChildren<valveEndCollisions>();
        valveRend = GetComponent<SpriteRenderer>();
   //   valveRend.material.SetColor("_Color", tintCancel);
        valveRend.color = vObjectColor;
    }

    void Update()
    {
        if (vActivated)
        {
            foreach(valveEndCollisions v in childRef)
            {
                v.activated = true;
            }
        }
        else
        {
            foreach (valveEndCollisions v in childRef)
            {
                v.activated = false;
            }
        }
    }

    private void OnMouseDown()
    {

        if (!coolDown)
        {
            StartCoroutine(turnValve());
            FindObjectOfType<AudioManager>().Play("Valve");
            Invoke("ResetCoolDown", 0.25f);
            coolDown = true;
        }
            
        
    }

    void ResetCoolDown()
    {
        coolDown = false;
    }

    IEnumerator turnValve()
    {
        for(int i = 0; i<10; i++)
        {
            transform.Rotate(0.0f, 0.0f, -9.0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
