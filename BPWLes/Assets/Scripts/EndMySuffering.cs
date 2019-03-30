using UnityEngine;

public class EndMySuffering : MonoBehaviour
{
    public GameManager gameManager;

   void OnTriggerEnter ()
    {
        gameManager.Done();
    }
}
