
internal class JuegoTaTeTi
{
    private string _input;
    private bool _turnoX;
    private string _jugador;
    private bool _error;

    private Tablero _tablero;

    private IConsolaInput _consolaInput;
    private IConsolaOutput _consolaOutput;

    public JuegoTaTeTi(IConsolaInput consolaInput, IConsolaOutput consolaOutput)
    {
        _tablero = new Tablero();
        _turnoX = true;

        _consolaInput = consolaInput;
        _consolaOutput = consolaOutput;
    }

    public void Jugar()
    {
        // loop del juego:
        // comprobar que el juego no esté ganado ni abandonado
        // definir a quién le toca
        // llenar el tablero con la opciones e imprimirlo
        // tomar la opción del jugador y procesarla acordemente
        // limpiar la consola en preparación para la próxima iteración

        while (!_tablero.EstaFinalizado() && _input != ":q!")
        {
            _jugador = (_turnoX) ? "X" : "O";
            _tablero.GenerarOpciones();
            ImprimirTablero();

            _input = _consolaInput.ReadLine();
            _error = !_tablero.ProcesarJugada(_input, _jugador);
            if (!_error)
            {
                _turnoX = !_turnoX;
            }
            _consolaOutput.Clear();
        }

        if (_input != ":q!")
        {
            ImprimirVictoria();
        } else
        {
            ImprimirAbandono();
        }
    }

    internal void ImprimirTablero()
    {
        _consolaOutput.WriteLine("+++++++++++++++++++++++++++++++++");
        _consolaOutput.WriteLine("++++++++++++ T4-T3-T1 +++++++++++");
        _consolaOutput.WriteLine("+++++++++++++++++++++++++++++++++");
        _consolaOutput.WriteLine("");
        if (_error)
        {
            _consolaOutput.WriteLine("ERROR: INGRESE UNA OPCIÓN VÁLIDA.");
            _consolaOutput.WriteLine("");
        }
        _consolaOutput.WriteLine("        Es el turno de: " + _jugador);
        string linea;
        for (int i = 0; i < 3; i++)
        {
            linea = "          | ";
            for (int j = 0; j < 3; j++)
            {
                linea += _tablero.ObtenerPosicion(i, j) + " | ";
            }
            _consolaOutput.WriteLine(linea);
        }
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+++++++++++++++++++++++++++++++++");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("Para abandonar ingrese \":q!\"");
        _consolaOutput.WriteLine("");
        _consolaOutput.Write("Ingrese la opción que desee: ");
    }

    internal void ImprimirVictoria()
    {
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+*+*+*+*+ VICTORIA DE " + _jugador + " *+*+*+*+*");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
        _consolaOutput.WriteLine("");
        _consolaOutput.WriteLine("+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+");
    }

    internal void ImprimirAbandono()
    {
        _consolaOutput.WriteLine("\n\n\n\n\n");
        _consolaOutput.WriteLine(_jugador + " abandonó la partida... ¬¬");
        _consolaOutput.WriteLine("\n\n\n\n\n");
    }
}

    /*
    internal void GenerarTablero()
    {
        _tablero = new string[3, 3]
        {
            {" ", " ", " "},
            {" ", " ", " "},
            {" ", " ", " "}
        };
    }
    
    internal void GenerarOpciones()
    {
        int opcion = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_tablero[i, j] != "X" && _tablero[i,j] != "O")
                {
                    _tablero[i, j] = opcion.ToString();
                    opcion++;
                }
            }
        }
    }

    internal bool EstaFinalizado()
    {
        if (
            (_tablero[0,0] == _tablero[0,1] && _tablero[0,0] == _tablero[0,2] && _tablero[0,0] != " ") ||
            (_tablero[1,0] == _tablero[1,1] && _tablero[1,0] == _tablero[1,2] && _tablero[1,0] != " ") ||
            (_tablero[2,0] == _tablero[2,1] && _tablero[2,0] == _tablero[2,2] && _tablero[2,0] != " ") ||
            (_tablero[0,0] == _tablero[1,0] && _tablero[0,0] == _tablero[2,0] && _tablero[0,0] != " ") ||
            (_tablero[0,1] == _tablero[1,1] && _tablero[0,1] == _tablero[2,1] && _tablero[0,1] != " ") ||
            (_tablero[0,2] == _tablero[1,2] && _tablero[0,2] == _tablero[2,2] && _tablero[0,2] != " ") ||
            (_tablero[0,0] == _tablero[1,1] && _tablero[0,0] == _tablero[2,2] && _tablero[0,0] != " ") ||
            (_tablero[0,2] == _tablero[1,1] && _tablero[0,2] == _tablero[2,0] && _tablero[0,2] != " ")
            )
        {
            return true;
        }

        return false;
    }

    internal bool ProcesarOpcion(string opcion, string jugador)
    {
        if (opcion == "X" || opcion == "O")
        {
            return false;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_tablero[i,j] == opcion)
                {
                    _tablero[i, j] = jugador;
                    return true;
                }
            }
        }

        return false;
    }
    */