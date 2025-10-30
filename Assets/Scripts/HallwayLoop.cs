using UnityEngine;
using System.Collections;

public class HallwayLoop : MonoBehaviour
{

    public Transform TeleportTarget;
    private static bool canTeleport = true;
    private float coolDownTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            StartCoroutine(TeleportCooldown());

            Vector3 localOffset = transform.InverseTransformPoint(other.transform.position);
            Quaternion relativeRotation = TeleportTarget.rotation * Quaternion.Inverse(transform.rotation);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                other.transform.position = TeleportTarget.TransformPoint(localOffset);
                other.transform.rotation = relativeRotation * other.transform.rotation;
                rb.isKinematic = false;
            }
        }
    }

    private IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(coolDownTime);
        canTeleport = true;
    }

}
