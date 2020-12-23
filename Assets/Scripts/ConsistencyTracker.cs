using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class ConsistencyTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOutput;

    private UnityAction<string> _onAction;
    private int _currentActionInd;

    private void Start()
    {
        _onAction += CheckConsistency;

        ShowCurrentActionDescription();
    }

    private void ShowCurrentActionDescription()
    {
        textOutput.text = ActionsSequence.Actions[_currentActionInd].Description;
    }

    private void CheckConsistency(string actionName)
    {
        if (ActionsSequence.Actions[_currentActionInd].Name == actionName)
        {
            if (_currentActionInd + 1 >= ActionsSequence.Actions.Length) return;
            _currentActionInd++;
            ShowCurrentActionDescription();
        }
        else
        {
            StartCoroutine(ShowErrorForNSeconds(2));
        }
    }

    private IEnumerator ShowErrorForNSeconds(int n)
    {
        textOutput.text = "Не правильно!";

        yield return new WaitForSeconds(n);

        ShowCurrentActionDescription();
    }

    public void InvokeOnAction(string actionName)
    {
        _onAction.Invoke(actionName);
    }
}