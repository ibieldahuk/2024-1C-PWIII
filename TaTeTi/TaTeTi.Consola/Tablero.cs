
public class Tablero
{
    private string[,] _tablero;

    public Tablero()
    {
        InicializarTablero();
    }

    internal void InicializarTablero()
    {
        _tablero = new string[3,3]; 
        GenerarOpciones();
    }

    public void GenerarOpciones()
    {
        int opcion = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_tablero[i, j] != "X" && _tablero[i, j] != "O")
                {
                    _tablero[i, j] = opcion.ToString();
                    opcion++;
                }
            }
        }
    }

    public string ObtenerPosicion(int fila, int columna)
    {
        return _tablero[fila, columna];
    }

    public bool ProcesarJugada(string opcion, string jugador)
    {
        bool valido = false;
        for (int i = 1; i <= 9; i++)
            if (opcion == i.ToString())
                valido = true;
        if (!valido)
            return false;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_tablero[i, j] == opcion)
                {
                    _tablero[i, j] = jugador;
                    return true;
                }
            }
        }

        return false;
    }

    public bool EstaFinalizado()
    {
        if (
            (_tablero[0, 0] == _tablero[0, 1] && _tablero[0, 0] == _tablero[0, 2] && _tablero[0, 0] != " ") ||
            (_tablero[1, 0] == _tablero[1, 1] && _tablero[1, 0] == _tablero[1, 2] && _tablero[1, 0] != " ") ||
            (_tablero[2, 0] == _tablero[2, 1] && _tablero[2, 0] == _tablero[2, 2] && _tablero[2, 0] != " ") ||
            (_tablero[0, 0] == _tablero[1, 0] && _tablero[0, 0] == _tablero[2, 0] && _tablero[0, 0] != " ") ||
            (_tablero[0, 1] == _tablero[1, 1] && _tablero[0, 1] == _tablero[2, 1] && _tablero[0, 1] != " ") ||
            (_tablero[0, 2] == _tablero[1, 2] && _tablero[0, 2] == _tablero[2, 2] && _tablero[0, 2] != " ") ||
            (_tablero[0, 0] == _tablero[1, 1] && _tablero[0, 0] == _tablero[2, 2] && _tablero[0, 0] != " ") ||
            (_tablero[0, 2] == _tablero[1, 1] && _tablero[0, 2] == _tablero[2, 0] && _tablero[0, 2] != " ")
            )
        {
            return true;
        }

        if (
            (_tablero[0, 0] == "X" || _tablero[0, 0] == "O") &&
            (_tablero[0, 1] == "X" || _tablero[0, 1] == "O") &&
            (_tablero[0, 2] == "X" || _tablero[0, 2] == "O") &&
            (_tablero[1, 0] == "X" || _tablero[1, 0] == "O") &&
            (_tablero[1, 1] == "X" || _tablero[1, 1] == "O") &&
            (_tablero[1, 2] == "X" || _tablero[1, 2] == "O") &&
            (_tablero[2, 0] == "X" || _tablero[2, 0] == "O") &&
            (_tablero[2, 1] == "X" || _tablero[2, 1] == "O") &&
            (_tablero[2, 2] == "X" || _tablero[2, 2] == "O")
            )
        {
            return true;
        }

        return false;
    }
}
