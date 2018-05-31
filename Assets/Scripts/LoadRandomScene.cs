using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRandomScene : MonoBehaviour {

    public void RandomSene(){
        Time.timeScale = 1;
        int sceneIndex = Random.Range(3, 7);
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
