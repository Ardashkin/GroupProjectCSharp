using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Entry;
using Repository;
using Logger;
using DomainModel;

namespace Server
{
    public class ShopServiceBase<T> : IShopServiceBase<T>, IEntry<T> where T : BaseModel
    {
        protected readonly IRepository<T> repository;

        public event EntryCreateEventHandler<T> CreateEvent;
        public event EntryUpdateEventHandler<T> UpdateEvent;
        public event EntryDeleteEventHandler<T> DeleteEvent;
        public event EntrySaveDataEventHandler<T> SaveEvent;

        public ShopServiceBase()
        {
            repository = new Repository<T>();
            CreateEvent += new EntryCreateEventHandler<T>(OnCreateEventHandler);
            UpdateEvent += new EntryUpdateEventHandler<T>(OnUpdateEventHandler);
            DeleteEvent += new EntryDeleteEventHandler<T>(OnDeleteEventHandler);
            SaveEvent += new EntrySaveDataEventHandler<T>(OnSaveEventHandler);
        }
        public void Create(T item)
        {
            repository.Create(item);
            OnCreateEvent(item);
            repository.Save();
            OnSaveEvent(item);
        }

        public IEnumerable<T> GetItems()
        {
            return repository.GetItems();
        }

        public void Update(T item)
        {
            repository.Update(item);
            OnUpdateEvent(item);
            repository.Save();
            OnSaveEvent(item);
        }

        public void Delete(T item)
        {
            repository.Delete(item);
            OnDeleteEvent(item);
            repository.Save();
            OnSaveEvent(item);
        }
        protected virtual void OnCreateEvent(T item)
        {
            if (CreateEvent != null)
            {
                CreateEvent(this, new EntryEventArgs<T>(item));
            }
        }
        protected virtual void OnUpdateEvent(T item)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EntryEventArgs<T>(item));
            }
        }
        protected virtual void OnDeleteEvent(T item)
        {
            if (DeleteEvent != null)
            {
                DeleteEvent(this, new EntryEventArgs<T>(item));
            }
        }
        protected virtual void OnSaveEvent(T item)
        {
            if (SaveEvent != null)
            {
                SaveEvent(this, new EntryEventArgs<T>(item));
            }
        }
        protected virtual void OnCreateEventHandler(object sender, EntryEventArgs<T> e)
        {
            Log.Write("New item of " + e.Item.GetType().Name + " model was created:\n" + e.Item.ToString());
        }
        protected virtual void OnUpdateEventHandler(object sender, EntryEventArgs<T> e)
        {
            Log.Write("Item of " + e.Item.GetType().Name + " model was updated:\n" + e.Item.ToString());
        }
        protected virtual void OnDeleteEventHandler(object sender, EntryEventArgs<T> e)
        {
            Log.Write("Item of " + e.Item.GetType().Name + " model was deleted:\n" + e.Item.ToString());
        }
        protected virtual void OnSaveEventHandler(object sender, EntryEventArgs<T> e)
        {
            Log.Write("Data of " + e.Item.GetType().Name + " model was saved:\n" + e.Item.ToString());
        }
    }
}