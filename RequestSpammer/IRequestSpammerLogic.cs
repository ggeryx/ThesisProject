using RequestSpammer.Models.Dtos;

namespace RequestSpammer
{
    public interface IRequestSpammerLogic
    {
        public ProcessResponseDto SendRequest();
    }
}
