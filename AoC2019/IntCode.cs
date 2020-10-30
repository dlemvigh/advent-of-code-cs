using System;
using System.Linq;

namespace AoC2019.Day2
{
    public class IntCode
    {
        internal readonly int[] _program;
        internal int _p;
        internal bool _isHalted;

        public IntCode(string program) {
            _program = program.Split(',').Select(int.Parse).ToArray();
        }

        public string Program => string.Join(",", _program);

        public void RunUntilHalt() {
            while(_isHalted == false) {
                Exec();
            }
        }

        internal void Exec() {
            var op = ReadNextOp();
            op();
        }

        internal Action ReadNextOp() {
            var opcode = ReadImmediate();
            switch(opcode) {
                case 1:
                    return Add;
                case 2:
                    return Multiply;
                case 99:
                default:
                    return Halt;;
            }            
        }

        #region opcodes
        internal void Add() {
            var a = ReadPosition();
            var b = ReadPosition();
            var c = a + b;
            Write(c);
        }

        internal void Multiply() {
            var a = ReadPosition();
            var b = ReadPosition();
            var c = a * b;
            Write(c);
        }

        internal void Halt() {
            _isHalted = true;
        }
        #endregion

        internal int ReadPosition() {
            var addr = ReadImmediate();
            return _program[addr];
        }

        internal int ReadImmediate() {
            return _program[_p++];
        }

        internal void Write(int value) {
            var addr = ReadImmediate();
            Write(addr, value);
        }

        internal void Write(int addr, int value) {
            _program[addr] = value;
        }

    }
}