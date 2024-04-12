using System;

namespace AllianceDM.IO
{
#pragma warning disable CS9113 // 参数未读。
    internal sealed class IONode(uint a = 0, uint b = 0) : Component(0, 0)
#pragma warning restore CS9113 // 参数未读。
    {
        public override void Awake()
        {
            Console.WriteLine("AllianceDM.IO IOManager");
        }

    }
}