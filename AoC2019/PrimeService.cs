﻿using System;

namespace AoC2019
{
    public class PrimeService
    {
        public bool IsPrime(int candidate) {
            if (candidate < 2) {
                return false;
            }

            if (candidate == 2) {
                return true;
            }
            if (candidate % 2 == 0) {
                return false;
            }
            
            for (var i = 3; i <= Math.Sqrt(candidate); i += 2) {
                if (candidate % i == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}
