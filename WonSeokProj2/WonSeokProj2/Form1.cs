using Timer = System.Windows.Forms.Timer;

namespace WonSeokProj2
{
    public partial class Form1 : Form
    {
        Timer _timer = new Timer(); // 아래 생성자보다 위 즉 현재위치에 변수를 선언해줘야 클래스 전체에서 참조가능 
        // 전역변수 라고 부르며 실무에서 전역변수는 전역변수임을 알려주기위해 이름앞에 _(언더바)붙힘
        // 변수명, 메서드명 바꿀땐 F2 누르면 클래스 전체에서 한번에 바꿀수있음 꿀팁
        // 모든 변수는 해당 변수가 선언된 부분의 대활호가 끝나는
        // 부분까지 사용할수있음
        int score = 0;
        int Score = 0;
        int count = 0;
  

        public Form1()
        {
            InitializeComponent();

            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(timer_Tick);
            /*1. 타이머로 500 간격마다 랜덤으로 만들어진 숫자랑 같은 버튼의 백컬러를 바꾼다.
              2. 버튼을 클릭하면 다시 원래 색으로 돌아온다.
              3. 버튼 눌렀을때 점수 계산해서 점수 넣기
              배열
              4. 기본배경을 누르면 게임오버(다시하겠습니까?) 시간멈추기
              5. 시작할때 0.5초였으면 시간이 길어질때마다 0.4, 0.3, 0.2로 간격줄이기
              */

            btnStart.Click += BtnStart_Click;
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            _timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            BtnSelectStart();

            if(_timer.Interval > 400)
            {
                _timer.Interval -= 20;
            }
            else
            {
                Victory();
            }    
            // 버튼이 한번 바뀔떄마다 _interval -20씩 
            // _timer를 전역변수로 생성해놨기때문에 이자리에서 호출해서 변경해줄수있음
            // 전역번수, 지역변수 중요함
            // 지역변수는 생성된 지역 (메서드, 이벤트) 에서만 호출할 수 있음

        }

        private void BtnSelectStart()
        {
            int RanNum = GetRandomNum();
            string RanNumText = GetRandomNum().ToString();

            Button btn = GetButton(RanNum);

            if (btn.BackColor == SystemColors.Control)
            {
                btn.BackColor = Color.Blue;
                if (CheckGameOver()) //전부 다 파란색이면 게임아웃
                {
                    GameOver();
                }
            }
            else
            {
                BtnSelectStart();// 자기 자신 다시호출
            }
        }

        private bool CheckGameOver()
        {
            for (int i = 0; i < 10; i++) // Btn0부터 Btn9까지 루프
            {
                Button btn = GetButton(i); // 버튼 객체 가져오기

                if (btn.BackColor == SystemColors.Control) // 버튼 색상 확인
                {
                    return false; // 기본 색상 버튼 발견 시 게임 오버 아님
                }
            }
            return true; // 모든 버튼 확인 후 파란색 버튼 없으면 게임 오버
        }

        private Button GetButton(int num)
        {
            switch (num)
            {
                case 0:
                    return Btn0;
                case 1:
                    return Btn1;
                case 2:
                    return Btn2;
                case 3:
                    return Btn3;
                case 4:
                    return Btn4;
                case 5:
                    return Btn5;
                case 6:
                    return Btn6;
                case 7:
                    return Btn7;
                case 8:
                    return Btn8;
                case 9:
                    return Btn9;
                default:
                    return null;
            }
        }

        private int GetRandomNum()
        {
            Random random = new Random();
            int RanNum = random.Next(0, 10);

            return RanNum;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.BackColor == Color.Blue)
            {
                ChangeBtnColor(button, SystemColors.Control);
                Score += AddScore(score);

                count--; //카운트 에러방지
                lblScore.Text = Score.ToString();
            }
            else
            {
                GameOver();
            }
        }
        private int AddScore(int score)
        {
            score += 1;
            lblScore.Text = score.ToString();
            return score;
        }
        private void ChangeBtnColor(Button btn, Color color)
        {
            btn.BackColor = color;
        }
        private void Clear()
        {
            _timer.Interval = 1000;
            score = 0;
            Score = 0;

            for (int i = 0; i < 10; i++)
            {
                Button button = GetButton(i);
                button.BackColor = SystemColors.Control;
            }
        }
        private void GameOver()
        {
            _timer.Stop();
            MessageBox.Show("게임오버");


            Clear();

            lblScore.Text = "0";

            MessageBox.Show("다시 하겠습니까?");
        }

        private void Victory()
        {
            _timer.Stop();
            MessageBox.Show("버텨 냈습니다,승리!");


            Clear();

            lblScore.Text = "0";

            MessageBox.Show("다시 하겠습니까?");
        }
    }
}