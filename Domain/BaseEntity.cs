using Domain.Core;

namespace Domain
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = ShortIdGenerator.GenerateShortId();
        }

        public string Id { get; set; }
    }
}