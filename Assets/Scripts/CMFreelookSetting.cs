using Unity.Cinemachine;
using UnityEngine;

public class CMFreelookSetting : MonoBehaviour
{
    CinemachineCamera freelook;
    public float zoomSpeed = 2.5f;
    private void Start()
    {
        freelook = GetComponent<CinemachineCamera>();
    }

    private void Update()
    {
        ZoomInZoomOut();
    }

    //  카메라 Zoom in & Zoom Out 구현
    void ZoomInZoomOut()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput < 0) // 휠 내리면
        {
            if (freelook.Lens.FieldOfView >= 20)
                freelook.Lens.FieldOfView -= zoomSpeed * Time.deltaTime; //Zoom In
        }

        if (wheelInput > 0) // 휠 올리면
        {
            if (freelook.Lens.FieldOfView <= 60)
                freelook.Lens.FieldOfView += zoomSpeed * Time.deltaTime; //Zoom Out
        }
    }
}