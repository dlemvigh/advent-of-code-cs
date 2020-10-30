using System.Linq;
using System.Threading.Tasks;
using AoC2019.Day9y2018;
using Xunit;

namespace AoC2019.Tests
{
    public class Day9y2018Tests
    {
				[Fact]
				public void MarbleManiaTests() {
					var result = ListNode.MarbleMania(9, 25);
					Assert.Equal(32, result);
				}

				[Theory]
				[InlineData(10, 1618, 8317)]
				[InlineData(13, 7999, 146373)]
				[InlineData(17, 1104, 2764)]
				[InlineData(21, 6111, 54718)]
				[InlineData(30, 5807, 37305)]
				public void MarbleMania_InputPlayersAndTurnNumber_ExpectedHighscore(int players, int turns, int expected) {
					var result = ListNode.MarbleMania(players, turns);
					Assert.Equal(expected, result);
				}

				[Fact]
				public void MarbleMania_Part1() {
					var result = ListNode.MarbleMania(404, 71852);
					Assert.Equal(434674, result);
				}

				[Fact]
				public void MarbleMania_Part2() {
					var result = ListNode.MarbleMania(404, 7185200);
					Assert.Equal(3653994575, result);
				}
    }
}
