using MPP_TeledonClientServer.model;

namespace MPP_TeledonClientServer.repository
{
    public interface IVolunteerRepository
    {
        Volunteer FindOne(string username, string password);
    }
}