﻿namespace HiQ.Leap.TestExercise.Services.Helpers;

public static class PersonNumberValidator
{
    public static bool IsValidPersonNumber(string personNumber)
    {
        if (!IsValidLuhn(personNumber))
        {
            return false;
        }

        return true;
    }

    // Person numbers in Sweden are Luhn checked
    internal static bool IsValidLuhn(string digits)
    {
        if (string.IsNullOrWhiteSpace(digits))
        {
            return false;
        }

        return digits.All(char.IsDigit) && digits.Reverse()
            .Select(c => c - 48)
            .Select((thisNum, i) => i % 2 == 0
                ? thisNum
                : (thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
            .Sum() % 10 == 0;
    }
}