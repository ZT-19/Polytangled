using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenFadeOut : MonoBehaviour
{



    public Color c;
    private Color32 currentInstance = ColorThemes.backgroundColor;

    private Vector3 startPos = new Vector3(0, 0, -5);

    public int numberOfTFS;
    public int orderOfFade = 0;

    private SpriteRenderer screenRend;
    void Start()
    {
        transform.position = startPos;
        screenRend = gameObject.GetComponent<SpriteRenderer>();
        screenRend.material.color = currentInstance;
        StartCoroutine("FadeScreenIn");
    }

 
    void Update()
    {
        numberOfTFS = GameObject.FindGameObjectsWithTag("TFS").Length;
        if (GameObject.FindGameObjectsWithTag("TFS").Length > 0)
        {
            StartCoroutine("FadeScreenOut");
            for (int a = 0; a <= GameObject.FindGameObjectsWithTag("TFS").Length; a += 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("TFS"));
            }
        }
    }
    public IEnumerator FadeScreenOut()
    {
        for (float f = -0.05f; f <= 1.0; f += 0.01f)
        {
            c = screenRend.material.color;
            c.a = f;
            screenRend.material.color = c;

            yield return new WaitForSeconds(0.01f);
        }

        
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);


    }

   public IEnumerator FadeScreenIn()
    {
        yield return new WaitForSeconds(0.1f);
        for (float a = 1.0f; a >= -0.05; a -= 0.01f)
        {
            c = screenRend.material.color;
            c.a = a;
            screenRend.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }


    }






}
