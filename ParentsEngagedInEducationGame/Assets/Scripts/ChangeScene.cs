using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToNewScene(string sceneName)
    {
        LevelManager.Instance.LoadScene(sceneName);
    }
}
