using AliExpressTask;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Solution_TaskCase()
    {
        var solution = new Solution();
        var testArray = new int[] { 1, 5, 2, 1, 4, 0 };
        var result = solution.solution(testArray);
        Assert.Equal(11, result);
    }

    [Fact]
    public void Solution_CountOfIntersectionsIsGreaterThan10M_ReturnsMinusOne()
    {
        var solution = new Solution();
        var testArray = new int[10000];
        for (int i = 0; i < testArray.Length; i++)
            testArray[i] = int.MaxValue;

        var result = solution.solution(testArray);
        Assert.Equal(-1, result);
    }
}