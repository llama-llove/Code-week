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
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody>();
        inair = false;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    private void OnCollisionStay(Collision collision)
    {
        touching = collision.gameObject; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        inair = false;
    }
}
