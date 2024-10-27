using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene4Interview : MonoBehaviour
{
    public void Switch2Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}