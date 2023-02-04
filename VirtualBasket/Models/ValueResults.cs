namespace VirtualBasket.Models;

public struct ValueResults<T> where T : struct
{
    public required bool Success { get; init; }
    public required T Value { get; init; }
    public required int Code { get; init; }

    private string? _failure_message;
    public string FailureMessage => string.IsNullOrWhiteSpace(_failure_message) is true
        ? "No failure message has been provided"
        : _failure_message;

    public static ValueResults<T> Failed(int code = 0, string? failure_message = null) => new()
    {
        _failure_message = failure_message,
        Success = false,
        Code = code,
        Value = default!
    };

    public static ValueResults<T> Passed(T value, int code = 0) => new()
    {
        Success = true,
        Value = value,
        Code = code
    };
}
