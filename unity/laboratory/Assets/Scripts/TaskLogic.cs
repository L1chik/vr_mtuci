using System.Linq;
using BNG;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TaskLogic : MonoBehaviour
{
    private static int currentTaskInd;
    private static UnityAction onTaskIndexChanged;

    public string taskName;
    public GameObject[] objectsToHighlight;

    private Task _task;
    private ATaskFuncs _taskFuncs;
    private GameObject _tooltipObj;

    private void Start()
    {
        foreach (var task in InitialData.config.tasks)
        {
            if (task.name.Equals(taskName)) _task = task;
        }

        _taskFuncs = GetComponent<ATaskFuncs>();
        onTaskIndexChanged += HandleTooltip;

        HandleTooltip();
    }

    public void TaskIsDone(bool check = true)
    {
        if (check && _taskFuncs && !_taskFuncs.CheckRequirements())
        {
            _taskFuncs.HandleInvalid();
            ShowError();
            return;
        }

        if (!InitialData.config.tasks[currentTaskInd].name.Equals(taskName)) return;

        if (_taskFuncs) _taskFuncs.HandleTaskIsDone(taskName);

        currentTaskInd++;
        onTaskIndexChanged.Invoke();
        DestroyComponent();
    }

    private void HandleTooltip()
    {
        var configTask = InitialData.config.tasks[currentTaskInd];

        if (!configTask.name.Equals(taskName)) return;

        HighlightObjects();

        var offset = new Vector3(configTask.offset[0], configTask.offset[1], configTask.offset[2]);

        Destroy(_tooltipObj);
        ShowTooltip(InitialData.tooltipPrefab, configTask.helpHint, offset);
    }

    private void HighlightObjects()
    {
        if (objectsToHighlight == null || objectsToHighlight.Length == 0) return;

        foreach (var o in objectsToHighlight)
        {
            var _renderer = o.GetComponent<Renderer>();
            _renderer.materials = new[] {_renderer.material, new Material(InitialData.highlightMaterial)};
        }
    }

    private void DisableHighlight()
    {
        if (objectsToHighlight == null || objectsToHighlight.Length == 0) return;

        foreach (var o in objectsToHighlight)
        {
            var _renderer = o.GetComponent<Renderer>();
            _renderer.materials = new[] {_renderer.material};
        }
    }

    public void CheckRequirements()
    {
        if (_taskFuncs == null) return;

        if (_taskFuncs.CheckRequirements())
        {
            _taskFuncs.HandleIsChecked();
            return;
        }

        _taskFuncs.HandleInvalid();

        ShowError();
    }

    public void DestroyTooltip()
    {
        if (_taskFuncs.CheckRequirements()) return;
        Destroy(_tooltipObj);
    }

    private void ShowError()
    {
        var offset = new Vector3(_task.offset[0], _task.offset[1], _task.offset[2]);

        Destroy(_tooltipObj);
        ShowTooltip(InitialData.errorTooltipPrefab, _task.errorHint, offset);
    }

    private void ShowTooltip(GameObject prefab, string text, Vector3 offset)
    {
        _tooltipObj = Instantiate(prefab);
        var tooltip = _tooltipObj.GetComponent<Tooltip>();
        tooltip.GetComponentInChildren<Text>().text = text;

        tooltip.TipOffset = offset;
        tooltip.DrawLineTo = transform;
    }

    private void DestroyComponent()
    {
        DisableHighlight();
        onTaskIndexChanged -= HandleTooltip;

        Destroy(_taskFuncs);
        Destroy(_tooltipObj);

        Destroy(this);
    }
}