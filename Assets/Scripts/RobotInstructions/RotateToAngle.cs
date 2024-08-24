using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[Serializable]
public class RotateToAngle : Instruction
{
    [SerializeField]
    private Vector3 targetRotationAngle;

    public override async Task ExecuteInstruction()
    {
        float timeDelta = 0.0f;
        float startTime = Time.time;
        Quaternion startRotation = _robot.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(targetRotationAngle);
        while ((Time.time - startTime) < _instructionExecutionTime)
        {
            timeDelta += Time.deltaTime / _instructionExecutionTime;
            _robot.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeDelta);
            await Task.Yield();
        }
        _robot.TransitionToNext();
    }
}
