//状态机
public abstract class EnemyBaseState //状态基类
{
    public abstract void EnterState(Enemy enemy); //进入这个状态时
    public abstract void OnUpdate(Enemy enemy);  //在这个状态中逐帧运行  状态中进行的动作
}
