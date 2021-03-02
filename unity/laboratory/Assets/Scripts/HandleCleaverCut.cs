using UnityEngine;
using UnityEngine.Events;

public class HandleCleaverCut : MonoBehaviour
{
    public UnityEvent onFinishCut;

    private GameObject objectToCut;

    private void Start()
    {
        objectToCut = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Cleaver")) return;

        onFinishCut?.Invoke();

        objectToCut.transform.parent = null;
        objectToCut.AddComponent<Rigidbody>();
        
        Destroy(gameObject);
    }
}