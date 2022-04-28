using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public KeyCode pressE;
    public Light flashLight;
    public bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pressE))
        {
            if (isOn == false)
            {
                flashLight.enabled = true;
                isOn = true;
            }
            else if (isOn == true)
            {
                flashLight.enabled = false;
                isOn = false;
            }
        }
    }
}
