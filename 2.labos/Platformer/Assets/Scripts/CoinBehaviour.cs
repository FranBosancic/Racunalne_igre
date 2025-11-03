using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = CoinManager.instance; 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        coinManager.changeCoins(1);
        Destroy(gameObject);
    }
}
