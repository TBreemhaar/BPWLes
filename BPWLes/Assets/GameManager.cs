using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameEnd = false;

    public void Done()
    {
        SceneManager.LoadScene("Quit");
    }

    public void EndMySuffering ()
    {
        if (GameEnd == false)
        {
            GameEnd = true;
        }
        
    }
}
