/* GinoJumpSound.cs
 * -------------------------------
 * Authors:
 *      - Jay Ganguli
 *      - 
 *      - 
 * 
 * Last edited: 2021-04-05
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GinoJumpSound : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<AudioQueueBehaviour>().PlayJumpSound();
    }
}
