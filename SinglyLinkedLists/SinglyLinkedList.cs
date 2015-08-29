using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode first_node;

        // increment this variable in each "Add" method
        // decrement this variable in each "Remove" method
        private int listLength = 0;

        //public SinglyLinkedList()
        //{
        //    // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        //}

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        // List constructor with a variable number of parameters
        public SinglyLinkedList(params object[] values)
        {
            for (int i = 0; i < values.Count(); i++)
            {
                this.AddLast(values[i] as String);
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        // Element accessor method; making linked list act like an array when accessing data
        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set
            {
                // find the ith node and change its Value
                var thisNode = first_node;
                for (int x = 0; x < i; x++) { thisNode = thisNode.Next; }
                thisNode.Value = value;
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            var thisNode = first_node;
            bool found = false;

            for (int i = 0; i < listLength; i++)
            {
                if (thisNode.Value == existingValue)
                {
                    found = true;
                    break;
                }
                thisNode = thisNode.Next;
            }

            if (!found) { throw new ArgumentException(); }
            if (thisNode.IsLast())
            {
                this.AddLast(value);
                return;
            }
            // create new node and link it into the list
            var newNode = new SinglyLinkedListNode(value);
            newNode.Next = thisNode.Next;
            thisNode.Next = newNode;
            listLength += 1;

        }

        public void AddFirst(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else
            {
                var newFirstNode = new SinglyLinkedListNode(value);
                newFirstNode.Next = first_node;
                first_node = newFirstNode;
            }
            listLength += 1;

        }

        public void AddLast(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else
            {
                var currentNode = this.first_node;
                while (!currentNode.IsLast())
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new SinglyLinkedListNode(value);
            }
            listLength += 1;
        }

        public void AddInOrder(string value)
        {
            //var newNode = new SinglyLinkedListNode(value);
            var node1 = this.first_node;
            var node2 = node1.Next;
            for (int i = 0; i < this.listLength; i++)
            {
                // at beginning of list
                if ( i == 0 && (value.CompareTo(node1.Value) < 0 || value.CompareTo(node1.Value) == 0))
                {
                    this.AddFirst(value);
                    return;
                }
                // at end of list
                if (i == this.listLength -1 && value.CompareTo(node1.Value) > 0)
                {
                    this.AddLast(value);
                    return;
                }
                // middle of the list
                if (node1.Value.CompareTo(value) < 0 && node2.Value.CompareTo(value) > 0)
                {
                    this.AddAfter(node1.Value, value);
                    return;
                }
                if (node1.Value.CompareTo(value) == 0)
                {
                    this.AddAfter(node1.Value, value);
                    return;
                }
                node1 = node1.Next;
                node2 = node2.Next;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        // This method implementation relies on a private member variable, listLength, being
        // updated manually at each node add or remove.
        public int Count()
        {
            return listLength;
        }

        public string ElementAt(int index)
        {
            if (this.First() == null || index >= this.listLength)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var thisNode = this.first_node;
                for (int i = 0; i < index; i++) { thisNode = thisNode.Next; }
                
                return thisNode.Value;
            }
        }

        private SinglyLinkedListNode LastNode()
        {
            var thisNode = this.first_node;
            for (int i = 1; i < this.listLength; i++)
            {
                thisNode = thisNode.Next;
            }
            return thisNode;
        }

        public string First()
        {
            return (this.first_node == null) ? null : this.first_node.Value;
        }

        public int IndexOf(string value)
        {
            var thisNode = first_node;
            int index = -1;

            if (this.First() == null) { return index; }

            for (int i = 0; i < listLength; i++)
            {
                if (thisNode.Value == value)
                {
                    return i;
                    
                }
                thisNode = thisNode.Next;
            }
            return index;
        }

        public bool IsSorted()
        {
            var thisNode = this.first_node;
            for (int i = 0; i < listLength-1; i++)
            {
                if (thisNode.CompareTo(thisNode.Next) > 0)
                {
                    return false;
                }
                thisNode = thisNode.Next;
            }
            return true;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            return (this.first_node == null) ? null : this.LastNode().Value;
        }

        public void RemoveNode(int num)
        {
            var thisNode = this.first_node;
            var previousNode = this.first_node;
            
            for (int i = 0; i < num; i++)
            {
                
                if (i > 0)
                {
                    previousNode = thisNode;
                }
                thisNode = thisNode.Next;
            }

            if (num == 0)
            {
                first_node = first_node.Next;
                listLength -= 1;
                return;
            }
            previousNode.Next = thisNode.Next;
            listLength -= 1;

        }

        public void Remove(string value)
        {
            var thisNode = this.first_node;
            var previousNode = this.first_node;
            int index = 0;
            bool found = false;

            for (int i = 0; i < listLength; i++)
            {
                if (thisNode.Value == value)
                {
                    index = i;
                    found = true;
                    break;
                }
                if (i > 0)
                {
                    previousNode = thisNode;
                }
                thisNode = thisNode.Next;
            }
            if (!found) { return; }
            if (index == 0)
            {
                first_node = first_node.Next;
                listLength -= 1;
                return;
            }
            previousNode.Next = thisNode.Next;
            listLength -= 1;

        }

        //Implementation of Bubblesort
        public void Sort()
        {
            while (!this.IsSorted())
            {
                var node1 = this.first_node;
                var node2 = node1.Next;
                for (int i = 1; i < this.listLength; i++)
                {
                    if (node1.CompareTo(node2) > 0)
                    {
                        var temp = node2.Value;
                        node2.Value = node1.Value;
                        node1.Value = temp;
                    }
                    node1 = node1.Next;
                    node2 = node2.Next;
                }
            }
        }

        public void InsertionSort()
        {
            while (!this.IsSorted())
            {
                var limit = this.listLength;
                for (int i = 1; i < limit; i++)
                {
                    // remove node at index i
                    var nodeValue = this.ElementAt(i);
                    this.RemoveNode(i);
                
                    // add node in sorted order
                    this.AddInOrder(nodeValue);
                }
            }
        }

        public SinglyLinkedListNode NodeAt(int index)
        {
            var thisNode = this.first_node;
            for (int i = 0; i < index; i++)
            {
                thisNode = thisNode.Next;
            }
            return thisNode;
        }


        //public void InsertionSort()
        //{
        //    // convert linked list to array
        //    var arrayToSort = new string[this.listLength];
        //    arrayToSort = this.ToArray();

        //    // sort the array
        //    for (int i = 1; i < this.listLength; i++)
        //    {
        //        var value = arrayToSort[i];
        //        var j = i - 1;
        //        while (j >= 0 && (arrayToSort[j].CompareTo(value) > 0))
        //        {
        //            arrayToSort[j + 1] = arrayToSort[j];
        //            j -= 1;
        //        }
        //        arrayToSort[j + 1] = value;
        //    }

        //    // convert array back to linked list
        //    SinglyLinkedList newList = new SinglyLinkedList();
        //    for (int i = 0; i < this.listLength; i++)
        //    {
        //        newList.AddLast(arrayToSort[i]);
        //    }
        //    this.first_node = newList.first_node;
        //}


        public static string[] Quicksort(string[] arrayToSort)
        {
            if (arrayToSort.Length > 1)
            {
                var limit = arrayToSort.Length;
                var less = new ArrayList();
                var equal = new ArrayList();
                var greater = new ArrayList();
                var arrayToReturn = new string[arrayToSort.Length];
                var pivot = arrayToSort[0];

                foreach (var item in arrayToSort)
                {
                    if (item.CompareTo(pivot) < 0) { less.Add(item); }
                    if (item.CompareTo(pivot) == 0) { equal.Add(item); }
                    if (item.CompareTo(pivot) > 0) { greater.Add(item); }
                }

                if (less.Count > 1) { Quicksort(less.ToArray() as string[]); }
                if (greater.Count > 1) { Quicksort(greater.ToArray() as string[]); }
                
                // concatenate less, equal, greater
                arrayToReturn = less.ToArray().Concat(equal.ToArray()).Concat(greater.ToArray()) as string[];
                return arrayToReturn;
            } else
            {
                return arrayToSort;
            }
            
        }

        //        function quicksort(array)
        //less, equal, greater:= three empty arrays
        //if length(array) > 1
        //    pivot:= select any element of array
        //    for each x in array
        //        if x < pivot then add x to less
        //        if x = pivot then add x to equal
        //        if x > pivot then add x to greater
        //    quicksort(less)
        //    quicksort(greater)
        //    array:= concatenate(less, equal, greater)

        //}

        public string[] ToArray()
        {
            var thisNode = this.first_node;
            string[] emptyArray = new string[] { };
            string[] myArray = new string[listLength];

            if (listLength == 0) { return emptyArray; }

            else
            {
                for (int i = 0; i < listLength; i++)
                {
                    myArray[i] = thisNode.Value;
                    thisNode = thisNode.Next;
                }
            }

            return myArray;
        }

        public override string ToString()
        {
            string leftBrace = "{", rightBrace = "}";
            string space = " ", quote = "\"", comma = ",";
            var thisNode = this.first_node;
            StringBuilder builder = new StringBuilder();

            if (listLength == 0)
            {
                return builder.Append(leftBrace).Append(space).Append(rightBrace).ToString();
            }
            if (listLength == 1)
            {
                builder.Append(leftBrace).Append(space).Append(quote);
                builder.Append(thisNode.Value);
                builder.Append(quote).Append(space).Append(rightBrace);
                return builder.ToString();
            }
            else
            {
                builder.Append(leftBrace).Append(space);
                while (!thisNode.IsLast())
                {
                    builder.Append(quote).Append(thisNode.Value);
                    builder.Append(quote).Append(comma).Append(space);
                    thisNode = thisNode.Next;
                }
                builder.Append(quote).Append(thisNode.Value).Append(quote);
                builder.Append(space).Append(rightBrace);
            }
            return builder.ToString();
        }
    }
}
