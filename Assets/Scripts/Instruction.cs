using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

[Serializable]
public abstract class Instruction
{
    [SerializeField]
    protected float _instructionExecutionTime;

    protected Robot _robot;

    public void SetRobot(Robot robot)
    {
        this._robot = robot;
    }

    public abstract Task ExecuteInstruction();

}

