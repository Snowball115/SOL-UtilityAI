using UnityEditor;
using UnityEngine;

/// <summary>
/// Button to stop or exit scene
/// </summary>
public class RunStopScene : MonoBehaviour
{
    public void RunStopSceneButton()
    {
        if (EditorApplication.isPlaying) EditorApplication.ExitPlaymode();

        else Application.Quit();
    }
}
