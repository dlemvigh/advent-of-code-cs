using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2019.Day2
{
    public class IntCode
    {
        internal readonly int[] _program;
        internal int _p;
        internal bool _isHalted;
        internal readonly LinkedList<int> _inputs = new LinkedList<int>();
        internal readonly LinkedList<int> _outputs = new LinkedList<int>();
        internal int _opcode;
        internal int _rm;
        internal readonly int[] _readmode = new int[3];

        public IntCode(string program) {
            _program = program.Split(',').Select(int.Parse).ToArray();
        }

        public string Program => string.Join(",", _program);
        public int Out => _outputs.Last();

        public void In(params int[] inputs) {
            foreach(var input in inputs) {
                _inputs.AddLast(input);
            }            
        }

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
            _opcode = ReadImmediate();
            var op = ParseParameterMode(_opcode);

            switch(op) {
                case 1: return Add;
                case 2: return Multiply;
                case 3: return Input;
                case 4: return Output;
                case 5: return JumpIfTrue;
                case 6: return JumpIfFalse;
                case 7: return LessThan;
                case 8: return Equal;
                case 99:
                default:
                    return Halt;;
            }            
        }

        internal int ParseParameterMode(int opcode) {
            var op = opcode % 100;
            
            _rm = 0;
            _readmode[0] = (opcode / 100) % 10;
            _readmode[1] = (opcode / 1000) % 10;
            _readmode[2] = (opcode / 10000) % 10;

            return op;
        }

        #region opcodes
        internal void Add() {
            var a = Read();
            var b = Read();
            var c = a + b;
            Write(c);
        }

        internal void Multiply() {
            var a = Read();
            var b = Read();
            var c = a * b;
            Write(c);
        }

        internal void Input() {
            var value = _inputs.First();
            _inputs.RemoveFirst();
            Write(value);
        }

        internal void Output() {
            var value = Read();
            _outputs.AddLast(value);
        }

        internal void JumpIfTrue() {
            var value = Read();
            var addr = Read();
            if (value != 0) {
                _p = addr;
            }
        }

        internal void JumpIfFalse() {
            var value = Read();
            var addr = Read();
            if (value == 0) {
                _p = addr;
            }
        }

        internal void LessThan() {
            var a = Read();
            var b = Read();
            var result = a < b ? 1 : 0;
            Write(result);
        }

        internal void Equal() {
            var a = Read();
            var b = Read();
            var result = a == b ? 1 : 0;
            Write(result);
        }

        internal void Halt() {
            _isHalted = true;
        }
        #endregion

        internal int Read() {
            var readmode = _readmode[_rm++];
            switch (readmode) {
                default:
                case 0:
                    return ReadPosition();
                case 1:
                    return ReadImmediate();
            }
        }
        internal int ReadPosition() {
            var addr = ReadImmediate();
            try {
                return _program[addr];
            } catch(Exception) {
                throw;
            }
        }

        internal int ReadImmediate() {
            return _program[_p++];
        }

        internal void Write(int value) {
            var addr = ReadImmediate();
            WritePosition(addr, value);
        }

        internal void WritePosition(int addr, int value) {
            _program[addr] = value;
        }

    }
}