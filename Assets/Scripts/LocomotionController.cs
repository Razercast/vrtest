using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftTeleportationRay;
    public XRController rightTeleportationRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public bool EnableLeftTeleporter { get; set; } = true;
    public bool EnableRightTeleporter { get; set; } = true;

    // Update is called once per frame
    void Update()
    {
        if(leftTeleportationRay)
        {
            leftTeleportationRay.gameObject.SetActive(EnableLeftTeleporter && CheckIfActivated(leftTeleportationRay));
        }

        if (rightTeleportationRay)
        {
            rightTeleportationRay.gameObject.SetActive(EnableRightTeleporter && CheckIfActivated(rightTeleportationRay));
        }

    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated,activationThreshold);
        return isActivated; 
    }
}
