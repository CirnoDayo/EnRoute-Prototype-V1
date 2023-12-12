using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputToChangeScene :MonoBehaviour
{
    public string SceneName;

    private bool TargetKey;
    public void Input()
    {
        TargetKey = true;
    }
    private void Update()
    {
        GameManager GM = FindObjectOfType<GameManager>();
        if (TargetKey && GM != null)
        {
            GM.UpcomingScene = SceneName;
            GM.SceneChangeInput = true;
        }
    }
}
