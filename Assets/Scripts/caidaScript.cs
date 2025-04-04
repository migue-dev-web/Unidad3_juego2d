using UnityEngine;

public class caidaScript : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D collision){
    JhonMov jhon = collision.GetComponent<JhonMov>();

    if (jhon != null){
            jhon.hit(5);
            Debug.Log("has caido");
        }
 }
}
