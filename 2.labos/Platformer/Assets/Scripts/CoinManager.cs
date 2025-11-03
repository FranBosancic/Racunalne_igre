using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    private int coinAmount;
    public TextMeshProUGUI coinText; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }

    public void changeCoins(int amountToAdd)
    {
        coinAmount += amountToAdd;
        coinText.text = coinAmount.ToString(); 
    }
}
