/* ========================================================
 *	类名称：GameStateComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-27 18:10:44
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum GameState
{
    Ready,
    Start,
    Running,
    GameOver,
}
[Game, Event(EventTarget.Self), Unique]
public class GameStateComponent : IComponent
{
    public GameState state;
}