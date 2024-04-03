
public class TableroTest
{
    [Fact]
    public void cuandoIngresoUnaJugadaValidaRetornaTrue()
    {
        // preparaci�n - arrange
        var tablero = new Tablero();
        string jugadaValida = "1";
        string jugador = "X";
        // ejecuci�n - act
        bool resultado = tablero.ProcesarJugada(jugadaValida, jugador);
        // verificaci�n - assert
        Assert.True(resultado);
    }

    [Fact]
    public void cuandoIngresoUnaJugadaNoValidaRetornaFalse()
    {
        // preparaci�n - arrange
        var tablero = new Tablero();
        string jugadaNoValida = "X";
        string jugador = "X";
        // ejecuci�n - act
        bool resultado = tablero.ProcesarJugada(jugadaNoValida, jugador);
        // verificaci�n - assert
        Assert.False(resultado);
    }
}
