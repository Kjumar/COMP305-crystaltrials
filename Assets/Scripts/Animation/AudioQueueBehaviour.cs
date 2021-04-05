/* AudioQueueBehaviour.cs
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

public class AudioQueueBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSoundSource;
    [SerializeField] private AudioSource attackSoundSource;
    [SerializeField] private AudioSource hitSoundSource;

    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip[] jumpSounds;

    public void PlayJumpSound()
    {
        jumpSoundSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
    }

    public void PlayHitSound()
    {
        hitSoundSource.PlayOneShot(hitSound);
    }

    public void playAttackSound()
    {
        attackSoundSource.PlayOneShot(attackSound);
    }
}
