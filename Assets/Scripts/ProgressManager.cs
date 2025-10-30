using UnityEngine;
using UnityEngine.Events;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private int maxProgress = 5;
    public UnityEvent<int> OnProgressChanged;
    public UnityEvent OnProgressReset;
    public UnityEvent OnMaxProgressReached;
    private int currentProgress = 0;

    void Start()
    {
        InitializeClock();
    }

    public void CorrectGuess()
    {
        currentProgress++;
        Debug.Log($"correct! progress: {currentProgress}");
        
        OnProgressChanged?.Invoke(currentProgress);
        //UpdateClock();
        
        if (currentProgress >= maxProgress)
        {
            Debug.Log("max progress reached");
            OnMaxProgressReached?.Invoke();
        }
    }

    public void IncorrectGuess()
    {
        Debug.Log($"incorrect! progress reset from {currentProgress} to 0");
        currentProgress = 0;
        
        OnProgressReset?.Invoke();
        OnProgressChanged?.Invoke(currentProgress);
    }

    private void InitializeClock()
    {
        
    }

    private void UpdateClock()
    {
        Debug.Log($"clock updated to: {GetTimeString()}");
    }

    private string GetTimeString()
    {
        if (currentProgress == 0) return "Midnight";
        return $"{currentProgress}am";
    }

    public void TestCorrectGuess() => CorrectGuess();

    public void TestIncorrectGuess() => IncorrectGuess();

    public int GetCurrentProgress()
    {
        return currentProgress;
    }
    public int GetMaxProgress()
    {
        return maxProgress;
    }
    public bool IsAtMaxProgress()
    {
        if (currentProgress >= maxProgress) {
            return true;
        }
        return false;
    }
}