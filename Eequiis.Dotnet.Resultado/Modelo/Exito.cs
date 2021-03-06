﻿/*******************************************************************************
 *
 * Copyright (C) 2020, 2021 Eequiis Vásquez
 *
 * This file is part of Eequiis.Dotnet.Resultado.
 *
 * Eequiis.Dotnet.Resultado is free software: you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation, either version 3 of the License,
 * or (at your option) any later version.
 *
 * Eequiis.Dotnet.Resultado is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser
 * General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with Eequiis.Dotnet.Resultado. If not, see
 * <https://www.gnu.org/licenses/>.
 *
 ******************************************************************************/

namespace Eequiis.Dotnet.Resultado
{
	/// <summary>
	/// <para>Resultado exitoso de una operación cualquiera, que no devuelve nungún valor, como se indica en la clase
	/// <see cref="Resultado"/>.</para>
	/// </summary>
	public class Exito : Resultado
	{
		public override bool EsExito => true;
		public override Exito AsExito() => this;

		/// <summary>
		/// <para>A partir de este resultado, obtiene un resultado de éxito genérico, añadiendo un valor del tipo
		/// indicado.</para>
		/// <para>Este método crea, efectivamente, un nuevo objeto cuyo tipo es instancia de la platilla de clase
		/// genérica <see cref="Exito{T}"/>.</para>
		/// </summary>
		/// <typeparam name="T">Tipo del valor del resultado obtenido.</typeparam>
		/// <param name="valor">Valor del resultado genérico obtenido.</param>
		/// <returns>Un resultado exitoso genérico con el valor indicado asociado.</returns>
		public Exito<T> Cast<T>(T valor) => new Exito<T>(valor);
	}

	/// <summary>
	/// <para>Resultado exitoso de una operación cualquiera, que devuelve un valor de tipo parametrizado.</para>
	/// </summary>
	/// <typeparam name="T">Tipo del valor devuelto por la operación exitosa.</typeparam>
	public class Exito<T> : Resultado<T>
	{
		private readonly T valor;

		/// <summary>
		/// <para>Construye un nuevo resultado exitoso, conteniendo un valor a devolver asociado.</para>
		/// </summary>
		/// <param name="valor">Valor asociado al resultado exitoso a construir.</param>
		public Exito(T valor) => this.valor = valor;

		/// <summary>
		/// <para>Obtiene el valor asociado a este resultado exitoso.</para>
		/// </summary>
		public T Valor => valor;

		public override bool EsExito => true;
		public override Exito<T> AsExito() => this;
	}
}
