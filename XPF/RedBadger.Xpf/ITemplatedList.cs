﻿namespace RedBadger.Xpf
{
    using System;

#if WINDOWS_PHONE
    public interface ITemplatedList<T>
#else
    public interface ITemplatedList<in T>
#endif
    {
        void Add(object item, Func<object, IElement> template);

        void Clear();

        void Insert(int index, object item, Func<object, IElement> template);

        void Move(int oldIndex, int newIndex);

        void RemoveAt(int index);
    }
}