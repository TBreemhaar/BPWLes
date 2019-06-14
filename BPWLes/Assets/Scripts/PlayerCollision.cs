using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void CollisionsAreFun (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Finish")
        {
            Debug.Log("End");
            FindObjectOfType<GameManager>().EndMySuffering();

        }
    }
}
