using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    public bool signal;

    public GameObject expandBtn;
    public GameObject[] vConnect;
    private LineRenderer[] lineRends;

    private SpriteRenderer[] childrenRend;

    private Color32 applyAll = ColorThemes.objectColor;
    private Color32 tintCancel = new Color32(255, 255, 255, 255);

    private void Start()
    {
        lineRends = GetComponentsInChildren<LineRenderer>();
        childrenRend = GetComponentsInChildren<SpriteRenderer>();
        SetColors();
    }
    private void OnMouseDown()
    {
            StartCoroutine(active1Sec());
            FindObjectOfType<AudioManager>().Play("ClickDown");
            Vector3 a = new Vector3(expandBtn.transform.localScale.x * 1.25f, expandBtn.transform.localScale.y * 1.25f);
            expandBtn.transform.localScale = a;  
    }

    private void OnMouseUpAsButton()
    {
 
            FindObjectOfType<AudioManager>().Play("ClickUp");
            Vector3 b = new Vector3(1.0f, 1.0f);
            expandBtn.transform.localScale = b;
              
       
    }

    IEnumerator active1Sec()
    {
        signal = true;
        
        foreach(GameObject g in vConnect)
        {
            g.SetActive(true);
        }
        yield return new WaitForSeconds(0.25f);
        signal = false;
        foreach (GameObject g in vConnect)
        {
            g.SetActive(false);
        }
    }
    private void SetColors()
    {
        //Setting all colors to the same thing
        foreach (SpriteRenderer cRend in childrenRend)
        {
            cRend.material.SetColor("_Color", tintCancel);
            cRend.color = applyAll;
        }
        foreach (LineRenderer test in lineRends)
        {

            test.startColor = applyAll;
            test.endColor = applyAll;
        }
    }
     
}
