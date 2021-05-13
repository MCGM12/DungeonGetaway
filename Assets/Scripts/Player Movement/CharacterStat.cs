using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[Serializable]
public class CharacterStat {

    public float BaseValue;
    public virtual float Value
    {
        get
        {
            if (isDirty || BaseValue != lastBaseValue )
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    protected  bool isDirty = true;
    protected  float _value;
    protected  float lastBaseValue = float.MinValue;

    protected  readonly List<BuffSystem> buffSystems;
    public readonly ReadOnlyCollection<BuffSystem> BuffSystems;


    public CharacterStat()
    {
        buffSystems = new List<BuffSystem>();

        BuffSystems = buffSystems.AsReadOnly();
    }

    public CharacterStat(float baseValue) : this()
    {
        BaseValue = baseValue;
      
    }


    public virtual void AddStats(BuffSystem mod)
    {
        isDirty = true;
        buffSystems.Add(mod);
        buffSystems.Sort(CompareModifierOrder);
    }
    protected virtual int CompareModifierOrder(BuffSystem a, BuffSystem b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0 ;// if (a.order == b.order)
    }
    public virtual bool RemoveStats(BuffSystem mod)
    {
      if (buffSystems.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    public virtual bool RemoveAllModifersFromSource(object source)
    {
        bool didRemove = false;
         for (int i = buffSystems.Count - 1; i>=0; i--)
        {
            if (buffSystems[i].Source == source)
            {
                isDirty = true;
                didRemove = true;
                buffSystems.RemoveAt(i);
            }
        }
        return didRemove;
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i=0; i< buffSystems.Count; i++)
        {
            BuffSystem mod = buffSystems[i];
            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }else if (mod.Type== StatModType.PercentAdd)
            {

                sumPercentAdd += mod.Value;

                if (i +1 >= buffSystems.Count || buffSystems[i+1].Type != StatModType.PercentAdd) 
                {

                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                
                }
            
            }
            else if (mod.Type== StatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;            }
        }
        return (float)Math.Round(finalValue, 4);
    }
}
