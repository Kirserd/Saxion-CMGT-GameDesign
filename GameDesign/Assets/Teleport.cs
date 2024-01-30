using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private string _targetScene;

    public void Invoke() 
    {
        SceneManager.LoadScene(_targetScene);
    }
}
