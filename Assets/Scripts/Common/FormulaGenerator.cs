using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FormulaGenerator
{
    public static string GenerateSimpleFormula(int order)
    {
        int first = Random.Range(0, 11);
        int sign = first < order ? 0 : 1;
        int second = 0; //Random.Range(0, 11);
        string signStr = sign == 0 ? "+" : "-";
        switch (sign)
        {
            case 0:
                second = order - first;
                break;
            case 1:
                second = first - order;
                break;
        }
        //string res = $"{first}{signStr}{second}={order}";
        string res = $"{first}{signStr}{second}";
        return res;
    }

    public static string GenerateRimNum(int order)
    {
        switch (order)
        {
            case 1:
                return "I";
            case 2:
                return "II";
            case 3:
                return "III";
            case 4:
                return "IV";
            case 5:
                return "V";
            case 6:
                return "VI";
            case 7:
                return "VII";
            case 8:
                return "VIII";
            case 9:
                return "IX";

            case 150:
                return "CL";
            case 151:
                return "CLI";
            case 152:
                return "CLII";
            case 153:
                return "CLIII";
            case 154:
                return "CLIV";
            case 155:
                return "CLV";
            case 156:
                return "CLVI";
            case 157:
                return "CLVII";
            case 158:
                return "CLVIII";
            case 159:
                return "CLIX";

            case 1595:
                return "MDXCV";
            case 1596:
                return "MDXCVI";
            case 1597:
                return "MDXCVII";
            case 1598:
                return "MDXCVIII";
            case 1599:
                return "MDXCIX";
            case 1600:
                return "MDC";

            default:
                return "I";
        }
    }
}
