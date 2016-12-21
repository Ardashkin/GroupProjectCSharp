using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.Entry
{
    public interface IEntry<T>
    {
        event EntryCreateEventHandler<T> CreateEvent;
        event EntryUpdateEventHandler<T> UpdateEvent;
        event EntryDeleteEventHandler<T> DeleteEvent;
        event EntrySaveDataEventHandler<T> SaveEvent;
    }
}
