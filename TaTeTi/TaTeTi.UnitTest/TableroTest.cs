
public class TableroTest
{
    [Fact]
    public void cuandoIngresoUnaJugadaValidaRetornaTrue()
    {
        // preparación - arrange
        var tablero = new Tablero();
        string jugadaValida = "1";
        string jugador = "X";
        // ejecución - act
        bool resultado = tablero.ProcesarJugada(jugadaValida, jugador);
        // verificación - assert
        Assert.True(resultado);
    }

    [Fact]
    public void cuandoIngresoUnaJugadaNoValidaRetornaFalse()
    {
        // preparación - arrange
        var tablero = new Tablero();
        string jugadaNoValida = "X";
        string jugador = "X";
        // ejecución - act
        bool resultado = tablero.ProcesarJugada(jugadaNoValida, jugador);
        // verificación - assert
        Assert.False(resultado);
    }
}
