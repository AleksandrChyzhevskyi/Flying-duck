using UnityEngine;
using UnityEditor.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void restartGame()
    {
        EditorSceneManager.LoadScene("Menu", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
