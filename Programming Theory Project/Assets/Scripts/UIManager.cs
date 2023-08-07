using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown nationality;
    [SerializeField] private TMP_Dropdown division;
    [SerializeField] private TMP_Dropdown regiments1PzDiv;
    [SerializeField] private TMP_Dropdown regiments4PzDiv;
    private int divisionIndex = 1;

    public Nationality SelectedNationality { get; private set; }
    public string SelectedDivision { get; private set; } = "1Pz";
    public int SelectedRegiment { get; private set; } = 1;
    public int SelectedBattalion { get; private set; } = 1;

    public bool SelectedReductionStatus { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (divisionIndex == 1)
        {
            regiments1PzDiv.enabled = true;
            regiments4PzDiv.enabled = false;


        }
        if (divisionIndex == 4)
        {
            regiments1PzDiv.enabled = false;
            regiments4PzDiv.enabled = true;


        }
    }


    // ABSTRACTION
    public void SelectNationality(int value)
    {
        SelectedNationality = (Nationality)value;
    }

    public void SelectDivision(int value)
    {
        if (value == 0)
        {
            SelectedDivision = "1Pz";
            divisionIndex = 1;
            regiments1PzDiv.enabled = true;
            regiments4PzDiv.enabled = false;

        }
        else if (value == 1)
        {
            SelectedDivision = "4Pz";
            divisionIndex = 4;
            regiments1PzDiv.enabled = false;
            regiments4PzDiv.enabled = true;

        }
    }
    public void SelectRegiment1PzDiv(int value)
    {
        if(divisionIndex == 1)
        {
            SelectedRegiment = value + 1;
            Debug.Log($"Div: {divisionIndex}\nValue: {value}");
        }
        
    }

    public void SelectRegiment4PzDiv(int value)
    {
        if (divisionIndex == 4)
        {
            SelectedRegiment = value + 35;
            Debug.Log($"Div: {divisionIndex}\nValue: {value}");
        }
            
    }

    public void SelectBattalion(int value)
    {
        SelectedBattalion = value + 1;
    }

    public void SetReductionStatus(bool value)
    {
        SelectedReductionStatus = value;
    }
}
