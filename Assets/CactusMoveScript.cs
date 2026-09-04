using UnityEngine;

public class CactusMoveScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float deadZone = -15f; // Where the cactus gets destroyed off-screen
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
