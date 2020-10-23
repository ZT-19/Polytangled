using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeAllVales : MonoBehaviour
{

    public GameObject levelManager;
    private CurrentLevelManager scriptRef;
    private SpriteRenderer[] childrenRend;
    private LineRenderer[] lineRends;
    private bool runOnce = true;
    void Start()
    {
        scriptRef = levelManager.GetComponent<CurrentLevelManager>();
        lineRends = GetComponentsInChildren<LineRenderer>();
        childrenRend = GetComponentsInChildren<SpriteRenderer>();
        foreach (LineRenderer test in lineRends)
        {

            test.startColor = ColorThemes.objectColor;
            test.endColor = ColorThemes.objectColor;
        }
    }

    void Update()
    {
        if (scriptRef.fadeOutAllValves)
        {
            if (runOnce)
            {
                StartCoroutine(fadeAllChildren());
                FindObjectOfType<AudioManager>().Play("FadeAway");
                runOnce = false;
            }

        }
    }

    IEnumerator fadeAllChildren()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            foreach (LineRenderer lineRend in lineRends)
            {
                Color h = lineRend.startColor;
                h.a = f;
                lineRend.startColor = h;
                h = lineRend.endColor;
                h.a = f;
                lineRend.endColor = h;
            }
            foreach (SpriteRenderer cRend in childrenRend)
            {
                Color b = cRend.material.color;
                b.a = f;
                cRend.material.color = b;
            }


            yield return new WaitForSeconds(0.005f);

        }
        

    }
}


