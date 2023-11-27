using Assignment3.ProblemDomain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment3.Utility
{
    /// <summary>
    /// My implementation of a singly linked list.
    /// </summary>
    /// <remarks>Author: Ki Fung Yuen</remarks>
    /// <remarks>Date: 22 Nov 2023</remarks>
    /// 


    public class SinglyLinkedList : ILinkedListADT
    {
        private Node head;
        private int size;

        /// <summary>
        /// Initializes a new instance of the SinglyLinkedList class.
        /// </summary>
        public SinglyLinkedList()
        {
            head = null;
            size = 0;
        }

        /// <summary>
        /// Checks if the linked list is empty.
        /// </summary>
        /// <returns>True if the linked list is empty; otherwise, false.</returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// Clears all elements from the linked list.
        /// </summary>
        public void Clear()
        {
            head = null;
            size = 0;
        }

        /// <summary>
        /// Appends the specified user to the end of the linked list.
        /// </summary>
        /// <param name="value">The user to append.</param>
        public void AddLast(User value)
        {
            Add(value, size);
        }

        /// <summary>
        /// Prepends the specified user to the beginning of the linked list.
        /// </summary>
        /// <param name="value">The user to prepend.</param>
        public void AddFirst(User value)
        {
            Add(value, 0);
        }

        /// <summary>
        /// Adds the specified user at the specified index in the linked list.
        /// </summary>
        /// <param name="value">The user to add.</param>
        /// <param name="index">The index at which to add the user.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is out of range.</exception>
        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node newNode = new Node(value);

            if (index == 0)
            {
                // Add at the beginning (prepend)
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                // Add at a specific position
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }

            size++;
        }


        public void RemoveFirst()
        {
            Remove(0);
        }

        public void RemoveLast()
        {
            Remove(size - 1);
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                // Remove the head (first element)
                head = head.Next;
            }
            else
            {
                // Remove from a specific position
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
            }

            size--;
        }


        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    // Value found at current index
                    return index;
                }

                current = current.Next;
                index++;
            }

            // Value not found in the list
            return -1;
        }

        //public int IndexOf(User value)
        //    {
        //        // ...

        //        return -1;
        //    }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }

        public int Count()
        {
            return size;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }


        /// <summary>
        /// Sorts the linked list based on user names in ascending order.
        /// </summary>
        public void Sort()
        {
            if (size <= 1)
            {
                // The list is already sorted or empty
                return;
            }

            // Use insertion sort to sort the list based on user names
            Node sortedHead = null; // The head of the sorted list

            Node current = head;
            while (current != null)
            {
                Node next = current.Next;

                // Insert current node into the sorted list
                sortedHead = InsertIntoSorted(sortedHead, current);

                current = next;
            }

            // Update the head of the original list to the head of the sorted list
            head = sortedHead;
        }

        private Node InsertIntoSorted(Node sortedHead, Node newNode)
        {
            if (sortedHead == null || string.Compare(newNode.Value.Name, sortedHead.Value.Name) <= 0)
            {
                // Insert at the beginning of the sorted list or when the list is empty
                newNode.Next = sortedHead;
                return newNode;
            }

            Node current = sortedHead;
            while (current.Next != null && string.Compare(newNode.Value.Name, current.Next.Value.Name) > 0)
            {
                // Traverse the sorted list to find the correct position to insert the new node
                current = current.Next;
            }

            // Insert the new node into the sorted position
            newNode.Next = current.Next;
            current.Next = newNode;

            return sortedHead;
        }
    }
}
