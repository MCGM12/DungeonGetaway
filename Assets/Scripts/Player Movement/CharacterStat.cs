using System;
using System.Collections.Generic;
public class CharacterStat {

    public float BaseValue;
    public float Value
    {
        get
        {
            if (isDirty)
            {
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    private bool isDirty = true;
    private float _value;

    private readonly List<BuffSystem> buffSystems;

   
    public CharacterStat(float baseValue)
    {
        BaseValue = baseValue;
        buffSystems = new List<BuffSystem>();
    }


    public void AddStats(BuffSystem mod)
    {
        isDirty = true;
        buffSystems.Add(mod);
        buffSystems.Sort(CompareModifierOrder);
    }
    private int CompareModifierOrder(BuffSystem a, BuffSystem b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0 ;// if (a.order == b.order)
    }
    public bool RemoveStats(BuffSystem mod)
    {
        isDirty = true;
        return buffSystems.Remove(mod);
    }


    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;

        for (int i=0; i< buffSystems.Count; i++)
        {
            BuffSystem mod = buffSystems[i];
            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }else if (mod.Type== StatModType.Percent)
            {
                finalValue *= 1 + mod.Value;            }
        }
        return (float)Math.Round(finalValue, 4);
    }
}
