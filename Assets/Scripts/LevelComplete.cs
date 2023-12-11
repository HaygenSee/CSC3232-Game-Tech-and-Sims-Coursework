using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);  
        }
    }
}
