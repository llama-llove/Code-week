using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flattening : MonoBehaviour
{
    public Vector3 position;
    public cameracontroller camera;
    // Start is called before the first frame update
    void Start()
    {
        // sets the true position of the object
        position = transform.position;
    }

    public void Update()
    {
        // flattens the object along the flat axis
        transform.position = new Vector3(camera.flatten.x * position.x, camera.flatten.y * position.y, camera.flatten.z * position.z);
    }

}
