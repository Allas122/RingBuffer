namespace RingBuffer
{
    public class RingBuffer<T>
    {
        int Length = 1;
        RingBufferElement<T> Pointer;
        RingBufferElement<T> First;
        public RingBuffer(int length) {
            if (length < 1)
            {
                throw new ArgumentException("the length is too low: ", nameof(length));
            }
            Length = length;
            RingBufferElement<T> first = new RingBufferElement<T>(default, null, null);
            RingBufferElement<T> pointer = first;
            for (int i = 1; i < Length; i++)
            {
                pointer.next = new RingBufferElement<T>(default, null, null);
                pointer.next.previous = pointer; 
                pointer = pointer.next;

            }
            first.previous = pointer;
            first.previous.next = first;
            Pointer = first;
            First = first;
        }
        public void add(T Value)
        {
            Pointer = Pointer.next;
            Pointer.Value = Value;
        }
        public T get()
        {
            Pointer = Pointer.next;
            return Pointer.Value;
        }
        public void clearPointer()
        {
            Pointer = First;
        }

    }
    public class RingBufferElement<T>
    {
        public T? Value { get; set; }
        public RingBufferElement<T>? next;
        public RingBufferElement<T>? previous;
        public RingBufferElement(T? value,RingBufferElement<T>? next,RingBufferElement<T>? previous)
        {
            Value = value;
        }
    }
}