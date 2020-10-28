using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu2Game : MonoBehaviour
{

    
    private Vector3 startPos = new Vector3(0, 1, -2);
    private bool fadeFinished1 = false;
    private bool fadeFinished2 = false;
    private SpriteRenderer[] screenRend;
    private TextMeshProUGUI menuText;
    void Start()
    {
        transform.position = startPos;
        menuText = GetComponentInChildren<TextMeshProUGUI>();
        menuText.color = ColorThemes.objectColor;

        screenRend = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in screenRend)
        {
            s.color = ColorThemes.backgroundColor;
            s.material.SetColor("_Color", new Color32(255, 255, 255, 255));
            Color c = s.material.color;//
            c.a = 0;//
            s.material.color = c;
        }

    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Play Button").Length == 0)
        {
            StartCoroutine("FadeTextOut");
            StartCoroutine("FadeScreenOut");
            if (fadeFinished1 && fadeFinished2)
            {
                SceneManager.LoadScene(nextLvl.next + 1);
            }
        }   
    }
    IEnumerator FadeScreenOut()
    {
        for (float f = 0f; f <= 1f; f += 0.01f)
        {
            foreach (SpriteRenderer s in screenRend)
            {
                Color c = s.material.color;//
                c.a = f;//
                s.material.color = c;
            }
            yield return new WaitForSeconds(0.01f);
        }
        fadeFinished1 = true;
        
    }

    IEnumerator FadeTextIn()
    {
     
        for (float a = 0f; a <= 1f; a += 0.01f)
        {
            Color d = menuText.color;
            d.a = a;
            menuText.color = d;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeTextOut()
    {
        for(float a = 1f; a >= 0f; a -= 0.01f)
        {
            Color f = menuText.color;
            f.a = a;
            menuText.color = f;
            yield return new WaitForSeconds(0.01f);
            
        }
        fadeFinished2 = true;
    }

    public void goToSettings()
    {
        foreach(SpriteRenderer s in screenRend)
        {
            Color c = s.material.color;//
            c.a = 1f;//
            s.material.color = c;
        }
    }
}
