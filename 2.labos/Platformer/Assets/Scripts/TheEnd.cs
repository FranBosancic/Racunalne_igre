using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public GameObject winUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KepecTag")
        {
            Time.timeScale = 0;
            winUI.SetActive(true);
        }
    }
}
