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

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
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

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            return listLength;
        }

        public string ElementAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var thisNode = this.first_node;
                int nodeIndex = 0;
                while (nodeIndex < index)
                {
                    thisNode = thisNode.Next;
                    nodeIndex++;
                }
                return thisNode.Value;
            }
        }

        private SinglyLinkedListNode LastNode()
        {
            var thisNode = this.first_node;
            while (!thisNode.IsLast())
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
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            return (this.first_node == null) ? null : this.LastNode().Value;
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            var thisNode = this.first_node;
            string[] emptyArray = new string[] { };
            string[] myArray = new string[listLength];

            if (listLength == 0)
            {
                return emptyArray;
            }
            else
            {
                int i = 0;
                while (i < listLength)
                {
                    myArray[i++] = thisNode.Value;
                    thisNode = thisNode.Next;
                }
            }

            return myArray;
        }

        public override string ToString()
        {

            string leftBrace = "{", rightBrace = "}";
            string space = " ", quote = "\"", comma = ",";
            SinglyLinkedListNode thisNode = this.first_node;
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
