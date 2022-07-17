using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [Header("Timer")]
    public float startTimer = 1;
    public float gameTimer = 2;
    public float endTimer = 3;

    [Header("Chrono")]
    protected float currentChrono = 0;
    [SerializeField] ChatBox _chronoText = null;

    public void Awake()
    {
        /*_chronoText._textMesh.enabled = false;*/
        _chronoText._textMesh.text = gameTimer.ToString();
        /*Event.current._onStartMiniGame += () => { _chronoText._textMesh.enabled = true; };*/
        if (!Event.current)
        {
            Debug.Log("is null");
        }
        Event.current._onStartMiniGame += () => { _chronoText._textMesh.gameObject.SetActive(true); };
        Event.current._onClearedMiniGame += () => { _chronoText._textMesh.gameObject.SetActive(false); };
    }

    void FixedUpdate()
    {
        
    }

    public virtual IEnumerator StartGame()
    {
        float time = Time.time;
        while (Time.time - time < startTimer)
            yield return null;

        StartCoroutine(StartTimer());
    }

    public virtual IEnumerator OnCleared()
    {
        _chronoText._textMesh.gameObject.SetActive(false);
        yield return null;
    }

    public IEnumerator StartTimer()
    {
        Event.current.OnStartMiniGame();
        Debug.Log("Start Game");

        float time = Time.time;
        while (Time.time - time < gameTimer)
        {
            currentChrono = Mathf.Round(Time.time - time);
            _chronoText._textMesh.text = Mathf.Round(gameTimer - currentChrono).ToString();
            yield return null;
        }

        Debug.Log("End Game");
        Event.current.OnEndMiniGame();
        StartCoroutine(OnCleared());
    }
}
