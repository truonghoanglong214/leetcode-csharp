using System;
/// <summary>
Given an integer array of size n, find all elements that appear more than ⌊n / 3⌋ times.



Example 1:

Input: nums = [3, 2, 3]
Output: [3]
Example 2:

Input: nums = [1]
Output: [1]
Example 3:

Input: nums = [1, 2]
Output: [1, 2]



Constraints:

1 <= nums.length <= 5 * 104
- 109 <= nums[i] <= 109
/// </summary>
public class Class1
{
    public IList<int> MajorityElement(int[] nums)
    {
        var seen = new Dictionary<int, int>();
        var list = new List<int>();
        foreach (int n in nums)
            seen[n] = seen.GetValueOrDefault(n, 0) + 1;

        foreach (var pair in seen)
        {
            if (pair.Value > nums.Length / 3)
                list.Add(pair.Key);
        }

        return list;
    }

    public IList<int> MajorityElementV2(int[] nums)
    {
        int candidate = 0, candidate1 = 0;
        int count = 0, count1 = 0;

        var list = new List<int>();
        foreach (int num in nums)
        {
            if (candidate == num)
            {
                count++;
            }
            else if (candidate1 == num)
            {
                count1++;
            }
            else if (count == 0)
            {
                candidate = num;
                count++;
            }
            else if (count1 == 0)
            {
                candidate1 = num;
                count1++;
            }
            else
            {
                count--;
                count1--;
            }
        }

        count = 0;
        count1 = 0;
        foreach (int num in nums)
        {
            if (candidate == num)
            {
                count++;
            }
            else if (candidate1 == num)
            {
                count1++;
            }
        }
        if (count > nums.Length / 3)
            list.Add(candidate);

        if (count1 > nums.Length / 3)
            list.Add(candidate1);
        return list;
    }
}
