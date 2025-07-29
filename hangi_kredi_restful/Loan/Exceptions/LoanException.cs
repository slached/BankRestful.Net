namespace HangiKredi.API.Loan.Exceptions
{
    public class LoanException : Exception
    {

        public LoanException() : base("Loan operation failed due to invalid parameters.")
        {
        }
        public LoanException(string message) : base(message)
        {
        }
        public LoanException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public LoanException(string message, params object[] args)
            : base(string.Format(message, args))
        {

        }
        public LoanException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }
    }
}
