using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;





public class OnCollision : MonoBehaviour
{

    public GameObject TrueForScreen;

    private OnClickTest[] reference;
    private OnClickTriangle[] triangleRef;
    private Switch[] switchRef;
    void Start()
    {
        reference = GetComponentsInParent<OnClickTest>();
        triangleRef = GetComponentsInParent<OnClickTriangle>();
        switchRef = GetComponentsInParent<Switch>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (!gameObject.CompareTag(collision.gameObject.tag))
        {

            FindObjectOfType<AudioManager>().Stop("Retraction");
            foreach (AudioSource stopAll in gameObject.GetComponentsInParent<AudioSource>())
            {
           
                stopAll.Stop();
            }
            FindObjectOfType<AudioManager>().Play("CollideError");
            
            foreach (OnClickTest c in reference)
            {
                c.connection = true;
            }
            foreach(OnClickTriangle A in triangleRef)
            {
                A.connection = true;
            }
            foreach(Switch S in switchRef)
            {
                S.connection = true;   
            }
            Instantiate(TrueForScreen);  
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)//For Triangle Btns to prevent object entering each others' hitboxes.
    {
        
        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            foreach (OnClickTriangle b in triangleRef)
            {
                b.endIt = true;
            }
        }
    }


}
