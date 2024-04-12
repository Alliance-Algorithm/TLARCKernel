
using System.Runtime.Serialization;

namespace AllianceDM
{
    public interface IComponent
    {
        /// <summary>
        /// 起始调用
        /// </summary>
        public virtual void Awake() { }
        /// <summary>
        /// 状态更新调用
        /// </summary>
        public virtual void Update() { }
        /// <summary>
        /// 信息传递
        /// </summary>
        public virtual void Echo() { }
    }

    public class Component(uint uuid, uint revid) : IComponent
    {
        uint _uuid = uuid;
        uint _revUid = revid;

        public uint ID => _uuid;
        public uint RecieveID => _revUid;

        /// <summary>
        /// 起始调用
        /// </summary>
        public virtual void Awake() { }
        /// <summary>
        /// 状态更新调用
        /// </summary>
        public virtual void Update() { }
        /// <summary>
        /// 信息传递
        /// </summary>
        public virtual void Echo() { }
    }
}