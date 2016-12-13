using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Entry 
{
    public delegate void EntrySaveDataEventHandler<T>(object sender, EntryEventArgs<T> e);
}