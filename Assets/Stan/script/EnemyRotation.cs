using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public string[] targetTags = { "player1", "player2" }; // The tags of the target objects to look at

    private Transform nearestTarget; // Reference to the nearest target object

    void Update()
    {
        FindNearestTarget();
        if (nearestTarget != null)
        {
            // Get the direction from this object to the nearest target object
            Vector3 direction = nearestTarget.position - transform.position;

            if (direction != Vector3.zero)
            {
                // Calculate the angle to rotate towards the target
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0f, 0f, -angle);

                // Apply the rotation to the object
                transform.rotation = rotation;
            }
        }
    }

    void FindNearestTarget()
    {
        float nearestDistance = Mathf.Infinity;
        nearestTarget = null;

        foreach (string tag in targetTags)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject target in targets)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
                if (distanceToTarget < nearestDistance)
                {
                    nearestDistance = distanceToTarget;
                    nearestTarget = target.transform;
                }
            }
        }
    }
}