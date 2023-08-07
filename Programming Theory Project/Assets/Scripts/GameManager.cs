using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI unitOrganization;
    [SerializeField] private TextMeshProUGUI unitType;
    [SerializeField] private TextMeshProUGUI detailedType;
    [SerializeField] private TextMeshProUGUI unitCapabilities;
    [SerializeField] private GameObject reducedMarker;
    [SerializeField] private GameObject divisionMarker;
    [SerializeField] private Material []divisionColors;
    [SerializeField] private GameObject ui;
    [SerializeField] private Button submit;

    private Nationality selectedNationality;
    private string selectedDivision;
    private int selectedRegiment;
    private int selectedBattalion;
    private bool selectedReductionStatus;

    Armored pzAbtI_PzR1_1PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "1Pz",
        Regiment = 1,
        Battalion = 1,
        Type = "Armor",
        ArmorType = "Panzer II",
        ArmorAttackFactor = 2,
        InfantryAttackFactor = 2,
        MovementPoints = 4
    };
    Armored pzAbtII_PzR1_1PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "1Pz",
        Regiment = 1,
        Battalion = 2,
        Type = "Armor",
        ArmorType = "Panzer II",
        ArmorAttackFactor = 2,
        InfantryAttackFactor = 2,
        MovementPoints = 4
    };
    Armored pzAbtIII_PzR1_1PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "1Pz",
        Regiment = 1,
        Battalion = 3,
        Type = "Armor",
        ArmorType = "Panzer IV",
        ArmorAttackFactor = 3,
        InfantryAttackFactor = 3,
        MovementPoints = 4
    };

    Armored pzAbtI_PzR2_1PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "1Pz",
        Regiment = 2,
        Battalion = 1,
        Type = "Armor",
        ArmorType = "Panzer II",
        ArmorAttackFactor = 2,
        InfantryAttackFactor = 2,
        MovementPoints = 4
    };
    Armored pzAbtII_PzR2_1PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "1Pz",
        Regiment = 2,
        Battalion = 2,
        Type = "Armor",
        ArmorType = "Panzer II",
        ArmorAttackFactor = 2,
        InfantryAttackFactor = 2,
        MovementPoints = 4
    };
    Armored pzAbtIII_PzR2_1PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "1Pz",
        Regiment = 2,
        Battalion = 3,
        Type = "Armor",
        ArmorType = "Panzer III",
        ArmorAttackFactor = 3,
        InfantryAttackFactor = 3,
        MovementPoints = 4
    };

    Armored pzAbtI_PzR35_4PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "4Pz",
        Regiment = 35,
        Battalion = 1,
        Type = "Armor",
        ArmorType = "Panzer II",
        ArmorAttackFactor = 2,
        InfantryAttackFactor = 2,
        MovementPoints = 4
    };
    Armored pzAbtII_PzR35_4PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "4Pz",
        Regiment = 35,
        Battalion = 2,
        Type = "Armor",
        ArmorType = "Panzer II",
        ArmorAttackFactor = 2,
        InfantryAttackFactor = 2,
        MovementPoints = 4
    };
    Armored pzAbtIII_PzR35_4PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "4Pz",
        Regiment = 35,
        Battalion = 3,
        Type = "Armor",
        ArmorType = "Panzer IV",
        ArmorAttackFactor = 3,
        InfantryAttackFactor = 3,
        MovementPoints = 4
    };

    Armored pzAbtI_PzR36_4PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "4Pz",
        Regiment = 36,
        Battalion = 1,
        Type = "Armor",
        ArmorType = "Panzer II",
        ArmorAttackFactor = 2,
        InfantryAttackFactor = 2,
        MovementPoints = 4
    };
    Armored pzAbtII_PzR36_4PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "4Pz",
        Regiment = 36,
        Battalion = 2,
        Type = "Armor",
        ArmorType = "Panzer II",
        ArmorAttackFactor = 2,
        InfantryAttackFactor = 2,
        MovementPoints = 4
    };
    Armored pzAbtIII_PzR36_4PzDiv = new Armored
    {
        Nationality = Nationality.German,
        Division = "4Pz",
        Regiment = 36,
        Battalion = 3,
        Type = "Armor",
        ArmorType = "Panzer III",
        ArmorAttackFactor = 3,
        InfantryAttackFactor = 3,
        MovementPoints = 4
    };

    // Start is called before the first frame update
    void Start()
    {
        submit.onClick.AddListener(TaskOnSubmit);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    //ABSTRACTION
    private void TaskOnSubmit()
    {
        selectedNationality = ui.GetComponent<UIManager>().SelectedNationality;
        selectedDivision = ui.GetComponent<UIManager>().SelectedDivision;
        selectedRegiment = ui.GetComponent<UIManager>().SelectedRegiment;
        selectedBattalion = ui.GetComponent<UIManager>().SelectedBattalion;
        selectedReductionStatus = ui.GetComponent<UIManager>().SelectedReductionStatus;
        PrintCounterInformation(PickUnit(selectedDivision, selectedRegiment, selectedBattalion), selectedReductionStatus);
    }

    void PrintCounterInformation(Armored unit, bool isReduced)
    {
        if (isReduced)
        {
            unit.ReduceUnit();
        } else
        {
            unit.UnReduceUnit();
        }
        unit.PrintCounterInformation();
        unitOrganization.text = unit.UnitOrganization();
        unitType.text = unit.Type;
        detailedType.text = unit.ArmorType;
        unitCapabilities.text = unit.UnitCapabilities();
        reducedMarker.SetActive(unit.IsReduced);
        switch (unit.Division)
        {
            case "1Pz":
                divisionMarker.GetComponent<Renderer>().material = divisionColors[0];
                break;
            case "4Pz":
                divisionMarker.GetComponent<Renderer>().material = divisionColors[1];
                break;
            default:
                divisionMarker.GetComponent<Renderer>().material = divisionColors[2];
                break;
        }
    }

    private Armored PickUnit(string division, int regiment, int battalion)
    {
        
            if(division == "1Pz")
            {
                if(regiment == 1)
                {
                    switch(battalion)
                    {
                        case 1:
                            return pzAbtI_PzR1_1PzDiv;
                        case 2:
                            return pzAbtII_PzR1_1PzDiv;
                    default:
                            return pzAbtIII_PzR1_1PzDiv;
                    }
                }
                else
                {
                    switch (battalion)
                    {
                        case 1:
                            return pzAbtI_PzR2_1PzDiv;
                        case 2:
                            return pzAbtII_PzR2_1PzDiv;
                    default:
                            return pzAbtIII_PzR2_1PzDiv;
                    }
                }
            }
            else
            {
                if (regiment == 35)
                {
                    switch (battalion)
                    {
                        case 1:
                            return pzAbtI_PzR35_4PzDiv;
                        case 2:
                            return pzAbtII_PzR35_4PzDiv;
                        default:
                            return pzAbtIII_PzR35_4PzDiv;
                    }
                }
                else
                {
                    switch (battalion)
                    {
                        case 1:
                            return pzAbtI_PzR36_4PzDiv;
                        case 2:
                            return pzAbtII_PzR36_4PzDiv;
                    default:
                            return pzAbtIII_PzR36_4PzDiv;
                    }
                }
            }
        

    }
}
