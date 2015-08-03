using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode first_node;
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
            } else
            {
                // find last node
                // set last_node.Next = new SinglyLinkedListNode(value)
                SinglyLinkedListNode currentNode = first_node;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new SinglyLinkedListNode(value);
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            int count = 0;
            if (this.First() == null)
            {
                return count;
            } else
            {
                SinglyLinkedListNode thisNode = this.first_node;
                count = 1;
                while (thisNode.Next != null)
                {
                    thisNode = thisNode.Next;
                    count++;
                }
                return count;
            }

            // Provide a second implementation
        }

        public string ElementAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == 0)
            {
                return this.First(); // placeholder
            }
            else
            {
                SinglyLinkedListNode thisNode = this.first_node;
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
            SinglyLinkedListNode thisNode = this.first_node;
            while (thisNode.Next != null)
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
            // if list is empty, return null
            if (this.first_node == null)
            {
                return null;
            }
            else
            {
                return this.LastNode().Value;
            }
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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            int count = this.Count();
            string returnString = "", leftBrace = "{", rightBrace = "}";
            string space = " ", quote = "\"", comma = ",";
            SinglyLinkedListNode thisNode = this.first_node;

            if (count == 0) // empty list
            {
                return leftBrace + space + rightBrace;
            }
            // loop through the list and build a string

            if (count == 1)
            {
                returnString += leftBrace + space + quote + thisNode.Value + quote + space + rightBrace;
            }
            else
            {
                returnString = leftBrace + space;
                while (thisNode.Next != null)
                {
                    returnString += quote + thisNode.Value + quote + comma + space;
                    thisNode = thisNode.Next;
                }
                returnString += quote + thisNode.Value + quote;
                returnString += space + rightBrace;
            }
            return returnString;
        }


    }
}
