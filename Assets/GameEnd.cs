using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject Death;
    public float DeathTimer;

    void Update()
    {
        //if (Death.SetActive(true))
        //{
            //DeathTimer += Time.deltaTime;
        //}

        if (DeathTimer >= 5)
        {
            DeathTimer = 0;
            //SceneManager.LoadScene("Vertical Slice Level");
        }
    }

}
