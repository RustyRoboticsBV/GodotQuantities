﻿

namespace Generator
{
    /// <summary>
    /// A generator for loop methods.
    /// </summary>
    public static class LoopMethodGenerator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return MethodGenerator.GenerateSummary(GenerateDesc(className, false))
                + "\n" + ClassGenerator.Indent + $"public readonly {className} Loop({className} max) => new {className}(Mathd.Loop(value, max.value));";
        }

        public static string GenerateStatic(string className)
        {
            return MethodGenerator.GenerateSummary(GenerateDesc(className, true))
                + "\n" + ClassGenerator.Indent + $"public static {className} Loop({className} value, {className} max) => new {className}(Mathd.Loop(value.value, max.value));";
        }

        /* Private methods. */
        private static string GenerateDesc(string className, bool isStatic)
        {
            return $"Return the result of forcing {(isStatic ? "an" : "this")} {className.ToLower()} into a range from 0 to the specified max (through a modulo operation).";
        }
    }
}
