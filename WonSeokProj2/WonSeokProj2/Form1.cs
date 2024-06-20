using Timer = System.Windows.Forms.Timer;

namespace WonSeokProj2
{
    public partial class Form1 : Form
    {
        Timer _timer = new Timer(); // �Ʒ� �����ں��� �� �� ������ġ�� ������ ��������� Ŭ���� ��ü���� �������� 
        // �������� ��� �θ��� �ǹ����� ���������� ������������ �˷��ֱ����� �̸��տ� _(�����)����
        // ������, �޼���� �ٲܶ� F2 ������ Ŭ���� ��ü���� �ѹ��� �ٲܼ����� ����
        // ��� ������ �ش� ������ ����� �κ��� ��Ȱȣ�� ������
        // �κб��� ����Ҽ�����
        int score = 0;
        int Score = 0;
        int count = 0;
  

        public Form1()
        {
            InitializeComponent();

            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(timer_Tick);
            /*1. Ÿ�̸ӷ� 500 ���ݸ��� �������� ������� ���ڶ� ���� ��ư�� ���÷��� �ٲ۴�.
              2. ��ư�� Ŭ���ϸ� �ٽ� ���� ������ ���ƿ´�.
              3. ��ư �������� ���� ����ؼ� ���� �ֱ�
              �迭
              4. �⺻����� ������ ���ӿ���(�ٽ��ϰڽ��ϱ�?) �ð����߱�
              5. �����Ҷ� 0.5�ʿ����� �ð��� ����������� 0.4, 0.3, 0.2�� �������̱�
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
            // ��ư�� �ѹ� �ٲ������� _interval -20�� 
            // _timer�� ���������� �����س��⶧���� ���ڸ����� ȣ���ؼ� �������ټ�����
            // ��������, �������� �߿���
            // ���������� ������ ���� (�޼���, �̺�Ʈ) ������ ȣ���� �� ����

        }

        private void BtnSelectStart()
        {
            int RanNum = GetRandomNum();
            string RanNumText = GetRandomNum().ToString();

            Button btn = GetButton(RanNum);

            if (btn.BackColor == SystemColors.Control)
            {
                btn.BackColor = Color.Blue;
                if (CheckGameOver()) //���� �� �Ķ����̸� ���Ӿƿ�
                {
                    GameOver();
                }
            }
            else
            {
                BtnSelectStart();// �ڱ� �ڽ� �ٽ�ȣ��
            }
        }

        private bool CheckGameOver()
        {
            for (int i = 0; i < 10; i++) // Btn0���� Btn9���� ����
            {
                Button btn = GetButton(i); // ��ư ��ü ��������

                if (btn.BackColor == SystemColors.Control) // ��ư ���� Ȯ��
                {
                    return false; // �⺻ ���� ��ư �߰� �� ���� ���� �ƴ�
                }
            }
            return true; // ��� ��ư Ȯ�� �� �Ķ��� ��ư ������ ���� ����
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

                count--; //ī��Ʈ ��������
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
            MessageBox.Show("���ӿ���");


            Clear();

            lblScore.Text = "0";

            MessageBox.Show("�ٽ� �ϰڽ��ϱ�?");
        }

        private void Victory()
        {
            _timer.Stop();
            MessageBox.Show("���� �½��ϴ�,�¸�!");


            Clear();

            lblScore.Text = "0";

            MessageBox.Show("�ٽ� �ϰڽ��ϱ�?");
        }
    }
}