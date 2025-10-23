using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class AnomalyManager : MonoBehaviour
{
    public List<Anomaly> anomalies;  
    public float anomalyChance = 0.6f;
    private Anomaly currentAnomaly;

    void Start()
    {
        ResetScene();
    }

    public void ResetScene()
    {
        foreach (Anomaly a in anomalies)
            a.SetActiveAnomaly(false);

        float roll = Random.value; 

        if (roll <= anomalyChance)
        {
            int index = Random.Range(0, anomalies.Count);
            currentAnomaly = anomalies[index];
            currentAnomaly.SetActiveAnomaly(true);
            Debug.Log("Anomaly active!");// FOR TESTING PURPOSES - DELETE LATER
        }
        else
        {
            currentAnomaly = null;
            Debug.Log("[No anomaly active.");// FOR TESTING PURPOSES - DELETE LATER
        }
    }

    void Update() // FOR TESTING PURPOSES - DELETE LATER
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
            //Debug.Log("SceneReset!");
            ResetScene();
    }
}