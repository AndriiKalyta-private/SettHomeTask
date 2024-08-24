using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


[Serializable]
public class MoveToPos : Instruction
{
    [SerializeField]
    private Vector3 targetPosition;
    public override async Task ExecuteInstruction()
    {
        float timeDelta = 0.0f;
        float startTime = Time.time;
        var startPosition = _robot.transform.position;
        while ((Time.time - startTime) < _instructionExecutionTime)
        {
            timeDelta += Time.deltaTime / _instructionExecutionTime;
            _robot.transform.position = Vector3.Lerp(startPosition, targetPosition, timeDelta);
            await Task.Yield();
        }
        _robot.TransitionToNext();
    }
}
