namespace Eequiis.Dotnet.Resultado
{
	internal static class NSGlobal
	{
		internal static readonly string FracasoCausaDesconocida = "Causa desconocida";
	}

	/// <summary>
	/// <para>Resultado de fracaso de una operación cualquiera, que no devuelve ningún valor, como se indica en la
	/// clase <see cref="Resultado"/>.</para>
	/// </summary>
	public class Fracaso : Resultado
	{
		private readonly string causa;

		/// <summary>
		/// <para>Construye un resultado de fracaso indicando la causa del mismo.</para>
		/// <para>Si la causa es no significativa (nula, vacía o blanca), se indidicará un mensaje genérico.</para>
		/// </summary>
		/// <param name="causa">Mensaje que indica la causa del fracaso.</param>
		public Fracaso(string causa)
			=> this.causa = string.IsNullOrWhiteSpace(causa) ? NSGlobal.FracasoCausaDesconocida : causa;

		/// <summary>
		/// <para>Obtiene el mensaje con la causa del fracaso en la operación que devuelve este resultado.</para>
		/// </summary>
		public string Causa => causa;

		public override bool EsFracaso => true;
		public override Fracaso AsFracaso() => this;

		/// <summary>
		/// <para>A partir de este fracaso, obtiene un nuevo resultado de fracaso, pero en su versión genérica,
		/// manteniendo el mensaje de error original.</para>
		/// <para>Este método crea, efectivamente, un nuevo objeto cuyo tipo es instancia de la platilla genérica
		/// de clase <see cref="Fracaso{T}"/>.</para>
		/// </summary>
		/// <typeparam name="T">Tipo genérico del resultado obtenido.</typeparam>
		/// <returns>Un resultado de fracaso genérico, con el mensaje original asociado.</returns>
		public Fracaso<T> Cast<T>() => new Fracaso<T>(causa);
	}

	/// <summary>
	/// <para>Resultado de fracaso de una operación cualquiera, cuya intención era devolver un valor del tipo
	/// parametrizado, pero que al fracasar, no devuelve ningún valor asociado, sino un mensaje de error.</para>
	/// </summary>
	/// <typeparam name="T">Tipo parametrizado del valor que debería haber sido devuelto por la operación si hubiera
	/// tenido éxito (ya que hereda de la clase parametrizada <see cref="Resultado{T}"/>).</typeparam>
	public class Fracaso<T> : Resultado<T>
	{
		private readonly string causa;

		/// <summary>
		/// <para>Construye un resultado de fracaso parametrizado con un mensaje de error asociado indicando la cause
		/// del fracaso de la operación.</para>
		/// <para>Si la causa es no significativa (nula, vacía o blanca), se indidicará un mensaje genérico.</para>
		/// </summary>
		/// <param name="causa">Mensaje de error asociado a la causa del fracaso de la operación que devuelve
		/// el resultado.</param>
		public Fracaso(string causa)
			=> this.causa = string.IsNullOrWhiteSpace(causa) ? NSGlobal.FracasoCausaDesconocida : causa;

		/// <summary>
		/// <para>Obtiene el valor del mensaje de este fracaso, que indica la causa del mismo.</para>
		/// </summary>
		public string Causa => causa;

		public override bool EsFracaso => true;
		public override Fracaso<T> AsFracaso() => this;
	}
}
