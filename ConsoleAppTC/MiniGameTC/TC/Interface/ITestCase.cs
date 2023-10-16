using System;
using System.Xml;

namespace MiniGameTC {
    public interface ITestCase {
        TCResult Result { get; }
        void OnInitialize();
        TCResult OnUpdate();
        void OnClose();
    }
}