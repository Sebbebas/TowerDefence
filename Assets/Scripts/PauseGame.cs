using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    Animator cameraAnimator;

    public void Start()
    {
        cameraAnimator = FindObjectOfType<Camera>().GetComponent<Animator>();
    }

    public void Pause(bool a)
    {
        if (a) { Time.timeScale = 0; }
        else { Time.timeScale = 1; }
    }
    public void OpenPauseMenu(bool b)
    {
        cameraAnimator.SetBool("OpenPauseMenu", b);
        Pause(b);
    }
}
