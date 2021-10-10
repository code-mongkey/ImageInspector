using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInspector.Controls
{
    public class MyList<T> : List<T>
    {
        public event EventHandler OnAdd;
        public new void Add(T item)
        {
            base.Add(item);
            if (null != OnAdd)
            {
                OnAdd(this, null);
            }
        }
    }
}
