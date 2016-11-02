/*
 * Written by Kaila Harris, 11/01/2016
 * converts hex colors to rgb
 */
using System;
using UnityEngine;

class ConvertHexColor
{
    // returns percentage-based RGB color
    public Color toRGB(string _hexValue)
    {
        if (_hexValue.Length == 6)
        {
            byte rValue = byte.Parse(_hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte gValue = byte.Parse(_hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte bValue = byte.Parse(_hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            
            return (new Color32(rValue, gValue, bValue,255));
        }
        else
        {
            Debug.Log("Color input error: " + _hexValue);
            return (new Color32(1, 1, 1, 255));
        }
    }
}