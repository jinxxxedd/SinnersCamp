using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exit pressed");  // Just for testing in the Editor
        Application.Quit();         // Actually quits the game when it's built
    }
}
