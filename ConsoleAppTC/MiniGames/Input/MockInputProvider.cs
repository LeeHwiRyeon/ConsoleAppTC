using MiniGames;
using System;
using System.Collections.Generic;

public class MockInputProvider : IInputProvider {
    private Queue<string> _inputs = new Queue<string>();

    public string GetInput()
    {
        if (_inputs.Count == 0)
            throw new InvalidOperationException("No more inputs available in MockInputProvider.");
        return _inputs.Dequeue();
    }

    public void SetInputs(params string[] inputs)
    {
        foreach (var input in inputs) {
            _inputs.Enqueue(input);
        }
    }

    public void Reset()
    {
        _inputs.Clear();
    }
}