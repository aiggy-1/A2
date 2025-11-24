using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class npcMovement : MonoBehaviour
{
    public Transform path;
    public float maxsteerAngle = 45f;


    public WheelCollider Wheelfl;
    public WheelCollider Wheelfr;
    private List<Transform> nodes;
    private int currentNode = 0;

    private void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();


        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    private void FixedUpdate()
    {
        applySteer();
        drive();
        checkWaypointDistance();
    }

    private void applySteer()
    {

        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
       float newSteer = (relativeVector.x/relativeVector.magnitude)*maxsteerAngle;

        Wheelfl.steerAngle=newSteer;
        Wheelfr.steerAngle=newSteer;
    }
    private void drive()
    {
        Wheelfr.motorTorque = 50f;
        Wheelfl.motorTorque = 50f;
    }
    private void checkWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 3f){
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }
}
