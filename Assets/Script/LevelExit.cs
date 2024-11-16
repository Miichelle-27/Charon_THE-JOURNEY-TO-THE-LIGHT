using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public SoulsManager soulsManager;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish") || collision.gameObject.CompareTag("Antorcha"))
        {
            if (collision.otherCollider.gameObject.CompareTag("Player"))
            {
                if (soulsManager.soulsCollected == soulsManager.totalSouls)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }

}
