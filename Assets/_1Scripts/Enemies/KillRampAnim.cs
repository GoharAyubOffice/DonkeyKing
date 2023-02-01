using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRampAnim : MonoBehaviour
{
    public Animator rampAnimator;
    [SerializeField] bool isKillRamp = false;   // bool for kill ramp

    public GameObject _player;
    public float thresholdDistance = 5.0f;

    public float distance;
    private void Start()
    {
        _player = GameObject.Find("Player");

        rampAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, _player.transform.position);

        RampPlayerDistance();
        KillRamp();
    }
    void RampPlayerDistance()
    {
        if (distance < thresholdDistance)
        {
            isKillRamp = true;
        }
    }
    void KillRamp()
    {
        if (isKillRamp)
        {
            rampAnimator.SetBool("isKill", true);
        }
    }
}
