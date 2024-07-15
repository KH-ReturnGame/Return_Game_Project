using System.Collections.Generic;
using Unity.VisualScripting;

public class StateManager<T> where T : class
{
    //자식 클래스를 가리킴
    private T _owner;
    //현재가지고 있는 모든 상태 리스트
    public List<State<T>> _currentState;
    //가지고 있을 수 있는 상태 개수
    private int _stateCount;
    //가지고 있을 수 있는 상태 종류
    private State<T>[] _states;

    //기본 변수 설정
    public void Setup(T owner, int stateCount, State<T>[] states)
    {
        _owner = owner;
        _states = states;
        _stateCount = stateCount;
        _currentState = new List<State<T>>(_stateCount);
    }

    //현재 상태중에 있는 상태를 찾고, 그 상태에서 매 프레임 수행해야하는 행동을 PlayerOwnedStates에서 구현된 Execute를 호출하여 수행하기
    public void Execute()
    {
        for (int i = 0; i < _stateCount; i++)
        {
            if (_currentState.Contains(_states[i]))
            {
                _currentState[_currentState.IndexOf(_states[i])].Execute(_owner);
            }
        }
    }
    
    //상태 추가 메소드
    public void AddState(State<T> newState)
    {
        if(_currentState.Contains(newState)) return;
        _currentState.Add(newState);
        _currentState[_currentState.IndexOf(newState)].Enter(_owner);
    }
    
    //상태 제거 메소드
    public void RemoveState(State<T> remState)
    {
        if(!_currentState.Contains(remState)) return;
        _currentState[_currentState.IndexOf(remState)].Exit(_owner);
        _currentState.Remove(remState);
    }
    
}
