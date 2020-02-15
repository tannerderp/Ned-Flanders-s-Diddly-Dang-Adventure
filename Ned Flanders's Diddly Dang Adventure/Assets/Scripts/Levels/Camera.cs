using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] bool followY = false; //whether the camera will also move on the y axis or not

    private float cameraY = 0;

    // Update is called once per frame
    void Update()
    {
        cameraY = 0;
        if(followY == true)
        {
            cameraY = Player.transform.position.y;
        }
        transform.position = new Vector3(Player.transform.position.x, cameraY, -10);
    }
}
