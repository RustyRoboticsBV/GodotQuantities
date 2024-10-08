﻿namespace Generators
{
    public class VectorNumericType : VectorType
    {
        /* Public properties. */
        public new ScalarNumericType ScalarType => base.ScalarType as ScalarNumericType;

        /* Constructors. */
        public VectorNumericType(string name, ScalarNumericType scalarType, int size) : base(name, scalarType, size) { }

        /* Public methods. */
        public override string CastTo(string value, Type to, string scope)
        {
            if (to is ScalarNumericType sn)
                return "VEC_NUM_TO_SCL_NUM";
            if (to is ScalarNumericType sq)
                return "VEC_NUM_TO_SCL_Q";
            if (to is VectorNumericType vn)
                return "VEC_NUM_TO_VEC_NUM";
            if (to is VectorQuantityType vq)
                return "VEC_NUM_TO_VEC_Q";
            if (to is StringType)
                return "\"{x.ToString()}, {y.ToString()}, {z.ToString()}\"";

            // Invalid types.
            throw new ArgumentOutOfRangeException($"{value} from {Name} to {to.Name}");
        }
    }
}