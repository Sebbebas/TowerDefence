using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    //Next Scene transition
    [Header("Transition")]
    [SerializeField] Animator transition;
    [SerializeField] string boolName;
    [SerializeField] float transitionTime = 1f;

    //Quit
    [Header("QuitGame")]
    [SerializeField] float quitTime = 0f;

    //Loads a certian Scene
    public void LoadSceneNumber(int sceneNumber)
    {
        StartCoroutine(ChangeSceneRoutine(sceneNumber));
    }

    IEnumerator ChangeSceneRoutine(int scene)
    {
        PlayAnimation();
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
        PlayAnimation();
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //PlayAnimation
    void PlayAnimation()
    {
        if(transition == null) { return; }

        transition.SetBool(boolName, true);
    }


    //Quits the game
    public void Quit()
    {
        PlayAnimation();
        StartCoroutine(QuitGameRoutine());
    }

    IEnumerator QuitGameRoutine()
    {
        yield return new WaitForSeconds(quitTime);
        Application.Quit();
        Debug.Log("Quit");
    }
}