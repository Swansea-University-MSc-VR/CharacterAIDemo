using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawNavigationPath : MonoBehaviour
{
    public Transform person;
    public Transform target;
    public LineRenderer lineRenderer;

    public float updateRate = 1f;
    private float elapsed = 0.0f;

    public enum PathColour
    {
        Blue,
        Yellow,
        GreenRed,
    }

    public PathColour pathColour;   
    public PathColour alternativePathColour;


    private void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed > updateRate)
        {
            elapsed = 0f;

            NavMeshPath path = new NavMeshPath();
            NavMeshHit hit;
            Vector3 starPos = Vector3.zero;
            Vector3 TargetPos = Vector3.zero;

           if( NavMesh.SamplePosition(person.position, out hit, 1.0f, NavMesh.AllAreas))
            {
                starPos = hit.position; 
            }
            if (NavMesh.SamplePosition(target.position, out hit, 1.0f, NavMesh.AllAreas))
            {
                TargetPos = hit.position;
            }

            if (starPos == Vector3.zero || TargetPos == Vector3.zero)
                return;

            if (NavMesh.CalculatePath(starPos, TargetPos, NavMesh.AllAreas, path))
            {
                lineRenderer.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    lineRenderer.SetPosition(i, path.corners[i]);
                }
            }
            else
                Debug.Log("no path");

        }    
    }
}
