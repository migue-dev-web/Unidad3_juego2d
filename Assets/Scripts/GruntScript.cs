using UnityEngine;

public class GruntScript : MonoBehaviour
{
   public GameObject John_idle_0;

   private float Lastshoot;

   public GameObject bulletPrefab;

   private int healt = 3;
    
    void Update()
    {
        if (John_idle_0 == null) return;

        Vector3 direccion = John_idle_0.transform.position - transform.position;
        if (direccion.x >= 0.0f ) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f );
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f );

        float distance = Mathf.Abs(John_idle_0.transform.position.x - transform.position.x);
        if (distance < 1.0f && Time.time > Lastshoot + 0.35f)
        {
            Shoot();
            Lastshoot = Time.time;
        }
    }

    private void Shoot(){
       Vector3 direction;
    if(transform.localScale.x == 1.0f)direction = Vector3.right;
    else direction = Vector3.left;
   GameObject Bullet = Instantiate(bulletPrefab, transform.position + direction * 0.15f, Quaternion.identity);
   Bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void hit()
    {
        healt = healt -1;
        if ( healt == 0){
            Destroy(gameObject);
        }
    }
}
