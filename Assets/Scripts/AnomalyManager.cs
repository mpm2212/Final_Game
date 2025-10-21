using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AnomalyManager : MonoBehaviour
{
    private List<Anomaly> allAnomalies;
    private List<Anomaly> availableAnomalies;
    private Anomaly currentAnomaly;
    //40% chance of no anomaly
    private float anomalyProbability = 0.4f;
    // 20% chance of obvious anomaly
    private float obviousnessProbability = 0.2f;


    void Start()
    {
        availableAnomalies = new List<Anomaly>(allAnomalies);
        ChooseAnomaly();
    }

    public void ResetScene()
    {
        if (currentAnomaly != null && currentAnomaly.anomalyObject != null)
            currentAnomaly.anomalyObject.SetActive(false);

        ChooseAnomaly();
    }

    void ChooseAnomaly()
    {
        
        if (Random.value < anomalyProbability)
        {
            currentAnomaly = null; // Add to this?? 
            // Trigger for level update ?? 
            return;
        }

        Obviousness chosenObviousness = Random.value < obviousnessProbability ? Obviousness.Obvious : Obviousness.Subtle;

        var potential = availableAnomalies
            .Where(a => a.obviousness == chosenObviousness).ToList();

        if (potential.Count == 0)
        {
            if (availableAnomalies.Count == 0)
                availableAnomalies = new List<Anomaly>(allAnomalies);

            potential = availableAnomalies;
        }

        currentAnomaly = potential[Random.Range(0, potential.Count)];
        availableAnomalies.Remove(currentAnomaly);

        if (currentAnomaly.anomalyPrefab != null)
        {
            currentAnomaly.anomalyObject.SetActive(true); // Make sure this works
        }
    }
}