using System.Threading;

namespace SmartHomeCommon.StateMachine
{
    public interface IStateMachine
    {
        void Handle(Context context)
    }
}