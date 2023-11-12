using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] bool debug;

    Animator cameraAnimator;

    public void Start()
    {
        cameraAnimator = FindObjectOfType<Camera>().GetComponent<Animator>();
    }

    private void Update()
    {
        if (!debug) { return; }
        Debug.Log(Time.timeScale);
    }

    public void Pause(bool a)
    {
        if (a) { Time.timeScale = 0; }  // a = true
        else { Time.timeScale = 1; }    // a = false
    }
    public void OpenPauseMenu(bool b)
    {
        cameraAnimator.SetBool("OpenPauseMenu", b);
        Pause(b);
    }
}
