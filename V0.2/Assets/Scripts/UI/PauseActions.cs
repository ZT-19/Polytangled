using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseActions : MonoBehaviour
{
    public static bool gameIsPaused = false;
    // private CircleCollider2D[] all;

    private AudioSource[] soundSources;

    private SpriteRenderer rend;

    private int current;

    private bool playOnce = true;

    public GameObject theLevel;
    public GameObject nxtLvlBtn;

    public Canvas pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        current = nextLvl.next;
        if (current < SceneManager.GetActiveScene().buildIndex)
        {

            nxtLvlBtn.gameObject.SetActive(false);
        }
        rend = GetComponent<SpriteRenderer>();

        soundSources = theLevel.GetComponentsInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        current = nextLvl.next;
        if (current < SceneManager.GetActiveScene().buildIndex)
        {

            nxtLvlBtn.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(playOnce && CurrentLevelManager.lvlIsFinished)
        {
            StartCoroutine(fadeOut());
        
            
            playOnce = false;
            CurrentLevelManager.lvlIsFinished = false;
        }
    }

    private void OnMouseDown()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        foreach (AudioSource a in theLevel.GetComponentsInChildren<AudioSource>())
        {
            a.Play();   
        }
        foreach (Collider2D b in theLevel.GetComponentsInChildren<CircleCollider2D>())
        {
            b.enabled = true;
        }
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        foreach (AudioSource a in theLevel.GetComponentsInChildren<AudioSource>())
        {
            a.Pause();
        }
        foreach (Collider2D b in theLevel.GetComponentsInChildren<CircleCollider2D>())
        {
            b.enabled = false;
        }
      
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void previousLvl()
    {
        int k = SceneManager.GetActiveScene().buildIndex - 1;

        SceneManager.LoadScene(k);
        Time.timeScale = 1;
    }
    public void nextLevel()
    {
        int g = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(g);
        Time.timeScale = 1;
    }

    public void back2Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    IEnumerator fadeOut()
    {
        for(float f = 1; f >= 0; f -= 0.01f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;

            yield return new WaitForSeconds(0.01f);
        }
 
    }
}
