using System.Linq;
using System.Threading.Tasks;
using AoC2019.Tests;
using Xunit;

namespace AoC2019.Day1.Tests
{
    public class Day1Tests
    {
        private readonly Day1 _sut;

        public Day1Tests() {
            _sut = new Day1();
        }

				[Theory]
				[InlineData(12, 2)]
				[InlineData(14, 2)]
				[InlineData(1969, 654)]
				[InlineData(100756, 33583)]
				public void CalculateFuel_SampleCases(double mass, double expected) {
					var result = _sut.CalculateFuel(mass);
					Assert.Equal(expected, result);
				}

				[Fact]
				public async Task CalculateFuel_InputFile() {
					var test_data = await Util.ReadTestData("Day1.txt");
					var result = test_data
						.Split("\n")
						.Select(int.Parse)
						.Aggregate(0.0, (sum, mass) => {
							var fuel = _sut.CalculateFuel(mass);
							return sum + fuel;
						});
						Assert.Equal(3443395, result);
				}

				[Theory]
				[InlineData(12, 2)]
				[InlineData(14, 2)]
				[InlineData(1969, 966)]
				[InlineData(100756, 50346)]
				public void CalculateFuelRecursive_SampleCases(double mass, double expected) {
					var result = _sut.CalculateFuelRecursive(mass);
					Assert.Equal(expected, result);
				}

				[Fact]
				public async Task CalculateFuelRecursive_InputFile() {
					var test_data = await Util.ReadTestData("Day1.txt");
					var result = test_data
						.Split("\n")
						.Select(int.Parse)
						.Aggregate(0.0, (sum, mass) => {
							var fuel = _sut.CalculateFuelRecursive(mass);
							return sum + fuel;
						});
						Assert.Equal(5162216, result);
				}
    }
}
