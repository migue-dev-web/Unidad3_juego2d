using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            
        }
    }
}
