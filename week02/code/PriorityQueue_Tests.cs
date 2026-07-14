using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and remove them in order.
    // Expected Result: The highest-priority item is removed first, then the next highest.
    // Defect(s) Found: The implementation did not remove the selected item from the queue and did not consistently choose the highest-priority element.
    public void TestPriorityQueue_HigherPriorityIsDequeuedFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alpha", 1);
        priorityQueue.Enqueue("Beta", 5);
        priorityQueue.Enqueue("Gamma", 3);

        Assert.AreEqual("Beta", priorityQueue.Dequeue());
        Assert.AreEqual("Gamma", priorityQueue.Dequeue());
        Assert.AreEqual("Alpha", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same highest priority.
    // Expected Result: The older item is removed first to preserve FIFO ordering.
    // Defect(s) Found: The implementation used an incorrect comparison and did not preserve FIFO behavior for equal priorities.
    public void TestPriorityQueue_SamePriorityUsesFIFOOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 4);
        priorityQueue.Enqueue("Second", 4);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with the expected message.
    // Defect(s) Found: The empty-queue case should be handled explicitly, and the implementation was already intended to do so.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
