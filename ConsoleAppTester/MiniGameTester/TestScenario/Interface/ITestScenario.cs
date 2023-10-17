using System;
using System.Xml;

namespace MiniGameTester {
    public interface ITestScenario {
        TestScenarioReport Report { get; }
        void OnInitialize();
        TestScenarioReport ExecuteScenario();
        void OnFinalize();
    }
}