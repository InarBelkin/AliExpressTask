namespace AliExpressTask;

public class Solution
{
    public int solution(int[] a)
    {
        return PlainSolution(a);
        // return ParallelSolution(a);
    }

    private int PlainSolution(int[] a)
    {
        int count = 0;
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                if (Intersects(i, a[i], j, a[j]))
                    count++;
            }

            if (count > 10_000_000) return -1;
        }

        return count;
    }

    private int ParallelSolution(int[] a)
    {
        int finalCount = 0;
        var locker = new object();
        var loopResult = Parallel.For(0, a.Length - 1, (i, state) =>
        {
            var intermediateCount = 0;

            for (int j = i + 1; j < a.Length; j++)
            {
                if (Intersects(i, a[i], j, a[j]))
                    intermediateCount++;
            }

            lock (locker)
            {
                finalCount += intermediateCount;
                if (finalCount > 10_000_000) state.Break();
            }
        });
        return finalCount > 10_000_000 ? -1 : finalCount;
    }

    private bool Intersects(int aCenter, int aRadius, int bCenter, int bRadius)
    {
        var distanceBetweenCenters = bCenter - aCenter;
        return distanceBetweenCenters <= (uint)aRadius + (uint)bRadius;
    }
}