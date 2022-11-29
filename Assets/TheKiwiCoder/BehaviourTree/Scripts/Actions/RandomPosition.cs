using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class RandomPosition : ActionNode {
    public Vector3 min;
    public Vector3 max;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        Vector3 pos = new Vector3();
        pos.x = Random.Range(min.x, max.x);
        pos.y = Random.Range(min.y, max.y);
        pos.z = Random.Range(min.z, max.z);
        blackboard.moveToPosition = pos;
        return State.Success;
    }
}
