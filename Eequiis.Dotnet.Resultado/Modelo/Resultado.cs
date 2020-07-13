using System;

namespace Eequiis.Dotnet.Resultado
{
	/// <summary>
	/// <para>Representa el resultado de una operación que no devuelve ningún valor, o cuyo valor de retorno es
	/// un booleano que solo indica si la operación ha tenido éxito o no.</para>
	/// <para>En caso de que una operación devuelva un valor booleano que no indique el éxito o fracaso de la operación
	/// invocada, se recomienda el uso de la clase <see cref="Resultado{T}"/> genérica, instanciándola mediante el uso
	/// de la clase Resultado&lt;bool&gt;.
	/// </para>
	/// </summary>
	public abstract class Resultado : TResultado
	{
		/// <summary>
		/// <para>Obtiene una vista exitosa del resultado.</para>
		/// <para>Si el resultado no es una instancia de <see cref="Exito"/>, el método devolverá null.</para>
		/// </summary>
		/// <returns>Una vista exitosa del resultado, o null.</returns>
		public abstract Exito AsExito();

		/// <summary>
		/// <para>Obtiene una vista fallida del resultado.</para>
		/// <para>Si el resultado no es una instancia de <see cref="Fracaso"/>, el método devolverá null.</para>
		/// </summary>
		/// <returns>Una vista fallida del resultado, o null.</returns>
		public abstract Fracaso AsFracaso();

		/// <summary>
		/// <para>Obtiene un resultado, instancia de <see cref="Exito"/> o <see cref="Fracaso"/>, en base a un valor
		/// booleano y un mensaje de error.</para>
		/// <para>Si el valor booleano es true, se devolverá un resultado exitoso, mientras que si es false,
		/// se devolverá un resultado fallido, acompañado por el mensaje indicado en el parámetro.</para>
		/// </summary>
		/// <param name="exito">Indica si el resultado a obtener es exitoso.</param>
		/// <param name="error">Mensaje de error en caso de que el resultado a construir sea un <see cref="Fracaso"/>.
		/// </param>
		/// <returns>Un resultado exitoso o fallido en función del valor booleano indicado.</returns>
		public static Resultado Get(bool exito, string error)
		{
			if (exito) return new Exito();
			else return new Fracaso(error);
		}
	}

	/// <summary>
	/// <para>Representa el resultado de una operación que devuelve un valor de un tipo parametrizado.</para>
	/// <para>En caso de que la operación devuelva un valor booleano solo indique el éxito o fracaso de la operación,
	/// o que no tenga valor de retorno (void), se recomienda el uso de la clase <see cref="Resultado"/> no
	/// parametrizada.</para>
	/// </summary>
	/// <typeparam name="T">Tipo parametrizado del valor devuelto por la operación.</typeparam>
	public abstract class Resultado<T> : TResultado
	{
		/// <summary>
		/// <para>Obtiene una vista exitosa del resultado que llama al método.</para>
		/// <para>Si el resultado no es instancia de <see cref="Exito{T}"/>, el método devolverá null.</para>
		/// </summary>
		/// <returns>Una vista parametrizada exitosa del resultado, o null.</returns>
		public abstract Exito<T> AsExito();

		/// <summary>
		/// <para>Obtiene una vista fallida del resultado que llama al método.</para>
		/// <para>Si el resultado no es instancia de <see cref="Fracaso{T}"/>, el método devolverá null.</para>
		/// </summary>
		/// <returns>Una vista parametrizada fallida del resultado, o null.</returns>
		public abstract Fracaso<T> AsFracaso();

		/// <summary>
		/// <para>Obtiene un resultado, instancia de <see cref="Exito{T}"/> o <see cref="Fracaso{T}"/>, en base a
		/// un valor de tipo parametrizado, una condición parametrizada y un mensaje de error.</para>
		/// <para>Si la condición parametrizada es cierta, se devolverá un resultado parametrizado exitoso conteniendo
		/// el valor de tipo parametrizado indicado, mientras que si es falsa se devolverá un resultado parametrizado
		/// fallido, acompañado por el mensaje de error indicado.</para>
		/// </summary>
		/// <param name="valor">Valor de tipo parametrizado devuelto por la operación que devuelve el resultado,
		/// en caso de ser exitosa.</param>
		/// <param name="exito">Condición de tipo parametrizado que indica en qué caso el resultado es exitoso.</param>
		/// <param name="error">Mensaje de error en caso de que el resultado obtenido sea fallido.</param>
		/// <returns>Un resultado parametrizado, exitoso o fallido en base a la condición indicada.</returns>
		public static Resultado<T> Get(T valor, Predicate<T> exito, string error)
		{
			if (exito == null) return new Fracaso<T>(error);
			if (exito(valor)) return new Exito<T>(valor);
			else return new Fracaso<T>(error);
		}
	}
}
