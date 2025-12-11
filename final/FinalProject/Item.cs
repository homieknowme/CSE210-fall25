using System;

public class Item
{
    
    private string _name;
    private string _description;
    private double _weight;
    private int _quantity;
    private double _value;

    public Item(string name, string description, double weight, int quantity, double value)
    {
        _name = name;
        _description = description;
        _weight = weight;
        _quantity = quantity;
        _value = value;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public double GetWeight()
    {
        return _weight;
    }

    public int GetQuantiy()
    {
        return _quantity;
    }

    public double GetValue()
    {
        return _value;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void SetWeight(double weight)
    {
        _weight = weight;
    }

    public void SetQuantiy(int quantity)
    {
        _quantity = quantity;
    }

    public void SetValue(double value)
    {
        _value = value;
    }

    public void AddQuantity(int amount)
    {
        _quantity += amount;
    }

    public void RemoveQuantity(int amount)
    {
        _quantity -= amount;
        if (_quantity < 0) _quantity = 0;
    }

    public double GetTotalValue()
    {
        return _quantity * _value;
    }

    public void Use()
    {
        
    }


}