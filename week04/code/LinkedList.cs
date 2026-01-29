using System.Collections;

/// <summary>
/// A doubly linked list that stores integers and supports
/// insertion, removal, replacement, and forward/backward iteration.
/// </summary>
public class LinkedList : IEnumerable<int>
{
    private Node? _head; // First node in the list
    private Node? _tail; // Last node in the list

    /// <summary>
    /// Insert a new node at the front (head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);

        if (_head is null) // Empty list: head and tail both point to the new node
        {
            _head = newNode;
            _tail = newNode;
        }
        else // Non-empty list: adjust head pointers
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the end (tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        if (_tail is null) // Empty list
        {
            _head = newNode;
            _tail = newNode;
        }
        else // Non-empty list: adjust tail pointers
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail) // Empty or single node list
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null) // More than one node
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Remove the last node (tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_tail is null) return; // Empty list

        if (_head == _tail) // Single node
        {
            _head = null;
            _tail = null;
        }
        else // More than one node
        {
            _tail = _tail.Prev;
            _tail!.Next = null;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first node that contains 'value'.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail) // If it's the tail, just use InsertTail
                {
                    InsertTail(newValue);
                }
                else // Insert in the middle
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return; // Only insert once
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head) RemoveHead();
                else if (curr == _tail) RemoveTail();
                else // Node in middle
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return; // Remove only the first occurrence
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Replace all nodes with 'oldValue' to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue) curr.Data = newValue;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Forward iteration over the linked list.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public IEnumerator<int> GetEnumerator()
    {
        Node? curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Reverse iteration over the linked list.
    /// </summary>
    public IEnumerable Reverse()
    {
        Node? curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    /// <summary>
    /// Convert the linked list to a readable string.
    /// </summary>
    public override string ToString()
        => "<LinkedList>{" + string.Join(", ", this) + "}";

    // Methods for testing
    public bool HeadAndTailAreNull() => _head is null && _tail is null;
    public bool HeadAndTailAreNotNull() => _head is not null && _tail is not null;
}

/// <summary>
/// Extension method to convert IEnumerable to string for testing.
/// </summary>
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
        => "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
}
