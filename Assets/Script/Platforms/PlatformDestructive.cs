using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformDestructive : MonoBehaviour
{
    public float intensity;
    public float time;
    public float waitingTime;
    
    private Vector3 _originalPosition;
    private Coroutine _vibration;

    void Start()
    {
        intensity = 0.08f;
        time = 2f;
        waitingTime = 1f;

        _originalPosition = transform.position;
        _vibration = StartCoroutine(Vibration());
    }
    
    IEnumerator Vibration()
    {
        while (true)
        {
            float offsetX = Random.Range(-intensity, intensity);
            float offsetY = Random.Range(-intensity, intensity);
            transform.position = _originalPosition + new Vector3(offsetX, offsetY, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Dissapear", waitingTime);
        }
    }
    private void Dissapear() // Efecto de desaparición
    {
        if (_vibration != null)
        {
            StopAllCoroutines();
        }
        gameObject.SetActive(false);
        Invoke("Reappear", time);
    }

    private void Reappear()
    {
        gameObject.SetActive(true);
        _vibration = StartCoroutine(Vibration());
    }
}
