using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
             Debug.Log("Win!!");
                SceneManager.LoadScene("HasGanado");
            Destroy(gameObject);
        }
    }
}
