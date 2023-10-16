using System.Text;

namespace MiniGameTC {
    public class TCResult {
        private StringBuilder history = new StringBuilder();
        /// <summary> 결과의 상태 (예: 성공, 실패, 에러 등) </summary>
        public string Status { get; set; }

        /// <summary> 테스트 케이스 실행 시 발생한 예외나 에러 메시지 </summary>
        public string ErrorMessage { get; set; }
    }
}

