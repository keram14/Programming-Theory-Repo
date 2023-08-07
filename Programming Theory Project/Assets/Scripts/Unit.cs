using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.ComponentModel;

// The following is a solution for stack overflow to CS0518
// compiler error for property init issue
namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit { }
}

public enum Nationality
{
    German,
    Polish
}


public class Unit
{
    // ENCAPSULATION
    public Nationality Nationality { get; init; }
    public string Division { get; init; }
    public string Type { get; init; }
    public int ArmorAttackFactor { get; init;  }
    public int InfantryAttackFactor { get; init; }
    public int MovementPoints { get; init; }
    public bool IsReduced { get; private set; } = false;


    public virtual void PrintCounterInformation()
    {
        Debug.Log($"{Nationality}\n{Division}\n{Type}\n{ArmorAttackFactor}-{InfantryAttackFactor}-{MovementPoints}\n{IsReduced}\n");
    }
    public string UnitCapabilities() => $"{ArmorAttackFactor}-{InfantryAttackFactor}-{MovementPoints}";

    public void ReduceUnit() => IsReduced = true;
    public void UnReduceUnit() => IsReduced = false;
}