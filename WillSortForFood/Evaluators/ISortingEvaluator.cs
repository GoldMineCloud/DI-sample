using System.Collections.Generic;

namespace WillSortForFood.Evaluators
{
    interface ISortingEvaluator
    {
        EvaluationResult EvaluateOn(IEnumerable<int> items);
    }
}