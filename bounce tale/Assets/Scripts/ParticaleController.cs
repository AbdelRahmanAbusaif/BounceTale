using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticaleController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem movementParticleSystem;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 1)]
    [SerializeField]
    float dustFormationPeriod;

    [SerializeField]
    Rigidbody2D playerRB;

    private float counter;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (Mathf.Abs(playerRB.velocity.x) <= occurAfterVelocity)
            return;

        if (counter <= dustFormationPeriod)
            return;

        movementParticleSystem.Play();
        counter = 0;
    }
}
