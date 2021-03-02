using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    public void ShellSnapped()
    {
        var snapZone = transform.parent;
        var cable = snapZone.parent;
        snapZone.GetComponent<SnapZone>().HeldItem = null;
        Destroy(snapZone.gameObject);
        transform.parent = cable;
        var colliders = GetComponentsInChildren<BoxCollider>();
        foreach (var boxCollider in colliders)
        {
            boxCollider.enabled = true;
        }

        var coatTaskLogic = cable.gameObject.AddComponent<TaskLogic>();
        var claddingTaskLogic = cable.gameObject.AddComponent<TaskLogic>();
        coatTaskLogic.taskName = "CleanIsolation";
        claddingTaskLogic.taskName = "CleanIsolation2";

        var cableParts = cable.GetChild(0);
        var coat = cableParts.GetChild(2).gameObject;
        var cladding = cableParts.GetChild(1).gameObject;

        coatTaskLogic.objectsToHighlight = new[] {coat};
        claddingTaskLogic.objectsToHighlight = new[] {cladding};

        coat.GetComponentInChildren<HandleCut>(true).onFinishCut.AddListener(() => coatTaskLogic.TaskIsDone());
        cladding.GetComponentInChildren<HandleCut>(true).onFinishCut.AddListener(() => claddingTaskLogic.TaskIsDone());
    }
}