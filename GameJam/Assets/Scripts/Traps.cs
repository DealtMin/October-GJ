using Unity.VisualScripting;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.transform.position = respawnPoint.position;
        }
    }
}
