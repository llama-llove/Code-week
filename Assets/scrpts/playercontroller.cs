using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public int speed;
    public Rigidbody self;
    public cameracontroller camera;
    public float jumpspeed;
    public GameObject touching;
    public bool inair;
    public float deathlevel;
    public Vector3 Coords;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody>();
        inair = false;
        Coords = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(Coords);
        if (transform.position.y <= deathlevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // movement script
        if (Input.GetKey("a"))
        {
            self.MovePosition(transform.position+camera.move * -1 * speed*Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            self.MovePosition(transform.position + camera.move * 1 * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&inair==false)
        {
            self.AddForce(0,jumpspeed,0); 
            inair = true;
        }

        Coords = new Vector3(Coords.x+(transform.position.x-Coords.x)*camera.flatten.x,Coords.y + (transform.position.y - Coords.y) * camera.flatten.y, Coords.z + (transform.position.z - Coords.z) * camera.flatten.z);
        transform.position = new Vector3(camera.flatten.x * Coords.x, camera.flatten.y * Coords.y, camera.flatten.z * Coords.z);
    }
    private void OnCollisionStay(Collision collision)
    {
        touching = collision.gameObject; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        inair = false;
    }
    public void turnstay()
    {
        transform.position = new Vector3(camera.flatten.x * Coords.x, camera.flatten.y * Coords.y, camera.flatten.z * Coords.z);
    }
}
