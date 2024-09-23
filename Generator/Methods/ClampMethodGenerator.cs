﻿

namespace Generator
{
    /// <summary>
    /// A generator for the clamp method.
    /// </summary>
    public static class ClampMethodGenerator
    {
        /* Public methods. */
        public static string GenerateLocal(string className)
        {
            return MethodGenerator.GenerateSummary(GetDesc(false, className))
                + "\n" + Generator.Indent + $"public readonly {className} Clamp({className} min, {className} max) => new {className}(Mathd.Clamp(value, min.value, max.value));";
        }

        public static string GenerateStatic(string className)
        {
            return MethodGenerator.GenerateSummary(GetDesc(true, className))
                + "\n" + Generator.Indent + $"public static {className} Clamp({className} value, {className} min, {className} max) => new {className}(Mathd.Clamp(value.value, min.value, max.value));";
        }

        /* Private methods. */
        private static string GetDesc(bool isStatic, string className)
        {
            return $"Return the result of clamping {(isStatic ? "a" : "this")} {className.ToLower()} value between a min and max value.";
        }
    }
}
