using System.Data.Entity;

namespace CoreBase.SaveActors
{
    public interface ISaveActorManagerBase
    {
        void DoBeforeSaveAction(object entity, EntityState state);
    }
}