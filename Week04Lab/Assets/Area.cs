using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    public CameraMode areaMode;

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Camera.main.GetComponent<CameraController>().cameramode = areaMode;
            if (areaMode == CameraMode.AreaZoom) {
                Camera.main.GetComponent<CameraController>().areaBounds = GetComponent<BoxCollider2D>().bounds;
            }
        }
    }
}
