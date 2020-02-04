namespace LinkedList {
  public class LinkListNode<T>
  {
    public LinkListNode(T value)
    {
      Value = value;
    }

    public T Value { get; set; }
    public LinkedListNode<T> Next { get; set; }
  }
}
