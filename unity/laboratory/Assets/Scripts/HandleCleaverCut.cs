using UnityEngine;

public class HandleCleaverCut : MonoBehaviour
{
    private GameObject objectToCut;

    private void Start()
    {
        objectToCut = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Cleaver")) return;

        objectToCut.transform.parent = null;
        objectToCut.AddComponent<Rigidbody>();

        // FindObjectOfType<TasksLogic>().TaskIsDone("Cleaver");
        Destroy(gameObject);
    }
}