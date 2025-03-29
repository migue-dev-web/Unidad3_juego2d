using UnityEditor.Build.Content;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
             Debug.Log(" Moneda recogida!");
            GameManager.instance.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }

}
