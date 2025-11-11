using UnityEngine;

public class bulletTimer : MonoBehaviour
{
    private float bulletClock = 4;
    void Update()
    {
        bulletClock -= Time.deltaTime;

        if (bulletClock <= 0)
        {
            Destroy(gameObject);
        }
    }
}
