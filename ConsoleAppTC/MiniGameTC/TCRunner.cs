using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MiniGameTC {
    public class TCRunner {
        private List<ITestCase> m_testCases = new List<ITestCase>();

        public void Init()
        {
            var testCaseTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(ITestCase)))
                .ToArray();

            m_testCases.Clear();
            foreach (var type in testCaseTypes) {
                if (Activator.CreateInstance(type) is ITestCase testCase) {
                    m_testCases.Add(testCase);
                }
            }
        }

        public void RunAllTests()
        {
            if (m_testCases == null || m_testCases.Count == 0) {
                Console.WriteLine("No test cases found!");
                return;
            }

            foreach (var tc in m_testCases) {
                RunTestCase(tc);
            }

            SlackNotifier.SendMessage($"테스트 완료: 성공({0}) 실패({0})");
        }

        private void RunTestCase(ITestCase tc)
        {
            tc.OnInitialize();
            var result = tc.OnUpdate();
            //if (result == Formatting.Indented) { // 예시로 결과가 Formatting.Indented라면 성공으로 판단
            //    Console.WriteLine("Test Case Passed!");
            //} else {
            //    Console.WriteLine("Test Case Failed!");
            //}
            tc.OnClose();
        }


    }
}
