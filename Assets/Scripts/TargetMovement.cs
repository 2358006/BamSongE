using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    float moveTarget;
    void Update()
    {
        if (transform.position.x >= 10 || transform.position.x <= -10)
        {
            moveTarget *= -1;
        }
    }
}
