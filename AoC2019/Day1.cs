using System;

namespace AoC2019
{
    public class Day1
    {
			public double CalculateFuel(double mass) {
				return Math.Max(0, Math.Floor(mass / 3.0) - 2);
			}

			public double CalculateFuelRecursive(double mass) {
				var sum = 0.0;
				while (mass > 0) {
					var fuel = CalculateFuel(mass);
					sum += fuel;
					mass = fuel;
				}
				return sum;
			}
    }
}
