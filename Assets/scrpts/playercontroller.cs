using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public int speed;
    public Rigidbody self;
    public cameracontroller camera;
    public float jumpspeed;
    public GameObject touching;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // movement script
        if (Input.GetKey("a"))
        {
            self.MovePosition(transform.position+camera.move * -1 * speed*Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            self.MovePosition(transform.position + camera.move * 1 * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            self.AddForce(0,jumpspeed,0);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        touching = collision.gameObject; 
    }
    private void OnCollisionExit(Collision collision)
    {
        touching = null;
    }
}
