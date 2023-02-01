using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPowerup : MonoBehaviour
{
    public Slider _powerUpslider;
    public PowerUpBar powerBar;
    public int maxPowerUpValue = 7;
    public int currentPowerUpValue = 0;

    public bool isDash = false;

    private void Update()
    {
        PowerUpBar();

        if (isDash == true)
        {
            PowerDash();
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDash = false;
            _powerUpslider.value = 1;
            currentPowerUpValue = 0;
        }
    }
}
