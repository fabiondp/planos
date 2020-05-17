using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PlanoModel
    {
		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private Guid _uid;

		public Guid Uid
		{
			get { return _uid; }
			set { _uid = value; }
		}

		private string _titulo;

		public string Titulo
		{
			get { return _titulo; }
			set { _titulo = value; }
		}

		private string _descricao;

		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		private DateTime dateTime;

		public DateTime DataAlteracao
		{
			get { return dateTime; }
			set { dateTime = value; }
		}


		private DateTime _dataCriacao;

		public DateTime DataCriacao
		{
			get { return _dataCriacao; }
			set { _dataCriacao = value; }
		}

	}
}
