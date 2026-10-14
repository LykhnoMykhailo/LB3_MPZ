using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1_1609
{
    public class DBItem<T> where T : IEntity
    {
        public int counter = 1;
        public List<T> Items { get; set; } = new List<T>();

        public void AddItem(T item)
        {
            item.Id = counter++;
            Items.Add(item);
        }
        public T GetItem(int id) 
        {
            foreach (T item in Items)
            {
                if (item.Id == id) return item;
            }
            return default(T);
        }
        public bool UpdateItem(T oldItem, T newItem)
        {
            newItem.Id = oldItem.Id;
            if (Items.Remove(oldItem))
            {
                Items.Add(newItem);
                return true;
            }
            return false;
        }
        public bool DeleteItem(T item)
        {
           return Items.Remove(item); 
        }
        
    }
}
