using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManagerInstance;

    private void Start()
    {
        if(uiManagerInstance == null)
        {
            uiManagerInstance = this;
        }
    }
    private void Update()
    {
        
    }
}
