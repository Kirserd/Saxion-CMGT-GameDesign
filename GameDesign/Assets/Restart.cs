using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Invoke()
    {
        GameProgress.Reset();
        SceneManager.LoadScene("Level 0");
    }
}
