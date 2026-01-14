using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several items with different priorities and dequeue them all
    // Expected Result: Items are returned in order from highest to lowest priority
    // Defect(s) Found: Original test not implemented
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        // High priority first
        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority, check FIFO order
    // Expected Result: Items with same priority are dequeued in order they were added
    // Defect(s) Found: Original test not implemented
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);
        pq.Enqueue("Third", 5);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items, then dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Original test not implemented
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type {e.GetType()}: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Mix of priorities and same-priority items
    // Expected Result: Highest priority first, same-priority items FIFO
    // Defect(s) Found: Original test not implemented
    public void TestPriorityQueue_Mixed()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 10);
        pq.Enqueue("E", 1);

        Assert.AreEqual("B", pq.Dequeue()); // highest priority, first inserted
        Assert.AreEqual("D", pq.Dequeue()); // same priority as B, inserted later
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("E", pq.Dequeue());
    }
}
