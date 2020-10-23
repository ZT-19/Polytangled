using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class CurrentLevelManager : MonoBehaviour
{
    public static bool lvlIsFinished = false;
    public bool fadeOutAllValves = false;

    private bool fadeFinished;
   // private bool fadeFinished2 = false;
    private bool playOnce = true;
    private bool secPassed = false;
    private int y;

    public int current;

  //  private GameObject fadeScreenRef;
  //  private SpriteRenderer fsrRend;

    private TextMeshProUGUI lvlIndicateText;

    public Button rightBtn;
    private Button[] btn;

    private Color32 textColor = ColorThemes.objectColor;

    // Start is called before the first frame update
    void Start()
    {
        current = nextLvl.next;
        lvlIndicateText = GetComponentInChildren<TextMeshProUGUI>();
        btn = GetComponentsInChildren<Button>(); 
        foreach (Button b in btn)
          {
              ColorBlock applyAll = b.colors;
              applyAll.normalColor = textColor;
           
              applyAll.highlightedColor = textColor;
              applyAll.pressedColor = textColor;
              applyAll.selectedColor = textColor;
              applyAll.disabledColor = textColor;
              b.colors = applyAll;

          }
        if(current < SceneManager.GetActiveScene().buildIndex )
        {
            
            rightBtn.gameObject.SetActive(false);
        }
        //fadeScreenRef = GameObject.FindGameObjectWithTag("Finish");
       // fsrRend = fadeScreenRef.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        current = nextLvl.next;

        y = SceneManager.GetActiveScene().buildIndex;
          if (transform.childCount <= 1)
          {
            fadeOutAllValves = true;
            StartCoroutine("Wait1Sec");
            if (secPassed)
            {
                
                y++;
                if (y <= SceneManager.sceneCountInBuildSettings - 1)
                {
                    if (playOnce)
                    {
                        if (!rightBtn.IsActive())
                        {
                            nextLvl.next++;//potential rework using current index
                        }
                        FindObjectOfType<AudioManager>().Play("NextLevelTone");
                        playOnce = false;
                    }
                //    StartCoroutine(screenFade());
             //       if (fadeFinished2 && nextLvl.next > 19)
                //    {
                        lvlIndicateText.color = textColor;
                        lvlIndicateText.text = (y).ToString();
                        StartCoroutine("TextFade");
                        lvlIsFinished = false;
                   // }
                    if (fadeFinished)
                    {
                        
                        SceneManager.LoadScene(y);
                        Debug.Log(y);//does not show current scene, but the scene about to be loaded
                    }
                }
                if (y > SceneManager.sceneCountInBuildSettings - 1)
                {
                    if (playOnce)
                    {
                        FindObjectOfType<AudioManager>().Play("NextLevelTone");
                        playOnce = false;
                    }
                    lvlIndicateText.color = textColor;
                    lvlIndicateText.text = "Thanks for playing! Source code in desc :)";
                    
                    StartCoroutine(TextFade());
                    StartCoroutine(Back2Menu());
                }
                secPassed = false;
            }
            
       
          }
    }

  /*  IEnumerator screenFade()
    {
        for (float f = 0; f <= 1.0f; f += 0.05f)
        {
            Color b = fsrRend.material.color;
            b.a = f;
            fsrRend.material.color = b;
            yield return new WaitForSeconds(0.04f);
        }
        fadeFinished2 = true;
    }*/
    IEnumerator TextFade()
    {
        for (float f = 0; f <= 1.0f; f+= 0.01f)
        {
            Color c = lvlIndicateText.color;
            c.a = f;
            lvlIndicateText.color = c;

            yield return new WaitForSeconds(0.01f);
        }
        for (float f = 1.0f; f >= -0.05; f -= 0.01f)
        {
            Color c = lvlIndicateText.color;
            c.a = f;
            lvlIndicateText.color = c;

            yield return new WaitForSeconds(0.01f);
        }
        fadeFinished = true;
        lvlIsFinished = false;
    }

    IEnumerator Wait1Sec()
    {
        lvlIsFinished = true;
        yield return new WaitForSeconds(1f);
        secPassed = true;
        
    }
//
    IEnumerator Back2Menu()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(0);
    }

    public void previous()
    {
        int k = SceneManager.GetActiveScene().buildIndex - 1;
        
        SceneManager.LoadScene(k);
    }

    public void nextLevel()
    {
        int g = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(g);
    }
    //
}
