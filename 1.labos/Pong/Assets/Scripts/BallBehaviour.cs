using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    public float speed = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Provjera da li je loptica udarila u lijevi reket
        if (col.gameObject.name == "RacketLeft")
        {
            // Provjera u koji dio reketa je loptica udarila
            float y = HitFactor(transform.position, col.transform.position,
            col.collider.bounds.size.y);
            // Normalizacija vektora
            Vector2 direction = new Vector2(1, y).normalized;
            // Pomicanje loptice
            GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        }
        // Provjera da li je loptica udarila u desni reket
        if (col.gameObject.name == "RacketRight")
        {
            // Provjera u koji dio reketa je loptica udarila
            float y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            // Normalizacija vektora
            Vector2 direction = new Vector2(-1, y).normalized;
            // Pomicanje loptice
            GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        }
    }

    private float HitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        // 1 <- gornji dio reketa
        // 0 <- sredina reketa
        // -1 <- donji dio reketa
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}
