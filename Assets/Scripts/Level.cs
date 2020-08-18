using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayTime = 5;
    public void LoadGameOver()
    {
        StartCoroutine(GameOver());
        
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                         Application.Quit();
        #endif
    }
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("Game Over");
    }
}
