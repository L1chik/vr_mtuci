using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTaskButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void TurnNextTask() {
        Messenger.Broadcast(MessageEvent.NEXT_TASK);
    }
}
