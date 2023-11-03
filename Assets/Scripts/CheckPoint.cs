using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isActive = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.lastCheckpoint = this.gameObject;
            }

            isActive = true;
        }
    }
}
