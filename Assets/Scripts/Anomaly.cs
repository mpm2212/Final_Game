using UnityEngine;

public enum Scareiness { NotSpooky, Spooky }
public enum Obviousness { NotObvious, Obvious }

public class Anomaly : ScriptableObject
{
    public string name;
    public GameObject anomalyObject;
    //public Scareiness scareiness; 
    public Obviousness obviousness;
}