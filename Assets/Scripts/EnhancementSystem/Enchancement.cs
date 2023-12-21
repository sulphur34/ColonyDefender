using System;

[Serializable]
public class Enchancement
{
    private string _name;
    private string _defaultValue;
    private string _currentValue;
    private string _upgradeStep;
    private string

    public Enchancement(string name, string defaultValue)
    {
        _name = name;
        _defaultValue = defaultValue;
    }


}
