using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public PlayerMovement playerMovement;
    [SerializeField] bool isEnabled = true;
    [SerializeField, Range (0, 0.1f)] private float headBobHeight = 0.015f;
    [SerializeField, Range (0, 30f)] private float headBobFrequency = 10.0f;
    private float minimumSpeedToHeadBob = 1f;
    public Transform cameraPos = null;
    private UnityEngine.Vector3 startPos;

    void Awake()
    {
        cameraPos.localPosition = startPos;
    }
    private UnityEngine.Vector3 HeadBobMotion()
    {
        UnityEngine.Debug.Log("Running this");
        UnityEngine.Vector3 pos = new UnityEngine.Vector3(0,0,0);
        pos.y += Mathf.Sin(Time.deltaTime * headBobFrequency) * headBobHeight;
        pos.x += Mathf.Cos(Time.deltaTime * headBobFrequency / 2) * headBobHeight * 2;
        return pos;
    }

    private void ResetCamera()
    {
        //print("cam resetting");
        if (cameraPos.localPosition == startPos) return;

        cameraPos.localPosition = UnityEngine.Vector3.Lerp(cameraPos.localPosition, startPos, 1 * Time.deltaTime);
    }

    private void CheckBob()
    {
        if (playerMovement.moveSpeed < minimumSpeedToHeadBob) return;
        if (!playerMovement.grounded) return;

        PlayMotion(HeadBobMotion());
        
    }

    private void PlayMotion(UnityEngine.Vector3 motion)
    {
        cameraPos.localPosition += motion;
    }
    void Update()
    {

        
        if (!isEnabled) return;

        CheckBob();
        ResetCamera();
    }
}
