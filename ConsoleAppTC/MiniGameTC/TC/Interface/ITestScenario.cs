using System;
using System.Xml;

namespace MiniGameTC {
    public interface ITestScenario {
        TestScenarioReport Report { get; }
        void OnInitialize();
        TestScenarioReport ExecuteScenario();
        void OnFinalize();
    }
}