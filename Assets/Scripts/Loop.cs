using UnityEngine;

public class Loop : MonoBehaviour
{
    [SerializeField] private Vector2 displacement = new Vector2(14f, 14f);
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.position += (Vector3)displacement;
        }
    }
}
