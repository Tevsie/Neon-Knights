using UnityEngine;
using System.Collections;

public class AttackEffect : MonoBehaviour
{
    public GameObject attackSprite;
    public GameObject enemyAttackSprite;
    public Camera mainCamera;
    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 0.2f;

void Start()
{
    Debug.Log("Attack Effect Started");
    if (attackSprite == null)
        Debug.LogError("Attack Sprite is not assigned.");
    if (enemyAttackSprite == null)
        Debug.LogError("Enemy Attack Sprite is not assigned.");
    if (mainCamera == null)
        Debug.LogError("Main Camera is not assigned.");

    attackSprite.SetActive(false);
    enemyAttackSprite.SetActive(false); // Ensure the sprite is initially inactive
}

    // Call this method when an attack triggers
    public void TriggerAttackEffect(bool isPlayerTurn)
    {
        StartCoroutine(PlayAttackEffect(isPlayerTurn));
    }

    IEnumerator PlayAttackEffect(bool isPlayerTurn)
    {
        if (isPlayerTurn)
        {
            // Enable the player's attack sprite
            attackSprite.SetActive(true);
        }
        else
        {
            // Enable the enemy's attack sprite
            enemyAttackSprite.SetActive(true);
        }

        // Start screen shake
        if (mainCamera != null)
        {
            StartCoroutine(ShakeScreen());
        }

        // Wait for a brief moment
        yield return new WaitForSeconds(0.5f); // Adjust the duration as needed

        // Disable the sprites
        attackSprite.SetActive(false);
        enemyAttackSprite.SetActive(false);
    }

    IEnumerator ShakeScreen()
    {
        Vector3 originalPosition = mainCamera.transform.localPosition;

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            mainCamera.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.localPosition = originalPosition;
    }
}
