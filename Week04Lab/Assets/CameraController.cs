using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public CameraMode cameramode;
    public GameObject player;
    public Vector3 zoomTarget;
    public float MaxZoomOut;
    public Bounds areaBounds;

	// Use this for initialization
	void Start () {
        cameramode = CameraMode.PlayerFollow;
        MaxZoomOut = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        switch (cameramode) {
            case CameraMode.PlayerFollow:
                print("follow");
                transform.position = new Vector3(player.transform.position.x, 0,-10);
                Camera.main.orthographicSize = 2;

                break;

            case CameraMode.AreaView:
                print("full");
                transform.position = new Vector3(0, 0, -10);
                Camera.main.orthographicSize = MaxZoomOut;
                break;

            case CameraMode.AreaZoom:
                
                transform.position = new Vector3(player.transform.position.x, 0, -10);
                float totalDistance = areaBounds.size.x;
                float distance = Vector3.Distance(player.transform.position, areaBounds.center + new Vector3(areaBounds.max.x,0,0));
                print(distance/totalDistance);
                Camera.main.orthographicSize = Mathf.Lerp( MaxZoomOut, 2,(distance / totalDistance) -1);
                break;
        }
	}
}

public enum CameraMode {
    PlayerFollow, AreaView, AreaZoom
}
