﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceContract.Entry
{
    public class EntryEventArgs<T> : EventArgs
    {
        public virtual T Item { get; }
        public EntryEventArgs(T item)
        {
            this.Item = item;
        }
    }
}