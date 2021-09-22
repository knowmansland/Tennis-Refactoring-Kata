using System;

namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        static private string[] point_desc = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame(string player1Name, string player2Name)
        {
            //assign players
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            /*

            TO DO: Check if game is over before assign more points
             
            */


            //abstract the player name
            if (this.player1Name == playerName)
                //point player 1
                m_score1 += 1;
            else if (this.player2Name == playerName)
                //point player 2
                m_score2 += 1;
            else 
                //throw error invalid player
                throw new Exception("Invalid playerName argument to WonPoint()");

        }

        public string GetScore()
        {
            string score = "";

            //Not a Tie
            if (m_score1 != m_score2)
            {

                //check for win and in array bounds
                if ((m_score1 >= 4 || m_score2 >= 4) && Math.Abs(m_score1 - m_score2) >= 2)
                {
                    score = m_score1 > m_score2 ? "Win for " + player1Name : "Win for " + player2Name;
                }
                //check advantage
                else if ((m_score1 + m_score2 >= 6) && Math.Abs(m_score1 - m_score2) == 1)
                {
                    score = m_score1 > m_score2 ? "Advantage " + player1Name : "Advantage " + player2Name;
                }
                //map score
                else
                {
                    score = point_desc[m_score1] + "-" + point_desc[m_score2];
                }

            }
            //Tie Score
            else
            {
                //Deuce or All
                score = (m_score1 + m_score2 >= 6) ? "Deuce" : point_desc[m_score1] + "-All";

            }

            return score;
        }
    }
}

