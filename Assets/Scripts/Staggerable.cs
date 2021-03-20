/* Staggerable.cs
 * ------------------------------
 * Author(s):
 *      - Jay Ganguli
 *      - 
 *      - 
 * 
 * Last Edited: 2021-03-19
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staggerable : MonoBehaviour
{
    // component for animated enemeies that have a hit animation
    [SerializeField] private Animator anim;

    public void Hit()
    {
        anim.SetTrigger("hit");
    }
}
