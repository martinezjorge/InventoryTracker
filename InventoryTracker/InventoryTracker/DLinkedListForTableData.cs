using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker
{
    public class DLinkedListForTableData
    {
        internal class DoublyLinkedListNode
        {
            internal String itemName;
            internal int actualAmount;
            internal int idealAmount;
            internal DoublyLinkedListNode prev;
            internal DoublyLinkedListNode next;

            public DoublyLinkedListNode(String iName, int aAmount, int iAmount)
            {
                itemName = iName;
                actualAmount = aAmount;
                idealAmount = iAmount;
                prev = null;
                next = null;
            }
        }

        internal class DoublyLinkedList
        {
            internal DoublyLinkedListNode head;
        }

        internal void InsertAtFront(DoublyLinkedList doublyLinkedList, String iName, int aAmount, int iAmount)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(iName, aAmount, iAmount);
            newNode.next = doublyLinkedList.head;
            newNode.prev = null;
            if (doublyLinkedList.head != null)
            {
                doublyLinkedList.head.prev = newNode;
            }
            doublyLinkedList.head = newNode;
        }

        internal void InsertAtEnd(DoublyLinkedList doublyLinkedList, String iName, int aAmount, int iAmount)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(iName, aAmount, iAmount);
            if (doublyLinkedList.head == null)
            {
                newNode.prev = null;
                doublyLinkedList.head = newNode;
                return;
            }
            DoublyLinkedListNode lastNode = GetLastNode(doublyLinkedList);
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }

        internal void InsertAfterGivenNode(DoublyLinkedListNode previousNode, String iName, int aAmount, int iAmount)
        {
            if (previousNode == null)
            {
                Console.WriteLine("Invalid previous node");
                return;
            }
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(iName, aAmount, iAmount);
            newNode.next = previousNode.next;
            previousNode.next = newNode;
            newNode.prev = previousNode;
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
        }

        internal void DeleteNodeByItemName(DoublyLinkedList doublyLinkedList, String iName)
        {
            DoublyLinkedListNode temp = doublyLinkedList.head;
            if (temp != null && temp.itemName == iName)
            {
                doublyLinkedList.head = temp.next;
                doublyLinkedList.head.prev = null;
                return;
            }
            while (temp != null && temp.itemName != iName)
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }

        internal DoublyLinkedListNode GetLastNode(DoublyLinkedList doublyLinkedList)
        {
            DoublyLinkedListNode temp = doublyLinkedList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

    }
}
