using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krawk_Protector.Protections.Math
{
    public class ArithmeticEmulator
    {
        private double x;
        private double y;
        private ArithmeticTypes ArithmeticTypes;
        public ArithmeticTypes GetType { get; private set; }
        public ArithmeticEmulator(double x, double y, ArithmeticTypes ArithmeticTypes)
        {
            this.x = x;
            this.y = y;
            this.ArithmeticTypes = ArithmeticTypes;
        }
        public double GetValue()
        {
            switch (ArithmeticTypes)
            {
                case ArithmeticTypes.Add:
                    return x - y;
                case ArithmeticTypes.Sub:
                    return x + y;
                case ArithmeticTypes.Div:
                    return x * y;
                case ArithmeticTypes.Mul:
                    return x / y;
                case ArithmeticTypes.Xor:
                    return ((int)x ^ (int)y);
            }
            return -1;
        }
        public double GetValue(List<ArithmeticTypes> arithmetics)
        {
            Generator.Generator generator = new Generator.Generator();
            ArithmeticTypes arithmetic = arithmetics[generator.Next(arithmetics.Count)];
            GetType = arithmetic;
            switch (ArithmeticTypes)
            {
                case ArithmeticTypes.Abs:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x + (System.Math.Abs(y) * -1);
                        case ArithmeticTypes.Sub:
                            return x - (System.Math.Abs(y) * -1);
                    }
                    return -1;
                case ArithmeticTypes.Log:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Log(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Log(y));
                    }
                    return -1;
                case ArithmeticTypes.Log10:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Log10(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Log10(y));
                    }
                    return -1;
                case ArithmeticTypes.Sin:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Sin(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Sin(y));
                    }
                    return -1;
                case ArithmeticTypes.Cos:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Cos(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Cos(y));
                    }
                    return -1;
                case ArithmeticTypes.Floor:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Floor(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Floor(y));
                    }
                    return -1;
                case ArithmeticTypes.Round:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Round(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Round(y));
                    }
                    return -1;
                case ArithmeticTypes.Tan:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Tan(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Tan(y));
                    }
                    return -1;
                case ArithmeticTypes.Tanh:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Tanh(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Tanh(y));
                    }
                    return -1;
                case ArithmeticTypes.Sqrt:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Sqrt(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Sqrt(y));
                    }
                    return -1;
                case ArithmeticTypes.Ceiling:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Ceiling(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Ceiling(y));
                    }
                    return -1;
                case ArithmeticTypes.Truncate:
                    switch (arithmetic)
                    {
                        case ArithmeticTypes.Add:
                            return x - (System.Math.Truncate(y));
                        case ArithmeticTypes.Sub:
                            return x + (System.Math.Truncate(y));
                    }
                    return -1;
            }
            return -1;
        }
        public double GetX() => x;
        public double GetY() => y;
    }
    public enum ArithmeticTypes
    {
        Add, // +
        Sub, // -
        Div, // /
        Mul, // *
        Xor, // ^
        Abs, // -1
        Log, //
        Log10,
        Sin,
        Cos,
        Round,
        Sqrt,
        Ceiling,
        Floor,
        Tan,
        Tanh,
        Truncate
    }

    public class ArithmeticVT
    {
        private Value value;
        private Token token;
        private ArithmeticTypes arithmeticTypes;
        public ArithmeticVT(Value value, Token token, ArithmeticTypes arithmeticTypes)
        {
            this.value = value;
            this.token = token;
            this.arithmeticTypes = arithmeticTypes;
        }
        public Value GetValue() => value;
        public Token GetToken() => token;
        public ArithmeticTypes GetArithmetic() => arithmeticTypes;
    }
    public abstract class iFunction
    {
        public abstract ArithmeticTypes ArithmeticTypes { get; }
        public abstract ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module);
    }
    public class Value
    {
        private double x;
        private double y;
        public Value(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double GetX() => x;
        public double GetY() => y;
    }
    public class Token
    {
        private OpCode opCode;
        private object Operand;
        public Token(OpCode opCode, object Operand)
        {
            this.opCode = opCode;
            this.Operand = Operand;
        }
        public Token(OpCode opCode)
        {
            this.opCode = opCode;
            this.Operand = null;
        }
        public OpCode GetOpCode() => opCode;
        public object GetOperand() => Operand;
    }
}
