using System.Data.Entity;

namespace CoreBase.SaveActors
{
    public interface ISaveActorBase
    {
        bool NeedDoAction(object entity, EntityState state);
        void DoAction(object entity, EntityState state);
    }
}