using System.Collections;
using FluentAssertions;
using Xunit;

namespace Kata_Hashi2;

public class HashiGameTests
{
    [Theory]
    [ClassData(typeof(TestSolution))]
    public void CheckSolvability(Solution solution)
    {
        var hashiGame = new HashiGame(solution);

        hashiGame.IsSolvable.Should().BeTrue();
    }
}

public class TestSolution : IEnumerable<object[]>
{
    /*
     * 2
     * ‖
     * 3 - 1
     */
    private static readonly Solution _realExample1 = new(
        new() { new(113), new(211), new(122) },
        new() { new(113, 211, 1), new(113, 122, 2) });

    /*
     * 2 ----- 1
     * |
     * 5 = 2
     * ‖
     * 4 ===== 2
     */
    private static readonly Solution _realExample2 = new(
        new()
        {
            new(114), new(312), new(125), new(222), new(132), new(331)
        },
        new()
        {
            new(114, 312, 2), new(114, 125, 2), new(125, 222, 2),
            new (125, 132, 1), new(132, 331, 1)
        });

    /*
     * https://jayisgames.com/images/conceptis-hashi/hashi8x8p10.jpg
     */
    private static readonly Solution _realExample3 = new(
        new()
        {
            new(113), new(315), new(513), new(813), new(133), new(332),
            new(155), new(454), new(423), new(621), new(472), new(271),
            new(184), new(383), new(583), new(781), new(565), new(762),
            new(533), new(731), new(854), new(651), new(874), new(672)
        },
        new()
        {
            new(113, 315, 2), new(315, 513, 1), new(513, 813, 2),
            new(113, 133, 1), new(315, 332, 2), new(133, 155, 2),
            new(155, 454, 1), new(454, 423, 2), new(423, 621, 1),
            new(454, 472, 1), new(472, 271, 1), new(155, 184, 2),
            new(184, 383, 2), new(383, 583, 1), new(583, 781, 1),
            new(583, 565, 1), new(565, 762, 2), new(565, 533, 2),
            new(533, 731, 1), new(813, 854, 1), new(854, 651, 1),
            new(854, 874, 2), new(874, 672, 2)

        }
    );

    private static readonly Solution _exampleWithNoIslands = new(
        new() { },
        new() { }
    );

    private static readonly Solution _exampleWithIslandOffTheBoard = new(
        new() { new(1234) },
        new() { }
    );

    private readonly List<object[]> _data = new()
    {
        new object[] { _exampleWithNoIslands },
        new object[] { _exampleWithIslandOffTheBoard },
        new object[] { _realExample1 },
        new object[] { _realExample2 },
        new object[] { _realExample3 }
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}