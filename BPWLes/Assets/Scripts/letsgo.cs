using UnityEngine;
using UnityEngine.SceneManagement;

public class letsgo : MonoBehaviour
{
    public void LetsGo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
