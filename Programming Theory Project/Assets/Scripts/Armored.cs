using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public class Armored : Unit
{
    //  ENCAPSULATION
    public int Regiment { get; init; }
    public int Battalion { get; init; }
    public string ArmorType { get; init; }
    //POLYMORPHISM
    public override void PrintCounterInformation()
    {
        Debug.Log($"{Nationality}\n{Battalion}/{Regiment}/{Division}\n{Type}\n{ArmorType}\n{ArmorAttackFactor}-{InfantryAttackFactor}-{MovementPoints}\n{IsReduced}\n");
    }

    public string UnitOrganization() => $"{Battalion}/{Regiment}/{Division}";


}

