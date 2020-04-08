using System;

namespace MPP_TeledonClientServer.model
{
    [Serializable]
    public class Entity<T>
    {
        private T id;

        public T Id
        {
            get { return id; }
            set { id = value; }
        }

        public Entity(T id)
        {
            this.id = id;
            //Id = id;
        }

    }
}