/// <summary>
/// This queue is circular. When people are added via AddPerson, they go to the 
/// back of the queue (FIFO). GetNextPerson dequeues the next person and re-enqueues 
/// them if they have turns left (0 or less means infinite turns).
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns > 0)
        {
            person.Turns--; // decrement finite turns
            if (person.Turns > 0)
                _people.Enqueue(person);
        }
        else
        {
            // Infinite turns: re-enqueue without changing turns
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
