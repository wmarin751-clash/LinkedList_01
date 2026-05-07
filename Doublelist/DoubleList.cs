using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelist;

public class DoubleList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleList()
    {
        _head = null;
        _tail = null;
    }

    public void Add(T data)
    {
        var newNode = new Node<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        if (data.CompareTo(_head.Data) < 0)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            newNode.Previous = null;
            _head = newNode;

            return;
        }
        var current = _head;

        while (current.Next != null && current.Next.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }
        newNode.Next = current.Next;
        newNode.Previous = current;

        current.Next?.Previous = newNode;
        current.Next = newNode;

        if (newNode.Next == null)
        {
            _tail = newNode;
        }

    }


    override public string ToString()
    {
        var current = _head;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Next;
        }
        result += "null";
        return result;
    }

    public string ToStringReverse()
    {
        var current = _tail;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Previous;
        }
        result += "null";
        return result;
    }


    public void Order()
    {
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            current.Next = current.Previous;
            current.Previous = next;
            current = next;
        }
        var exchange = _head;
        _head = _tail;
        _tail = exchange;
    }


    public List<T> ShowModes()
    {
        var current = _head;
        if (_head == null) return new List<T>();
        var cont = 0;
        var contMax = 1;
        var modes = new List<T>();
        var previousdata = current.Data;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, previousdata))
            {
                cont++;
            }
            else
            {
                if (cont > contMax)
                {
                    contMax = cont;
                    modes.Clear();
                    modes.Add(previousdata);
                }
                else if (cont == contMax)
                {
                    modes.Add(previousdata);
                }
                cont = 1;
                previousdata = current.Data;
            }
            current = current.Next;
        }

        if (cont > contMax)
        {
            modes.Clear();
            modes.Add(previousdata);
        }
        else if (cont == contMax)
        {
            modes.Add(previousdata);
        }
        return modes;
    }



    public List<(T value, int count)> ShowChart()
    {
        var result = new List<(T value, int count)>();

        if (_head == null)
            return result;

        var current = _head;

        while (current != null)
        {

            bool alreadyProcessed = false;
            foreach (var item in result)
            {
                if (EqualityComparer<T>.Default.Equals(item.value, current.Data))
                {
                    alreadyProcessed = true;
                    break;
                }
            }

            if (!alreadyProcessed)
            {
                int count = 0;
                var temp = _head;

                while (temp != null)
                {
                    if (EqualityComparer<T>.Default.Equals(temp.Data, current.Data))
                    {
                        count++;
                    }
                    temp = temp.Next;
                }

                result.Add((current.Data, count));
            }

            current = current.Next;
        }

        return result;
    }



    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }



    public void RemoveOccurrence(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current == _head)
                {
                    _head = _head.Next;
                    _head!.Previous = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Previous;
                    _tail!.Next = null;
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
                return;
            }
            current = current.Next;

        }
    }


    public void RemoveOccurrences(T data)
    {
        var current = _head;
        if (_head == null) return;

        while (current != null)
        {
            var next = current.Next;
            if (current.Data!.Equals(data))
            {
                if (current == _head)
                {
                    _head = _head.Next;
                    if (_head != null)
                        _head.Previous = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Previous;
                    if (_tail != null)
                        _tail.Next = null;
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
            }

            current = next; 
        }
    }
}
