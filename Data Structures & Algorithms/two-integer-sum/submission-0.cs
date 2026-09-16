public class Solution {
    public int[] TwoSum(int[] nums, int target) {
    Dictionary<int, int> values = new Dictionary<int, int>();
    int[] result = new int[2];

    for(int i = 0; i < nums.Length; i++)
    {

        int diff = target - nums[i];

        if (values.ContainsKey(diff))
        {
            result[0] = values[diff];
            result[1] = i;
            return result;
        }

        if (!values.ContainsKey(nums[i]))
            values[nums[i]] = i;
    }

    return result;
    }
}
