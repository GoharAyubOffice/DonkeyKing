using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPowerup : MonoBehaviour
{
    public static PlayerPowerup playerpowerupInstance;

    public Slider _powerUpslider;
    public PowerUpBar powerBar;
    public int maxPowerUpValue = 7;
    public int currentPowerUpValue = 0;

    [SerializeField] float dashDuration = 3f;

    public bool isDash = false;


    private void Awake()
    {
        playerpowerupInstance = this;
    }

    private void Update()
    {
        PowerUpBar();

        if (Input.GetKey(KeyCode.LeftShift) && isDash == true)
        {

            PowerDash();
            StartCoroutine(DisableKinematic());
        }
    }
    void PowerUpBar()
    {
        _powerUpslider.value = currentPowerUpValue;

        if (_powerUpslider.value == maxPowerUpValue)
        {
            currentPowerUpValue = maxPowerUpValue;

            isDash = true;
        }
    }
    void PowerDash()
    {
        {
            _powerUpslider.value = 1;
            currentPowerUpValue = 0;
        }
    }
    private IEnumerator DisableKinematic()
    {
        isDash = false;

        Time.timeScale = 2;


        PlayerMovement.playerInstance.isGrounded = false;
        PlayerMovement.playerInstance.isInAir = false;

        PlayerMovement.playerInstance.rb.isKinematic = true;
        yield return new WaitForSeconds(dashDuration);


        PlayerMovement.playerInstance.rb.isKinematic = false;
        Time.timeScale = 1;
    }
}
