using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageInvisibility : MonoBehaviour
{

    public float invincibilityDuration = 1;
    private InvisibilityCOntroller invincibilityController;

    private void Awake()
    {
        invincibilityController = GetComponent<InvisibilityCOntroller>();
    }

    public void StartInvincibility()
    {
        invincibilityController.StartInvisibility(invincibilityDuration);
    }
}
