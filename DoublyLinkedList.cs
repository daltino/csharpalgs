namespace DoublyLinkedList
{
    public class LinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        public LinkedListNode Head { get; private set; }
        public LinkedListNode Tail { get; private set; }
        
        #region Add
        public void AddFirst(T value)
        {
          AddFirst(new LinkedListNode<T>(value));
        }
        
        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;
            Count++;

            if (Count == 1)
            {
              Tail = Head;
            } else {
              temp.Previous = Head;
            }
        }

        public void AddLast(T value)
        {
          AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }
        #endregion

        #region Remove
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                  Tail.Previous.Next = null;
                  Tail = Tail.Previous;
                }

                Count--;
            }
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
                else
                {
                  Head.Previous = null;
                }
            }
        }
        #endregion

        #region ICollection
        
        public int Count { get; private set; }

        public void Add(T item)
        {
          AddFirst(item);
        }

        public bool Contains(T item)
        {
          LinkedListNode<T> current = Head;
          while (current != null)
          {
              if (current.Value.Equals(item))
              {
                  return true;
              }

              current = current.Next;
          }

          return false;
        }

        public CopyTo(T[] array, int arrayIndex)
        {
          LinkedListNode<T> current = Head;
          while (current != null)
          {
              array[arrayIndex++] = current.Value;
              current = current.Next;
          }
        }

        public bool isReadOnly
        {
          get
          {
            return false;
          }
        }

        public bool Remove(T item)
        {
          LinkedListNode<T> previous = null;
          LinkedListNode<T> current = Head;
           
          while (current != null)
          {
              if (current.Value.Equals(item))
              {
                if (previous != null)
                {
                    previous.Next = current.Next;

                    if (current.Next == null)
                    {
                        Tail = previous;
                    }
                    else
                    {
                      current.Next.Previous = previous;
                    }

                    Count--;
                }
                else
                {
                  RemoveFirst();
                }
                
                return true;
              }

              previous = current;
              current = current.Next;
          }

          return false;
        }

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
          LinkedListNode<T> current = Head;
          while (current != null)
          {
              yield return current.Value;
              current = current.Next;
          }
        }

        System.Collections.Generic.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
          return((System.Collections.Generic.IEnumerator<T>)this).GetEnumerator();
        }

        public void Clear()
        {
          Head = null;
          Tail = null;
          Count = 0;
        }

        #endregion
    }
}