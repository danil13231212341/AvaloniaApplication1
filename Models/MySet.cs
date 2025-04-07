using System;
using System.Collections.Generic;
using System.Threading;

namespace AvaloniaApplication1.Models
{
    public class MySet<T>
    {
        private readonly List<T> _setList;

        public int Count => _setList.Count;
        
        public bool IsEmpty => Count == 0;

        public MySet()
        {
            _setList = new List<T>();
            
        }
        //конструктор с начальными значениями
        public MySet(IEnumerable<T> collection)
        {
            if (collection == null){
                throw new ArgumentNullException(nameof(collection));
            }
                
            _setList = new List<T>();
            foreach (var item in collection)
            {
                Add(item); 
            }
}
       

        public void Add(T newElement)
        {
            if(newElement == null){
                throw new ArgumentNullException(nameof(newElement));
            }
            if( _setList.Contains(newElement) == false){
                _setList.Add(newElement);
            }
            
        }

        public void Remove(T element)
        {
            if(element == null){
                throw new ArgumentNullException(nameof(element));
            }
            if( _setList.Contains(element) == true){
                _setList.Remove(element);
            }
            
        }

        public void Clear()
        {
            _setList.Clear();
            
        }

        public T[] GetAllElements()
        {
            return _setList.ToArray();
        }

        public bool Contains(T element)
        {
            if(element == null){
                throw new ArgumentNullException(nameof(element));
            }
            return _setList.Contains(element);
        }
    }
}
