/// <summary>
/// Interface displaying sakura time. Fires an event whenever 
/// the sakura timer changes.
/// Useful for the sakura timer.
/// </summary>
public interface ISakuraSubject
{
    // Attach an observer to the subject.
    void Attach(ISakuraObserver observer);

    // Detach an observer from the subject.
    void Detach(ISakuraObserver observer);

    // Notify all observers about an event.
    void Notify();
}
