using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Animator animator;
    public Vector3 move;
    public Vector3 flatten;
    public Vector3 Vect;
    public bool isturning;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        // creates variables and starts "SetStart" as the level flys in
        isturning = true;
        flatten = new Vector3(1,1,1);
        Invoke("SetStart",.75f);
    }

    // Update is called once per frame
    void Update()
    {
        // camera moves to player position
        gameObject.transform.localPosition = new Vector3(player.position.x,player.position.y,player.position.z);
        // if it's already turning you can't turn it more
        if (isturning==false)
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isturning = true;
                //unparents the character
                player.SetParent(null, true);
                flatten = Vector3.one;
                animator.SetBool("left", true);
                Invoke("stop", .1f);
                Invoke("set", .25f);
                // parents the character to the object below it
                RaycastHit hit;
                if (Physics.Raycast(player.position, Vector3.down, out hit,.5f))
                {
                    Debug.Log(hit.collider.gameObject);
                    if (hit.collider.gameObject != null)
                    {
                        player.SetParent(hit.collider.gameObject.transform, true);
                    }
                }
                else
                {
                    player.SetParent(player.GetComponent<playercontroller>().touching.transform, true);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isturning = true;
                //unparents the character
                player.SetParent(null, true);
                flatten = Vector3.one;
                animator.SetBool("right", true);
                Invoke("stop", .1f);
                Invoke("set", .25f);
                // parents the character to the object below it
                RaycastHit hit;
                if (Physics.Raycast(player.position, Vector3.down, out hit, .5f))
                {
                    Debug.Log(hit.collider.gameObject);
                    if (hit.collider.gameObject != null)
                    {
                        player.SetParent(hit.collider.gameObject.transform, true);
                    }
                }
                else
                {
                    player.SetParent(player.GetComponent<playercontroller>().touching.transform, true);
                }
            }
        }

    }
    public void stop()
    {
        //stops turn after one rotation
        animator.SetBool("left", false);
        animator.SetBool("right", false);
    }
    public void set()
    {
        // sets the flat axis to the correct axis and stops turning
        flatten = Vect;
        isturning = false;
        player.gameObject.GetComponent<playercontroller>().turnstay();
    }
    private void SetStart()
    {
        // starts the game with correct flat axis and stops turning
        flatten = new Vector3(1, 1, 0);
        isturning = false;
    }
}
