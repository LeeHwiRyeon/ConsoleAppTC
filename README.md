
## 소개
**ConsoleAppTester**는 콘솔 환경에서 게임의 동작을 검증하기 위해 특별히 제작된 프로젝트입니다. 사용자는 직접 작성한 테스트 시나리오를 통해 게임이 정상적으로 작동하는지, 의도한대로 결과를 내놓는지 확인할 수 있습니다.
사용자는 다양한 시나리오를 정의하고 이를 자동 실행하여 어플리케이션의 동작을 검증할 수 있습니다.
결과는 자동으로 리포트 형식으로 저장되며, 원하는 경우 Git과 연동하여 자동으로 저장 및 공유할 수 있습니다.

## 주요 기능
1. **콘솔 어플리케이션 테스트 지원**: 콘솔 기반의 다양한 어플리케이션과 게임의 시나리오를 추가하고 관리합니다.
2. **리포트 자동 생성**: 테스트 실행 결과를 자동으로 리포트로 저장합니다.
3. **Git 통합**: 테스트 리포트를 Git에 자동 커밋 및 푸시하는 기능을 제공합니다.

## 사용 방법
### 1. 테스트 시나리오 추가하기
- **MiniGameTester** 디렉토리에서 새로운 테스트 시나리오 파일을 생성하거나 기존의 파일을 수정합니다.
- 시나리오를 정의할 때 `ITestScenario` 인터페이스를 구현합니다. 이 인터페이스는 테스트 시나리오의 실행과 관련된 메서드들을 포함합니다.

### 2. 테스트 시나리오 실행하기
- 메인 애플리케이션에서 `ConsoleAppTester` 클래스의 인스턴스를 생성합니다.
  ```csharp
  var tester = new ConsoleAppTester();
  tester.RunAllTests();
  ```
### 3. 테스트 결과 확인하기
- 테스트가 완료되면, **Reporter** 클래스를 사용하여 결과를 확인합니다.
- **PrintAllReports()** 메서드를 사용해 콘솔에 모든 테스트 결과를 출력합니다.
  ```csharp
  var reporter = new Reporter();
  reporter.PrintAllReports();
  ```
- GenerateReport() 메서드를 사용해 테스트 결과를 파일로 저장합니다. 저장 경로와 파일명은 메서드 내에서 설정할 수 있습니다. 
  ```csharp
  string reportPath = reporter.GenerateReport();
  ```
### 4. Git과 연동하기
- 결과 리포트를 Git 저장소에 커밋하거나 푸시하려면, GitCommand 클래스를 사용합니다.
  ```csharp
  var git = new GitCommand();
  git.CommitAndPush(reportPath, "Add new test report");
  ```
### 5. Slack 알림 사용법

`SlackNotifier` 클래스를 사용하여 특정 이벤트나 테스트 결과를 Slack 채널에 알림을 보낼 수 있습니다.

#### 설정 방법
1. Slack에서 [이 링크](https://api.slack.com/apps/A046YFXPBFX/incoming-webhooks?)를 참조하여 새로운 Incoming Webhook을 설정하세요.
2. 생성된 Webhook URL을 `SlackNotifier.webhookUrl`에 할당하세요.

#### 사용 방법
- 특정 시점에서 Slack에 메시지를 보내려면 다음 코드를 사용하세요:
  ```csharp
  MiniGameTester.SlackNotifier.SendMessage("Your message here");
  ```

## 개발자를 위한 참고 사항
- 테스트 시나리오를 추가하려면 `ITestScenario` 인터페이스를 구현하세요.
- 리포트의 형식이나 저장 경로와 같은 설정을 변경하려면 **Reporter** 클래스 내부의 관련 메서드나 변수를 수정하면 됩니다.

