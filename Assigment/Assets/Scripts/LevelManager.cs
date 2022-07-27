using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;

  public void LoadGame()
  {
      SceneManager.LoadScene("Main Level");
  }
  public void LoadMainMenu()
  {
      SceneManager.LoadScene("MainMenu");
  }

  public void LoadFinsih()
  {
      StartCoroutine(WaitAndLoad("Finish", sceneLoadDelay));
  }
  public void QuitGame()
  {
      Debug.Log("Quitting");
      Application.Quit();
  }
  IEnumerator WaitAndLoad(string sceneName, float delay)
    {
       yield return new WaitForSeconds(delay);
       SceneManager.LoadScene(sceneName);
    }
}

