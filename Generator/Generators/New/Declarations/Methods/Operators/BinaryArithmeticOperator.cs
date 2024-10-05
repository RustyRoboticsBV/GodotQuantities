﻿namespace Generators
{
    /// <summary>
    /// An binary arithmetic operator generator.
    /// </summary>
    public class BinaryArithmeticOperator : ArithmeticOperator
    {
        /* Constructors. */
        public BinaryArithmeticOperator(ReturnType returnType, string name, Parameter a, Parameter b)
            : base(returnType.Type.Name, name, new ParameterList(a, b), GetImpl(returnType, a, name, b)) { }

        /* Public methods. */
        public static string Generate(ReturnType returnType, string name, Parameter a, Parameter b)
        {
            return new BinaryArithmeticOperator(returnType, name, a, b).Generate();
        }

        /* Private methods. */
        private static string GetImpl(ReturnType returnType, Parameter a, string op, Parameter b)
        {
            if (a is VectorParameter va && b is VectorParameter vb)
            {
                return $"return new {returnType.Type.Name}(a.X + b.X, a.Y + b.Y, a.Z + b.Z);";
            }
            else
            {
                return returnType.Generate(Numerics.CoreType,
                    $"{a.Type.CastTo("a", Numerics.CoreType)} {op} {b.Type.CastTo("b", Numerics.CoreType)}");
            }
        }
    }
}