namespace Crud.App.Domain.Core.Commands
{
    public class CommandResponse
    {
        public static CommandResponse OK = new CommandResponse(success: true);
        public static CommandResponse Fail = new CommandResponse(success: false);
        public bool Success { get; private set; }

        public CommandResponse(bool success = false)
        {
            Success = success;
        }
    }
}
