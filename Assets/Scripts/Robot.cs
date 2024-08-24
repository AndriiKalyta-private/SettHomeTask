using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class Robot : MonoBehaviour
{
    [SerializeReference, SubclassSelector]
    private List<Instruction> _instructions = new();

    private Instruction _instruction = null;

    public List<Instruction> Instructions => _instructions;
    public async void Start()
    {
        this.TransitionTo(Instructions[0]);
        foreach (Instruction instruction in Instructions)
        {
            await RunInstruction();
        }
    }

    public void TransitionTo(Instruction instruction)
    {
        this._instruction = instruction;
        this._instruction.SetRobot(this);
    }

    public void TransitionToNext()
    {
        this._instruction = (Instructions.IndexOf(_instruction) < (Instructions.Count - 1)) ? Instructions[Instructions.IndexOf(_instruction) + 1] : Instructions[Instructions.Count - 1];
        this._instruction.SetRobot(this);
    }

    public async Task RunInstruction()
    {
        await this._instruction.ExecuteInstruction();
    }

}
