namespace WillSortForFood
{
    public class EvaluationResult
    {
        public long TimeInMs { get; set; }
        public int[] SortedItems { get; set; }
        public string SortingAlgorithmName { get; private set; }

        public EvaluationResult(string sortingAlgorithmName)
        {
            SortingAlgorithmName = sortingAlgorithmName;
        }
    }
}