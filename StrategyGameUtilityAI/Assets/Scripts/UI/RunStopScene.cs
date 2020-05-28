using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RunStopScene : MonoBehaviour
{
    public void RunStopSceneButton()
    {
        if (EditorApplication.isPlaying) EditorApplication.ExitPlaymode();

        else Application.Quit();
    }
}
