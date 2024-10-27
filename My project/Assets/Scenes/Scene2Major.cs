using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2Major : MonoBehaviour
{
    public void Switch2Major(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}