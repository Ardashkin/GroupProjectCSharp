using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceContract.Entry;
using Repository;
using Logger;
using DomainModel;

namespace ServiceContract
{
    public class ShopServiceBase<TEntity> : IShopServiceBase<TEntity>, IEntry<TEntity> where TEntity : BaseModel
    {
        protected readonly IRepository<TEntity> repository;

        public event EntryCreateEventHandler<TEntity> CreateEvent;
        public event EntryUpdateEventHandler<TEntity> UpdateEvent;
        public event EntryDeleteEventHandler<TEntity> DeleteEvent;
        public event EntrySaveDataEventHandler<TEntity> SaveEvent;

        public ShopServiceBase()
        {
            repository = new Repository<TEntity>();
            CreateEvent += new EntryCreateEventHandler<TEntity>(OnCreateEventHandler);
            UpdateEvent += new EntryUpdateEventHandler<TEntity>(OnUpdateEventHandler);
            DeleteEvent += new EntryDeleteEventHandler<TEntity>(OnDeleteEventHandler);
            SaveEvent += new EntrySaveDataEventHandler<TEntity>(OnSaveEventHandler);
        }
        public void Create(TEntity item)
        {
            repository.Create(item);
            OnCreateEvent(item);
            repository.Save();
            OnSaveEvent(item);
        }

        public IEnumerable<TEntity> GetItems()
        {
            return repository.GetItems();
        }

        public void Update(TEntity item)
        {
            repository.Update(item);
            OnUpdateEvent(item);
            repository.Save();
            OnSaveEvent(item);
        }

        public void Delete(TEntity item)
        {
            repository.Delete(item);
            OnDeleteEvent(item);
            repository.Save();
            OnSaveEvent(item);
        }
        protected virtual void OnCreateEvent(TEntity item)
        {
            EntryCreateEventHandler<TEntity> handler = CreateEvent;
            handler?.Invoke(this, new EntryEventArgs<TEntity>(item));
        }
        protected virtual void OnUpdateEvent(TEntity item)
        {
            EntryUpdateEventHandler<TEntity> handler = UpdateEvent;
            handler?.Invoke(this, new EntryEventArgs<TEntity>(item));
        }
        protected virtual void OnDeleteEvent(TEntity item)
        {
            EntryDeleteEventHandler<TEntity> handler = DeleteEvent;
            handler?.Invoke(this, new EntryEventArgs<TEntity>(item));
        }
        protected virtual void OnSaveEvent(TEntity item)
        {
            EntrySaveDataEventHandler<TEntity> handler = SaveEvent;
            handler?.Invoke(this, new EntryEventArgs<TEntity>(item));
        }
        protected virtual void OnCreateEventHandler(object sender, EntryEventArgs<TEntity> e)
        {
            Log.Write("New item of " + e.Item.GetType().Name + " model was created:\n" + e.Item.ToString());
        }
        protected virtual void OnUpdateEventHandler(object sender, EntryEventArgs<TEntity> e)
        {
            Log.Write("Item of " + e.Item.GetType().Name + " model was updated:\n" + e.Item.ToString());
        }
        protected virtual void OnDeleteEventHandler(object sender, EntryEventArgs<TEntity> e)
        {
            Log.Write("Item of " + e.Item.GetType().Name + " model was deleted:\n" + e.Item.ToString());
        }
        protected virtual void OnSaveEventHandler(object sender, EntryEventArgs<TEntity> e)
        {
            Log.Write("Data of " + e.Item.GetType().Name + " model was saved:\n" + e.Item.ToString());
        }
    }
}