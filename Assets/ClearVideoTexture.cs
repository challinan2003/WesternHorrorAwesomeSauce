using UnityEngine;

public class ClearVideoTexture : MonoBehaviour
{
    public RenderTexture rt;
    void Start()
    {
        rt.Release();
    }

}
