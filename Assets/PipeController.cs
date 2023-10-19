using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}