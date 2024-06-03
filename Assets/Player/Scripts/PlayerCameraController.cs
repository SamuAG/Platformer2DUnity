using Cinemachine;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    CinemachineVirtualCamera vCam;
    [SerializeField] float changeVelocity = 1f;
    [SerializeField] Vector3 offset = new Vector3(5,0,-10);
    Vector3 appliedOffset;
    [SerializeField] Rigidbody2D rb;
    
    void Start()
    {
        appliedOffset = offset;
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (rb.velocity.x != 0) 
            appliedOffset = Vector3.Lerp(appliedOffset, new Vector3(rb.velocity.x < 0 ? -offset.x : offset.x, offset.y, offset.z), changeVelocity * Time.deltaTime);
        vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = appliedOffset;
    }
}
