using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class OnClickTest : MonoBehaviour
{
    
    public bool clicked;
    public bool fadefinished;
    public bool connection = false;

    public float childy;

    private float speed = 0.25f;
    private float receiveSpeed = 2;
    private float rate = 2;
    private float maxReceiverHeight;
    private float origSize;

    public int clickTime ;
    private int timesClicked;

    public GameObject child1;
    public GameObject hookr;
    public GameObject hooka;
    public GameObject receiver;
    public GameObject expandBtn;

    private LineRenderer[] lineRends;
    
    private SpriteRenderer[] childrenRend;

    private Color32 applyAll = ColorThemes.objectColor;
    private Color32 tintCancel = new Color32(255, 255, 255, 255);
    void Start()
    {

        maxReceiverHeight = 1.5f * receiver.transform.localScale.y;

        lineRends = GetComponentsInChildren<LineRenderer>();
        childrenRend = GetComponentsInChildren<SpriteRenderer>();
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
        hookr.transform.position = hooka.transform.position;
        origSize = receiver.transform.localScale.y;
    }

    private void FixedUpdate()
    {
        hookr.transform.position = hooka.transform.position;
       
    }

    void Update()
    {

    
        childy = child1.transform.localScale.y;//shows var
        
        if (clicked)
        {
            if (receiver.transform.localScale.y < maxReceiverHeight)
            {
                Vector3 vc = new Vector3(receiver.transform.localScale.x, receiver.transform.localScale.y + rate * receiveSpeed * Time.deltaTime);
                receiver.transform.localScale = vc;
            }
            if (!connection)
            {
                if (childy > 0)
                {
                    
                    Vector3 vec = new Vector3(child1.transform.localScale.x, childy - rate * speed * Time.deltaTime);
                    child1.transform.localScale = vec;
             


                }
            }
            if (childy <= 0)
            {
                FindObjectOfType<AudioManager>().PlayOnObject(0, gameObject, "Retraction");//stops sound
               // FindObjectOfType<AudioManager>().Stop("Retraction");
                child1.SetActive(false);
                expandBtn.SetActive(false);
                clicked = false;
                StartCoroutine("Fadeout");
                FindObjectOfType<AudioManager>().Play("FadeAway");
                while (receiver.transform.localScale.y > origSize )
                {
                    Vector3 cv = new Vector3(receiver.transform.localScale.x, receiver.transform.localScale.y - rate * receiveSpeed * 0.05f * Time.deltaTime);
                    receiver.transform.localScale = cv;

                }
                hookr.SetActive(false);

            } 
            
        }

        if (fadefinished)
        {
            hookr.SetActive(false);
            Destroy(hookr);
            Destroy(gameObject);
            fadefinished = false;

        }

        hookr.transform.position = hooka.transform.position;
    }

    
    void OnMouseDown()
    {

        timesClicked ++;
        if (!connection)
        {
            if (timesClicked <= clickTime)
            {

                FindObjectOfType<AudioManager>().Play("ClickDown");
                
                FindObjectOfType<AudioManager>().PlayOnObject(1, gameObject, "Retraction");
                Vector3 a = new Vector3(expandBtn.transform.localScale.x * 1.25f, expandBtn.transform.localScale.y * 1.25f);
                expandBtn.transform.localScale = a;

            }

            clicked = true;
        }
    }


    private void OnMouseUpAsButton()
    {
        if (!connection)
        {
            if (timesClicked <= clickTime)
            {
                FindObjectOfType<AudioManager>().Play("ClickUp");
                Vector3 b = new Vector3(1.0f, 1.0f);
                expandBtn.transform.localScale = b;
            }
        }

    }

    IEnumerator Fadeout()
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
         

            yield return new WaitForSeconds(0.01f);

        }
        fadefinished = true;

    }


}
     
    


    
