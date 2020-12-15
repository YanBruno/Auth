namespace Auth.Domain.Shared.Commands
{
    public interface ICommandResult
    {
        public bool Success { get; }
        public string Message { get; }
        public object Data { get; }
    }
}
