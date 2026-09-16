public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> counts = new Dictionary<int, int>();

        foreach (int num in nums) {
            counts.TryGetValue(num, out int currentCount);
            counts[num] = 1 + currentCount;
        }

        // 1. Initialize the array of lists (buckets)
        List<int>[] buckets = new List<int>[nums.Length + 1];
        for (int i = 0; i <= nums.Length; i++) {
            buckets[i] = new List<int>();
        }

        // 2. Populate buckets based on frequency
        foreach (var kvp in counts) {
            int number = kvp.Key;
            int frequency = kvp.Value;
            buckets[frequency].Add(number);
        }

        // 3. Read backwards to get top k frequent elements
        int[] result = new int[k];
        int resultIndex = 0;

        for (int i = buckets.Length - 1; i >= 0; i--) {
            foreach (int num in buckets[i]) {
                result[resultIndex] = num;
                resultIndex++;

                if (resultIndex == k) {
                    return result;
                }
            }
        }
        return result;
    }
}
