using System;
using System.Collections.Generic;

namespace BookVerse
{
    public class Tela
    {
        private int largura;
        private int altura;
        private int linhaMensagem;
        private int colunaIniMensagem;
        private int colunaFinMensagem;
        private ConsoleColor corFundo;
        private ConsoleColor corTexto;

        public Tela(int largura, int altura, ConsoleColor fundo, ConsoleColor texto)
        {
            this.largura = largura;
            this.altura = altura;
            this.corFundo = fundo;
            this.corTexto = texto;
            this.definirMedidasMensagem();
        }
        
        public Tela()
        {
            this.largura = 80;
            this.altura = 25;
            this.corFundo = ConsoleColor.Black;
            this.corTexto = ConsoleColor.White;
            this.definirMedidasMensagem();
        }

        private void definirMedidasMensagem()
        {
            this.linhaMensagem = this.altura - 1;
            this.colunaIniMensagem = 1;
            this.colunaFinMensagem = this.largura - 1;
        }

        public void prepararTela(string titulo)
        {
            Console.ForegroundColor = corTexto;
            Console.BackgroundColor = corFundo;
            Console.Clear();
            this.desenharMoldura(0, 0, this.largura, this.altura);
            this.desenharMoldura(0, 0, this.largura, 2);
            this.desenharMoldura(0, this.altura - 2, this.largura, this.altura);
            this.centralizar(titulo, 1, 0, this.largura);
        }

        public void limparArea(int ci, int li, int cf, int lf)
        {
            for (int x = ci; x <= cf; x++)
            {
                for (int y = li; y <= lf; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }
        }

        public void desenharMoldura(int colIni, int linIni, int colFin, int linFin)
        {
            this.limparArea(colIni, linIni, colFin, linFin);

            for (int x = colIni; x <= colFin; x++)
            {
                Console.SetCursorPosition(x, linIni);
                Console.Write("-");
                Console.SetCursorPosition(x, linFin);
                Console.Write("-");
            }
            for (int y = linIni; y <= linFin; y++)
            {
                Console.SetCursorPosition(colIni, y);
                Console.Write("|");
                Console.SetCursorPosition(colFin, y);
                Console.Write("|");
            }
            Console.SetCursorPosition(colIni, linIni); Console.Write("+");
            Console.SetCursorPosition(colIni, linFin); Console.Write("+");
            Console.SetCursorPosition(colFin, linIni); Console.Write("+");
            Console.SetCursorPosition(colFin, linFin); Console.Write("+");
        }
        
        public void centralizar(string texto, int lin = 0, int colIni = 0, int colFin = 0)
        {
            if (lin == 0) lin = this.linhaMensagem;
            if (colIni == 0) colIni = this.colunaIniMensagem;
            if (colFin == 0) colFin = this.colunaFinMensagem;

            this.limparArea(colIni + 1, lin, colFin - 1, lin);
            int colTexto = ((colFin - colIni - texto.Length) / 2) + colIni;
            Console.SetCursorPosition(colTexto, lin);
            Console.Write(texto);
        }

        public string mostrarMenu(List<string> opcoes, int colIni, int linIni)
        {
            string opcaoEscolhida = "";
            int largura = 0;
            foreach (string opcao in opcoes)
            {
                if (opcao.Length > largura)
                {
                    largura = opcao.Length;
                }
            }

            int colFin = colIni + largura + 3;
            int linFin = linIni + opcoes.Count + 1;
            this.desenharMoldura(colIni-1, linIni-1, colFin, linFin);
            
            for (int i = 0; i < opcoes.Count; i++)
            {
                Console.SetCursorPosition(colIni, linIni);
                Console.WriteLine(opcoes[i]);
                linIni++;
            }
            
            Console.SetCursorPosition(colIni, linIni);
            Console.Write("Opção: ");
            opcaoEscolhida = Console.ReadLine();
            
            return opcaoEscolhida;
        }
    }
}