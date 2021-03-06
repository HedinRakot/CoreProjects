﻿using CoreBase.SaveActors;
using System.Collections.Generic;
using System.Data.Entity;

namespace CoreBase.SaveActors
{
    public abstract class SaveActorManager<TSaveActor> where TSaveActor: ISaveActorBase
    {
        private readonly List<TSaveActor> actors = new List<TSaveActor>();

        protected SaveActorManager(IEnumerable<TSaveActor> actors)
        {
            this.actors = new List<TSaveActor>(actors);
        }

        public void DoBeforeSaveAction(object entity, EntityState state)
        {
            foreach (var saveActor in actors)
            {
                if (saveActor.NeedDoAction(entity, state))
                {
                    saveActor.DoAction(entity, state);
                }
            }
        }
    }
}
