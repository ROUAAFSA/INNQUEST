using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Scene Trigger")]
    [SerializeField] private GameObject sctrigger;
    
    private bool playerInRange;

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        if (playerInRange) 
        {
            visualCue.SetActive(true);
            if (Input.GetKeyUp(KeyCode.Space))
            {
               sctrigger.SetActive(true);
            }
            
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}