using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


[Serializable]
public class ChangeColor : Instruction
{
    [SerializeField]
    private Color targetColor;
    public override async Task ExecuteInstruction()
    {
        float timeDelta = 0.0f;
        float startTime = Time.time;
        var renderer = _robot.gameObject.GetComponent<Renderer>();
        Color startColor = renderer.material.color;

        while ((Time.time - startTime) < _instructionExecutionTime)
        {
            timeDelta += Time.deltaTime / _instructionExecutionTime;
            renderer.material.color = Color.Lerp(startColor, targetColor, timeDelta);
            await Task.Yield();
        }
        _robot.TransitionToNext();
    }
}
