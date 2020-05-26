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
        position = transform.position;
    }

    public void Update()
    {
        transform.position = new Vector3(camera.flatten.x * position.x, camera.flatten.y * position.y, camera.flatten.z * position.z);
    }
    public void flatten(Vector3 flatten)
    {
        transform.position = new Vector3(flatten.x * position.x, flatten.y * position.y, flatten.z * position.z);
    }
}
