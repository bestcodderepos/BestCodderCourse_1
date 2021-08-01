namespace BestCodder.Common
{
    interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}
