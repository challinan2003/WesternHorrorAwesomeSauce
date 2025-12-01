using UnityEngine;

public class HeadBobV2 : MonoBehaviour
{
    [SerializeField, Range (0.001f, 0.1f)] private float amount = 0.002f;
    [SerializeField, Range (1f, 30f)] private float frequency = 10.0f;
    [SerializeField, Range (10f, 100f)] private float smooth = 10.0f;

    UnityEngine.Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        CheckHeadBobTrigger();
        StopHeadBob();
    }

    private void CheckHeadBobTrigger()
    {
        float inputMagnitude = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;
        

        if (inputMagnitude > 0)
        {
            StartHeadBob();       
        }
    }

    private UnityEngine.Vector3 StartHeadBob()
    {
        UnityEngine.Vector3 pos = UnityEngine.Vector3.zero;
        pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.deltaTime * frequency) * amount * 1.4f, smooth * Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.deltaTime * frequency / 2f) * amount * 1.6f, smooth * Time.deltaTime);
        transform.localPosition += pos;


        return pos;
    }

    private void StopHeadBob()
    {
        if (transform.localPosition == startPos) return;
        transform.localPosition = UnityEngine.Vector3.Lerp(transform.localPosition, startPos, 1 * Time.deltaTime);
    }
}
