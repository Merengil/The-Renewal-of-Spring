/// <summary>
/// Triggers an event whenever a tree is blooming
/// </summary>
public interface IBloomingTreeSubject
{
    // Attach an observer to the subject.
    void Attach(IBloomingTreeObserver observer);

    // Detach an observer from the subject.
    void Detach(IBloomingTreeObserver observer);

    // Notify all observers about an event.
    void NotifyBloomingTree();
}
