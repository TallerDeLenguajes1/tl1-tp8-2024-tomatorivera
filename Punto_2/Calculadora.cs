namespace EspacioCalculadora
{
    ///<summary>
    ///Clase encargada de ejecutar las operaciones y almacenar los resultados de la calculadora
    ///</summary>
    public class Calculadora {
        private double resultado;

        public Calculadora() {
            resultado = 0;
        }

        public double Resultado {
            get {
                return resultado;
            }
        }

        public void sumar(double termino) {
            resultado += termino;
        }

        public void restar(double termino) {
            resultado -= termino;
        }

        public void multiplicar(double termino) {
            resultado *= termino;
        }

        public void dividir(double termino) {
            resultado /= termino;
        }

        public void limpiar() {
            resultado = 0;
        }
    }

    ///<summary>
    ///Enumeracion que almacena los tipos de operacion que puede realizar la calculadora
    ///</summary>
    public enum TipoOperacion {
        SUMA,
        RESTA,
        MULTIPLICACION,
        DIVISION,
        LIMPIAR
    }

    ///<summary>
    ///Objeto que almacena información de cada una de las operaciones de la calculadora
    ///</summary>
    public class Operacion {
        
        private double resultadoAnterior;
        private double nuevoValor;
        private TipoOperacion operacion;

        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion) {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
            this.operacion = operacion;
        }

        public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
        public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
        public TipoOperacion tipoOperacion { get => operacion; set => operacion = value; }

        public override string ToString() {
            return $"Operacion {operacion} - Resultado anterior: {resultadoAnterior} - Nuevo valor: {nuevoValor}";
        }
    }

}