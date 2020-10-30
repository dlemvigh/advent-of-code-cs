using System;
using System.Threading.Tasks;
using AoC2019.Day2;
using Xunit;

namespace AoC2019.Tests.Day2.cs
{
    public class IntCodeTests
    {
        [Fact]
        public void ReadPosition_CanReadInput() {
            // Arrange
            var runner = new IntCode("2,1,0");

            // Act + Assert
            Assert.Equal(0, runner.ReadPosition());
            Assert.Equal(1, runner.ReadPosition());
            Assert.Equal(2, runner.ReadPosition());
        }

        [Fact]
        public void ReadImmediate_CanReadInput() {
            // Arrange
            var runner = new IntCode("2,1,0");

            // Act + Assert
            Assert.Equal(2, runner.ReadImmediate());
            Assert.Equal(1, runner.ReadImmediate());
            Assert.Equal(0, runner.ReadImmediate());
        }

        [Fact]
        public void Write_CanWriteToProgram() {
            // Arrange
            var runner = new IntCode("1,2,3");

            // Act
            runner.WritePosition(0, 42);
            Assert.Equal(42, runner._program[0]);

            runner.WritePosition(2, 13);
            Assert.Equal(13, runner._program[2]);

            // Assert
            Assert.Equal(new []{ 42, 2, 13}, runner._program);
        }

        [Theory]
        [InlineData("3,4,0,2,2", 0, 4)]
        [InlineData("3,4,2,2,2", 2, 4)]
        [InlineData("3,4,2,3,5", 2, 8)]
        [InlineData("3,4,2,100,23", 2, 123)]
        public void Add_CanAddValuesAndStoreOutput(string program, int addr, int expected) {
            var runner = new IntCode(program);
            runner.Add();
            Assert.Equal(expected, runner._program[addr]);
        }

        [Theory]
        [InlineData("3,4,0,2,2", 0, 4)]
        [InlineData("3,4,2,2,2", 2, 4)]
        [InlineData("3,4,2,3,5", 2, 15)]
        [InlineData("3,4,2,100,23", 2, 2300)]
        public void Multiply_CanAddValuesAndStoreOutput(string program, int addr, int expected) {
            var runner = new IntCode(program);
            runner.Multiply();
            Assert.Equal(expected, runner._program[addr]);
        }

        [Fact]
        public void ReadNextOp_Add() {
            var runner = new IntCode("1");
            var op = runner.ReadNextOp();
            Assert.Equal(runner.Add, op);
        }

        [Fact]
        public void ReadNextOp_Multiply() {
            var runner = new IntCode("2");
            var op = runner.ReadNextOp();
            Assert.Equal(runner.Multiply, op);
        }

        [Theory]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void Run(string program, string expected) {
            // Arrange
            var runner = new IntCode(program);

            // Act
            runner.RunUntilHalt();

            // Assert
            Assert.Equal(expected, runner.Program);
        }

        [Fact]
        public async Task Day2Part1() {
            // Arrange
            var program = await Util.ReadTestData("Day2.txt");

            // Act
            var result = RunTestProgram(program);

            // Assert
            Assert.Equal(3562672, result);
        }

        [Fact]
        public async Task Day2Part2() {
            // Arrange
            var program = await Util.ReadTestData("Day2.txt");
            var expected = 19690720;

            // Act
            int Search() {
                for (var noun = 0; noun < 100; noun++) {
                    for (var verb = 0; verb < 100; verb++) {
                        var result = RunTestProgram(program, noun, verb);
                        if (result == expected) {
                            return 100 * noun + verb;
                        }
                    }
                }
                return -1;
            }
            var result = Search();

            // Assert
            Assert.Equal(8250, result);

        }

        private int RunTestProgram(string program, int noun = 12, int verb = 2) {
            var runner = new IntCode(program);
            runner._program[1] = noun;
            runner._program[2] = verb;

            runner.RunUntilHalt();

            var result = runner._program[0];
            return result;
        }
        
    }
}