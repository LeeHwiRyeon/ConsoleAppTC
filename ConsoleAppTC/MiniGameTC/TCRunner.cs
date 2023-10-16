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
                .Where(type => type.GetInterfaces().Contains(typeof(ITestCase))
                                && type.IsDefined(typeof(IgnoreTestCaseAttribute), inherit: false) == false)
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

            int successCount = 0;
            int failureCount = 0;
            foreach (var tc in m_testCases) {
                var result = RunTestCase(tc);
                if (result.Status == "Success") {
                    successCount++;
                } else {
                    failureCount++;
                }
            }

            var msg = $"테스트 완료: 성공({successCount}) 실패({failureCount})";
            SlackNotifier.SendMessage(msg);
            Console.WriteLine(msg);
        }

        private TCResult RunTestCase(ITestCase tc)
        {
            tc.OnInitialize();
            var result = tc.OnUpdate();
            tc.OnClose();
            return result;
        }
    }
}
