using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

/// <summary>
/// Unit tests for the PriorityQueue class.
/// These tests verify correct dequeue behavior based on priority,
/// FIFO ordering for equal priorities, and proper exception handling.
/// </summary>
[TestClass]
public class PriorityQueueTests
{
    /// <summary>
    /// Scenario:
    /// Enqueue three items with different priorities.
    ///
    /// Expected Result:
    /// Items should be dequeued in descending priority order
    /// (highest priority value first).
    ///
    /// Test Result:
    /// Passes if items are returned as: High → Medium → Low.
    /// </summary>
    [TestMethod]
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    /// <summary>
    /// Scenario:
    /// Enqueue multiple items with the same priority.
    ///
    /// Expected Result:
    /// Items with equal priority should be dequeued
    /// in the same order they were enqueued (FIFO behavior).
    ///
    /// Test Result:
    /// Passes if items are returned in insertion order.
    /// </summary>
    [TestMethod]
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

    /// <summary>
    /// Scenario:
    /// Attempt to dequeue from an empty priority queue.
    ///
    /// Expected Result:
    /// An InvalidOperationException should be thrown
    /// with the message "The queue is empty."
    ///
    /// Test Result:
    /// Passes if the correct exception type and message are produced.
    /// </summary>
    [TestMethod]
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

    /// <summary>
    /// Scenario:
    /// Enqueue a mix of items with varying and duplicate priorities.
    ///
    /// Expected Result:
    /// - Items with higher priority are dequeued first.
    /// - Items with the same priority maintain FIFO order.
    ///
    /// Test Result:
    /// Passes if dequeue order matches expected priority and insertion rules.
    /// </summary>
    [TestMethod]
    public void TestPriorityQueue_Mixed()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 10);
        pq.Enqueue("E", 1);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("E", pq.Dequeue());
    }
}
