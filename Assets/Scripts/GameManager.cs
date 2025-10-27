using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private AnomalyManager anomalyManager;

    void Awake()
    {
        anomalyManager = FindObjectOfType<AnomalyManager>();
    }

    void Start()
    {
        ResetScene(forceNoAnomaly: true); 
    }

    public void ResetScene(bool forceNoAnomaly = false)
    {
        if (anomalyManager == null)
        {
            return;
        }

        anomalyManager.DeactivateAllAnomalies();

        if (!forceNoAnomaly)
        {
            bool spawned = anomalyManager.TrySpawnAnomaly();
        }
    }
    
    void Update() // FOR TESTING PURPOSES - DELETE LATER
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetScene();
        }
    }
}