using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnscript : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public cameracontroller camera;
    public Vector3 Vect;
    public Vector3 flatter;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        camera = animator.gameObject.GetComponent<cameracontroller>();
        camera.move = Vect;
        camera.Vect = flatter;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
