using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public Patrols Patrols;

    public GunSystem gunSystem;
    void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag("Bullet"))
        {
     
            SoundManager.instance.PlayAudioResource(Random.Range(0,3));
            
            UnityEngine.Debug.Log("bullet hit!");
            Patrols.enemyHealth -= gunSystem.damage;
            UnityEngine.Debug.Log(Patrols.enemyHealth);
            Destroy(bullet.gameObject);
        }
    }
}
