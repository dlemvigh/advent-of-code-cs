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
    }
}