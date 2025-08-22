using Fusion;
using UnityEngine;

public class ScriptTest : MonoBehaviour
{
    NetworkObjectBaker network;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(1, 1, 1);
        JAJA();
    }

    void JAJA()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Material m;
    [ContextMenu("Apply SHARED")]
    void ChangeShared()
    {
        foreach(var a in GetComponentsInChildren<MeshRenderer>())
        {
            a.sharedMaterial = m;
        }
    }

    [ContextMenu("Apply MAT")]
    void ChangeMaterial()
    {
        foreach (var a in GetComponentsInChildren<MeshRenderer>())
        {
            a.material = m;
        }
    }
}
