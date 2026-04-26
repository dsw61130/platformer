using UnityEngine;

public class coinComponent : MonoBehaviour
{
    public float coinBase = 0;
    public delegate void OnCoinCountHandler(float coinCounter);
    public event OnCoinCountHandler OnCoinCount;

    public int healValue = 10;
    public int coinsToHeal = 10;
    
    public HealthComponent healthComponent;

    public delegate void OnCoinCountInitialisedHandler(float coinCounter);
    public event OnCoinCountInitialisedHandler OnCoinCountInitialised;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnCoinCountInitialised?.Invoke(coinBase);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(float coinValue)
    {
        coinBase += coinValue;
        if (coinBase >= coinsToHeal)
        {
            healthComponent.RemoveDamage(healValue);
            coinBase -= coinsToHeal;
        }
        OnCoinCount?.Invoke(coinBase);
    }
}
