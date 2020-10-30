using System.Threading.Tasks;
using AoC2019.Day2;
using Xunit;

namespace AoC2019.Tests
{
    public class Day5Tests
    {
        [Fact]
        public void ReadMode() {
            var program = "1101,100,-1,4,0";
            var runner = new IntCode(program);
            runner.Exec();
            Assert.Equal(99, runner._program[4]);
        }

        [Fact]
        public async Task Day5Part1() {
            var program = await Util.ReadTestData("Day5.txt");
            var runner = new IntCode(program);

            runner.In(1);

            runner.RunUntilHalt();

            Assert.Equal(13087969, runner.Out);
        }

        [Theory]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 7, 0)]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 8, 1)]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 9, 0)]

        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 7, 1)]
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 8, 0)]
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 9, 0)]

        [InlineData("3,3,1108,-1,8,3,4,3,99", 7, 0)]
        [InlineData("3,3,1108,-1,8,3,4,3,99", 8, 1)]
        [InlineData("3,3,1108,-1,8,3,4,3,99", 9, 0)]

        [InlineData("3,3,1107,-1,8,3,4,3,99", 7, 1)]
        [InlineData("3,3,1107,-1,8,3,4,3,99", 8, 0)]
        [InlineData("3,3,1107,-1,8,3,4,3,99", 9, 0)]

        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 3, 999)]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 7, 999)]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 8, 1000)]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 9, 1001)]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 13, 1001)]
        public void VerifyFy_Input_Output(string program, int input, int expectedOutput) {
            var runner = new IntCode(program);
            runner.In(input);
            
            runner.RunUntilHalt();

            Assert.Equal(expectedOutput, runner.Out);
        }
 
         [Fact]
        public async Task Day5Part2() {
            var program = await Util.ReadTestData("Day5.txt");
            var runner = new IntCode(program);

            runner.In(5);

            runner.RunUntilHalt();

            Assert.Equal(14110739, runner.Out);
        }
   }
}