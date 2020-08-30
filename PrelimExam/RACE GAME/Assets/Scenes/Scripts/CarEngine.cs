using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CarEngine : MonoBehaviour
{
    
    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;
    public float maxMotorTorque = 100f;
    public float currentSpeed;
    public float maxSpeed = 100f;
    public bool isBraking = false;
    public Texture2D textureNormal;
    public Texture2D textureBraking;
    public Renderer carRenderer;
    public float maxBrakeTorque = 150f;

    private List<Transform> nodes;
    private int currectNode = 0;

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
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        
        Braking();
    }

    private void ApplySteer()
    {
        //The Ai will handle steering
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currectNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }
    private void Drive()
    {
        //for Ai to accelerate
        currentSpeed = 2 * Mathf.PI * wheelBL.radius * wheelBL.rpm * 60 / 1000;

        if(currentSpeed < maxSpeed)
        { 
        wheelBL.motorTorque = maxMotorTorque;
        wheelBR.motorTorque = maxMotorTorque;
        } else
        {
        wheelBL.motorTorque = 0f;
        wheelBR.motorTorque = 0f;
        }

    }
    private void CheckWaypointDistance()
    {
        //for checking distance of the waypoint
        if (Vector3.Distance(transform.position, nodes[currectNode].position) <0.5f)
        {
            if(currectNode == nodes.Count - 1)
            {
                currectNode = 0;
            } else
            {
                currectNode++;
            }
        }
    }
    private void Braking()
    {
        //applying brake for Ai
        if (isBraking)
        {
            wheelBL.brakeTorque = maxBrakeTorque;
            wheelBR.brakeTorque = maxBrakeTorque;
        }
        else
        {
            wheelBL.brakeTorque = 0;
            wheelBR.brakeTorque = 0;
        }
    }
}
