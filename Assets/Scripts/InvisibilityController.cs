using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityCOntroller : MonoBehaviour
{
    private HealthController healthController;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    public void StartInvisibility(float invicibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invicibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invicibilityDuration)
    {
        healthController.isInvincible = true;
        yield return new WaitForSeconds(invicibilityDuration);
        healthController.isInvincible = false;
    }

}
