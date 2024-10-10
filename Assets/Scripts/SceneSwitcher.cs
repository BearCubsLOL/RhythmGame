using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ButtonChecker(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}