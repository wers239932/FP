#include <iostream>
#include <cmath>
#include <algorithm>

long long largestPrimeFactor(long long n) {
    long long maxPrime = 1;

    while (n % 2 == 0) {
        maxPrime = 2;
        n /= 2;
    }

    for (long long i = 3; i <= sqrt(n); i += 2) {
        while (n % i == 0) {
            maxPrime = i;
            n /= i;
        }
    }

    if (n > 2) {
        maxPrime = n;
    }

    return maxPrime;
}

long long calculateSpiralDiagonalSum(int size) {
    if (size % 2 == 0) {
        return -1;
    }

    long long sum = 1;
    long long currentNum = 1;

    for (int i = 2; i <= (size + 1) / 2; ++i) {
        long long sideLength = (long long)(2 * i - 1);
        long long step = sideLength - 1;

        currentNum += step;
        sum += currentNum;

        currentNum += step;
        sum += currentNum;

        currentNum += step;
        sum += currentNum;

        currentNum += step;
        sum += currentNum;
    }

    return sum;
}

int main() {
    long long num1 = 13195;
    long long num2 = 600851475143LL;

    std::cout << "Largest prime factor of " << num1 << ": " << largestPrimeFactor(num1) << std::endl;
    std::cout << "Largest prime factor of " << num2 << ": " << largestPrimeFactor(num2) << std::endl;

    // Test cases for Task 2
    int spiralSize1 = 5;
    int spiralSize2 = 1001;

    std::cout << "Spiral diagonal sum for " << spiralSize1 << "x" << spiralSize1 << ": " << calculateSpiralDiagonalSum(spiralSize1) << std::endl;
    std::cout << "Spiral diagonal sum for " << spiralSize2 << "x" << spiralSize2 << ": " << calculateSpiralDiagonalSum(spiralSize2) << std::endl;

    return 0;
}
