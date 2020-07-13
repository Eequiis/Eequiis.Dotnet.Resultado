namespace Eequiis.Dotnet.Resultado
{
	/// <summary>
	/// Resultado exitoso de una operación cualquiera, que no devuelve nungún valor, como se indica en la clase
	/// <see cref="Resultado"/>.
	/// </summary>
	public class Exito : Resultado
	{
		public override bool EsCorrecto => true;
		public override Exito AsExito() => this;
		public override Fracaso AsFracaso() => null;

		/// <summary>
		/// <para>Obtiene un nuevo resultado exitoso en base al que realiza la llamada al método, pero en su versión
		/// genérica, añadiéndo un valor del tipo genérico indicado al nuevo resultado.</para>
		/// <para>Este método crea, efectivamente, un nuevo objeto cuyo tipo es instancia de la platilla de clase
		/// genérica <see cref="Exito{T}"/>.</para>
		/// </summary>
		/// <typeparam name="T">Tipo del valor del resultado obtenido.</typeparam>
		/// <param name="valor">Valor del resultado genérico obtenido.</param>
		/// <returns>Un resultado exitoso genérico asociado con el valor indicado en el parámetro.</returns>
		public Exito<T> Cast<T>(T valor) => new Exito<T>(valor);
	}

	/// <summary>
	/// Representa el resultado exitoso de una operación cualquiera, que devuelve un valor del tipo parametrizado.
	/// </summary>
	/// <typeparam name="T">Tipo parametrizado del valor devuelto por la operación exitosa.</typeparam>
	public class Exito<T> : Resultado<T>
	{
		private readonly T valor;

		/// <summary>
		/// Construye un nuevo resultado exitoso, conteniendo el valor devuelto por la operación exitosa.
		/// </summary>
		/// <param name="valor">Valor válido devuelto por la operación en caso de éxito.</param>
		public Exito(T valor) => this.valor = valor;

		public override bool EsCorrecto => true;

		/// <summary>
		/// Valor devuelto por la operación exitosa a través del objeto que llama al método.
		/// </summary>
		public T Valor => valor;

		public override Exito<T> AsExito() => this;
		public override Fracaso<T> AsFracaso() => null;
	}
}
