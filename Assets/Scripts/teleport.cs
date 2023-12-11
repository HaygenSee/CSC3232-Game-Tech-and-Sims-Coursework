using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public GameObject dead, player;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(delay());  
        }
    }

    private IEnumerator delay()
    {
        dead.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(3);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(currentScene.buildIndex); 
    }
}
