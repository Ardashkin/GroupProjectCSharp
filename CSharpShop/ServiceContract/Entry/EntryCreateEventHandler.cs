using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceContract.Entry
{
    public delegate void EntryCreateEventHandler<T>(object sender, EntryEventArgs<T> e);
}