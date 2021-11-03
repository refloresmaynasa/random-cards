namespace Application.Interfaces
{
    public interface ISessionService
    {
        string CurrentUserId { get; }
        string CurrentUserName { get; }
        string CurrentUserEmail { get; }
    }
}
