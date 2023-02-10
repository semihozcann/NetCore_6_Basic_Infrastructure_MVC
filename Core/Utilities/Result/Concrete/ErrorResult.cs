namespace Core.Utilities.Result.Concrete
{
    public class ErrorResult : Result
    {

        public ErrorResult(string message) : base(false, message)
        {

        }

        public ErrorResult() : base(false)
        {

        }


    }
}
