using UnityEngine;

public class Anomaly : MonoBehaviour
{
    public GameObject normalAppearance;
    public GameObject anomalyAppearance;
    private bool isActiveAnomaly = false;

    public void SetActiveAnomaly(bool active)
    {
        isActiveAnomaly = active;
        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        if (normalAppearance != null)
            normalAppearance.SetActive(!isActiveAnomaly);
        if (anomalyAppearance != null)
            anomalyAppearance.SetActive(isActiveAnomaly);
    }
}