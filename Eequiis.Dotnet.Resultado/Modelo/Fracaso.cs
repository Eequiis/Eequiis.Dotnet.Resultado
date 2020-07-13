namespace Eequiis.Dotnet.Resultado
{
	internal static class NSGlobal
	{
		internal static readonly string CausaDesconocida = "Causa desconocida";
	}

	/// <summary>
	/// Resultado fallido de una operación cualquiera, que no devuelve ningún valor, como se indica en la clase
	/// <see cref="Resultado"/>.
	/// </summary>
	public class Fracaso : Resultado
	{
		private readonly string causa;

		/// <summary>
		/// <para>Construye un resultado fallido indicando la causa del mismo.</para>
		/// <para>Si la causa es no significativa (nula, vacía o blanca), se indidicará un mensaje genérico.</para>
		/// </summary>
		/// <param name="causa">Mensaje que indica la causa del fracaso en la operación que devuelve este resultado.</param>
		public Fracaso(string causa) => this.causa = string.IsNullOrWhiteSpace(causa) ? NSGlobal.CausaDesconocida : causa;

		public override bool EsError => true;

		/// <summary>
		/// Obtiene el mensaje con la causa del fracaso en la operación que devuelve este tipo de resultado.
		/// </summary>
		public string Causa => causa;

		public override Exito AsExito() => null;
		public override Fracaso AsFracaso() => this;

		/// <summary>
		/// <para>Obtiene un nuevo resultado fallido en base al que realiza la llamada al método, pero en su versión
		/// genérica, manteniendo el mensaje de error del <see cref="Fracaso"/> original.</para>
		/// <para>Este método crea, efectivamente, un nuevo objeto cuyo tipo es instancia de la platilla genérica
		/// de clase <see cref="Fracaso{T}"/>.</para>
		/// </summary>
		/// <typeparam name="T">Tipo genérico del resultado obtenido.</typeparam>
		/// <returns>Un resultado fallido genérico asociado al mensaje del <see cref="Fracaso"/> original.</returns>
		public Fracaso<T> Cast<T>() => new Fracaso<T>(causa);
	}

	/// <summary>
	/// Representa el resultado fallido de una operación cualquiera, cuya intención era devolver un valor del tipo
	/// parametrizado, pero que al fracasar, no devuelve ningún valor asociado, sino un mensaje de error.
	/// </summary>
	/// <typeparam name="T">Tipo parametrizado del valor que debería haber sido devuelto por la operación
	/// si hubiera tenido éxito (ya que hereda de la clase parametrizada <see cref="Resultado{T}"/>).</typeparam>
	public class Fracaso<T> : Resultado<T>
	{
		private readonly string causa;

		/// <summary>
		/// <para>Construye un resultado fallido parametrizado con un mensaje de error concreto.</para>
		/// <para>Si la causa es no significativa (nula, vacía o blanca), se indidicará un mensaje genérico.</para>
		/// </summary>
		/// <param name="causa">Mensaje de error asociado a la causa del fracaso de la operación que devuelve
		/// el resultado.</param>
		public Fracaso(string causa) => this.causa = string.IsNullOrWhiteSpace(causa) ? NSGlobal.CausaDesconocida : causa;

		public override bool EsError => true;

		/// <summary>
		/// Obtiene el mensaje con la causa del fracaso en la operación que devuelve este tipo de resultado.
		/// </summary>
		public string Causa => causa;

		public override Exito<T> AsExito() => null;
		public override Fracaso<T> AsFracaso() => this;
	}
}
