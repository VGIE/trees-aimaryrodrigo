namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using System.Collections;


public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list

        return m_numItems;
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        if (index < 0 || index >= m_numItems)
        {
            return default(T);
        }
        else
        {
            int aux = 0;
            ListNode<T> listAyuda = First;
            while (aux < index)
            {
                listAyuda = listAyuda.Next;
                aux++;
            }
            return listAyuda.Value;
        }
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        if (First == null)
        {
            ListNode<T> nuevo = new ListNode<T>(value);

            First = nuevo;
            Last = nuevo;

            m_numItems++;
        }
        else
        {
            ListNode<T> nuevo = new ListNode<T>(value);

            Last.Next = nuevo;
            Last = nuevo;

            m_numItems++;
        }
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        ListNode<T> node = First;
        if (index < 0 || index >= m_numItems)
        {
            return default(T);
        }

        T elementElim;
        // Caso: eliminar la cabeza
        if (index == 0 && First.Next != null)
        {
            elementElim = First.Value;
            First = First.Next;
            m_numItems--;
            return elementElim;
        }
        else if (index == 0 && First.Next == null)
        {
            elementElim = First.Value;
            First = null;
            Last = null;
            m_numItems--;
            return elementElim;
        }

        for (int i = 0; i < index - 1; i++)
        {
            node = node.Next;
        }

        ListNode<T> Telim = node.Next;
        elementElim = Telim.Value;
        node.Next = Telim.Next;
        m_numItems--;

        if (Telim == Last)
        {
            Last = null;
        }
        return elementElim;



    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        First = null;
        Last = null;
        m_numItems = 0;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        for (int i = 0; i < m_numItems; i++)
        {
            yield return Get(i);
        }
    }
}