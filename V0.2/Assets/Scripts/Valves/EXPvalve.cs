using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPvalve : MonoBehaviour
{
    public bool signal = false;
    private bool coolDown = false;
    private SpriteRenderer valveRend;
    private Color32 vObjectColor = ColorThemes.objectColor;
    // Start is called before the first frame update
    void Start()
    {

        //   valveRend.material.SetColor("_Color", tintCancel);
        valveRend = GetComponent<SpriteRenderer>();
        valveRend.color = vObjectColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<ToggleSwitch>())
        {
            QuarterSecondSignal();
            Debug.Log("Valve Signal On");
        }
        if (collision.gameObject.GetComponent<wireEnds>())
        {
            //Note: calling function from other scripts applies to that gameobject
            wireEnds tempObj = collision.gameObject.GetComponent<wireEnds>();

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
    private IEnumerator QuarterSecondSignal()
    {
        signal = true;
        yield return new WaitForSeconds(0.25f);
        signal = false;
    }
    private IEnumerator turnValve()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.Rotate(0.0f, 0.0f, -9.0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
