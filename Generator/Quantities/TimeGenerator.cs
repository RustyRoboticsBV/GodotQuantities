﻿

namespace Generator
{
    /// <summary>
    /// A generator for the time quantity class.
    /// </summary>
    public static class TimeGenerator
    {
        /* Public methods. */
        public static void Generate(params FormulaSet[] formulas)
        {
            string code = ClassGenerator.Generate("Time", "Represents a time quantity.");

            string formulaCode = "";
            foreach (FormulaSet formulaSet in formulas)
            {
                if (formulaCode != "")
                    formulaCode += "\n";
                if (formulaSet.ContainsFormula('t'))
                    formulaCode += formulaSet.GenerateMethod("Time", 't', "Calculate");
            }
            code = code.Replace("//FORMULAS", formulaCode);

            FileWriter.Write("Time", code);
        }
    }
}
