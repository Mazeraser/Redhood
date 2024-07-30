using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Infrastructure.Factory
{
    public interface IFactory<T>
    {
        T CurrentItem { get; }
        T CreateItem();
    }
}
    