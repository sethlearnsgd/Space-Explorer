using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneMenu : MonoBehaviour
{
    [SerializeField] private GameObject deathText;
    [SerializeField] private GameObject jkText;
    
    void Start()
    {
        deathText.SetActive(true);
        jkText.SetActive(false);
    }

    
    void Update()
    {
        float currentTime = Time.timeSinceLevelLoad;
        if(currentTime >= 5f && currentTime <= 7f)
        {
            deathText.SetActive(false);
            jkText.SetActive(true);
        }
        if(currentTime > 7f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
