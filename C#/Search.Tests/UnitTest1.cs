using Xunit;
using Xunit.Abstractions;
using Search;
using System.Diagnostics;
using System.Text;

namespace Search.Test;

public class SearchTests
{

    private readonly ITestOutputHelper testOutput;

    public SearchTests(ITestOutputHelper testOutput) {
        this.testOutput = testOutput;
    }

    [Fact]
    public void EnhBSearch_SimpleArrayTest_EvenCount_ExactString()
    {
        var bs = new BinarySearch();
        List<string> directions = bs.EnhBinarySearch([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 10, []);
        StringBuilder sb = new(directions.Count);
        directions.ForEach(x => sb.Append(x + "|"));
        testOutput.WriteLine(sb.ToString());
        Assert.True(directions.Equals(new string[] {"r", "r", "rc"}));
    }

    [Fact]
    public void EnhBSearch_SimpleArrayTest_OddCount_ExactString()
    {
        var bs = new BinarySearch();
        List<string> directions = bs.EnhBinarySearch([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11], 11, []);
        StringBuilder sb = new(directions.Count);
        directions.ForEach(x => sb.Append(x + "|"));
        testOutput.WriteLine(sb.ToString());
        Assert.True(directions.Equals(new string[] {"r", "r", "rc"}));
    }

    [Fact]
    public void EnhBSearch_ResultLeft_OddCount_ExactString()
    {
        var bs = new BinarySearch();
        List<string> directions = bs.EnhBinarySearch([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11], 3, []);
        StringBuilder sb = new(directions.Count);
        directions.ForEach(x => sb.Append(x + "|"));
        testOutput.WriteLine(sb.ToString());
        Assert.True(directions.Equals(new string[] {"l", "r", "rc"}));
    }

    [Fact]
    public void EnhBSearch_NonConsecArray_OddCount_ExactString()
    {
        var bs = new BinarySearch();
        List<string> directions = bs.EnhBinarySearch([1, 3, 4, 7, 21, 32, 56, 58, 100, 1010, 9911], 7, []);
        StringBuilder sb = new(directions.Count);
        directions.ForEach(x => sb.Append(x + "|"));
        testOutput.WriteLine(sb.ToString());
        Assert.True(directions.Equals(new string[] {"l", "r", "lc"}));
    }
}