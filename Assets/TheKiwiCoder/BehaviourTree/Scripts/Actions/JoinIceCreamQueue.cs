using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class JoinIceCreamQueue : ActionNode
{
    public IceCreamPalour iceCreamPalour;

    protected override void OnStart() {

        iceCreamPalour = GameObject.FindObjectOfType<IceCreamPalour>();       

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if (iceCreamPalour.querers.Count == iceCreamPalour.queueLimit)
            return State.Failure;

        iceCreamPalour.querers.Add(context.gameObject);


        return State.Success;
    }
}
