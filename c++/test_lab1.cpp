#include <cassert>
#include <cstdlib>
#include <iostream>
#include <string>

#include "lab1.h"

class TestRunner {
 private:
  int passed = 0;
  int failed = 0;

 public:
  void test(const std::string& name, bool condition) {
    if (condition) {
      std::cout << "[PASS] " << name << std::endl;
      passed++;
    } else {
      std::cout << "[FAIL] " << name << std::endl;
      failed++;
    }
  }

  void summary() {
    std::cout << "\n=== Test Summary ===" << std::endl;
    std::cout << "Passed: " << passed << std::endl;
    std::cout << "Failed: " << failed << std::endl;
    std::cout << "Total:  " << (passed + failed) << std::endl;

    if (failed > 0) {
      std::cout << "TESTS FAILED!" << std::endl;
      exit(1);
    } else {
      std::cout << "ALL TESTS PASSED!" << std::endl;
    }
  }
};

void testLargestPrimeFactor(TestRunner& runner) {
  std::cout << "\n=== Testing largestPrimeFactor ===" << std::endl;

  runner.test("largestPrimeFactor(13195) == 29",
              largestPrimeFactor(13195) == 29);

  runner.test("largestPrimeFactor(600851475143) == 6857",
              largestPrimeFactor(600851475143LL) == 6857);
}

void testCalculateSpiralDiagonalSum(TestRunner& runner) {
  std::cout << "\n=== Testing calculateSpiralDiagonalSum ===" << std::endl;

  runner.test("calculateSpiralDiagonalSum(5) == 101",
              calculateSpiralDiagonalSum(5) == 101);

  runner.test("calculateSpiralDiagonalSum(1001) == 669171001",
              calculateSpiralDiagonalSum(1001) == 669171001);
}

int main() {
  TestRunner runner;

  std::cout << "Running C++ Unit Tests for Lab1" << std::endl;
  std::cout << "=================================" << std::endl;

  testLargestPrimeFactor(runner);
  testCalculateSpiralDiagonalSum(runner);

  runner.summary();

  return 0;
}