using UnityEngine;

public class RacketBehaviour : MonoBehaviour
{

    public float speed = 30;
    public string input_axis_name = "Vertical";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // Dohvat pomaka po vertikalnoj osi
        float vertical = Input.GetAxis(input_axis_name);
        // Pomicanje objekta
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, vertical) * speed;
    }
}
