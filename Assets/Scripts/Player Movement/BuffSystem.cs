
public enum StatModType
{
    Flat,
    Percent,
}



public class BuffSystem
{


    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public BuffSystem(float value, StatModType type, int order)
    {
        Value = value;
        Type = type;
        Order = order;
    }
    public BuffSystem(float value, StatModType type) : this(value, type, (int)type) { }

}
