using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    //Next Scene transition
    [Header("Transition")]
    [SerializeField] float transitionTime = 1.5f;

    //Quit
    [Header("QuitGame")]
    [SerializeField] int quitTime = 1;

    //Loads a certian Scene
    public void LoadSceneNumber(int sceneNumber)
    {
        StartCoroutine(ChangeSceneRoutine(sceneNumber));
    }

    IEnumerator ChangeSceneRoutine(int scene)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }

    //Reload Scene
    public void ReloadScene()
    {
        StartCoroutine(ReloaadSceneRoutine());
    }

    IEnumerator ReloaadSceneRoutine()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Quits the game
    public void Quit()
    {
        StartCoroutine(QuitGameRoutine());
    }

    IEnumerator QuitGameRoutine()
    {
        yield return new WaitForSeconds(quitTime);
        Application.Quit();
        Debug.Log("Quit");
    }
}