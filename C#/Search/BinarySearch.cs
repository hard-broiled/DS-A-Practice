using System;

namespace Search;

public class BinarySearch
{
    /// <summary>
    /// 
    /// </summary>
    public BinarySearch() {

    }
    /// <summary>
    /// Enhanced Binary Search utilizes standard BS algo to subdivide arrays into halves and
    /// explore each half for the target value. 
    /// The enhancement includes a string array carried through the recursion to add a 
    /// "l" or "r" to reflect left or right "turns" in the search effort, returning
    /// "directions" to the target if found in the provided array.
    /// </summary>
    /// <param name="arr">Target sorted int array to be searched</param>
    /// <param name="target">Int value to be searched for</param>
    /// <param name="directions">String array of directions to the target</param>
    /// <returns>The "directions" array if the target is found. Otherwise returns an empty string array</returns>
    /// <exception cref=""></exception>
    public List<string> EnhBinarySearch(int[] arr, int target, List<string> directions) {
        int splitIdx = (arr.Length-1)/2;
        int pivot = arr[splitIdx];

        if (pivot == target) {
            directions.Add("c");
            return directions;
        }
        else if (arr.Length == 2) {
            if (arr[0] == target) {
                directions.Add("lc");
                return directions;
            }
            
            else if( arr[1] == target) {
                directions.Add("rc");
                return directions;
            }
            return []; //false case 
        }
        else if (target < pivot) {
            directions.Add("l");
            int front = 0;//Index front = 0;
            int length = (arr.Length/2)-1;//Index end = arr.Length-1/2-1; //arr[front..end]
            int[] leftArr = new Span<int>(arr, front, length).ToArray();
            return EnhBinarySearch(leftArr, target, directions);
        }
        else {
            directions.Add("r");
            int front = ((arr.Length-1)/2)+1; // excluding the previous split value
            int length = arr.Length/2;
            int[] rightArr = new Span<int>(arr, front, length).ToArray();
            return EnhBinarySearch(rightArr, target, directions);
        }
    }
}
