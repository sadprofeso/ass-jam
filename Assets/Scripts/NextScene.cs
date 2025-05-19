using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void GoToNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            // Reload current scene if next scene doesn't exist
            SceneManager.LoadScene(currentIndex);
        }
    }

    public void GoToPreviousScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int prevIndex = currentIndex - 1;

        if (prevIndex >= 0)
        {
            SceneManager.LoadScene(prevIndex);
        }
        else
        {
            // Reload current scene if previous scene doesn't exist
            SceneManager.LoadScene(currentIndex);
        }
    }
}