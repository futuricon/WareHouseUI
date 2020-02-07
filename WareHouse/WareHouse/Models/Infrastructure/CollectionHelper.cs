using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WareHouse.Models.Infrastructure
{
	public class CollectionHelper :NotifyChangedPropertyBase
	{
		private int collectionPosition = -1;
		[NotMapped]
		public int CollectionPosition
		{
			get => collectionPosition; set
			{
				collectionPosition = value;
				if (value != -1)
				{
					Action = CollectionAction.Add;
				}

			}
		}
		[NotMapped]
		public CollectionAction Action { get; set; } = CollectionAction.NoAction;

		public void OnUpdate(object value)
		{
			if (value!=null && CollectionPosition == -1)
			{
				Action = CollectionAction.Update;
			}
		}
	}
	public enum CollectionAction
	{
		Add,
		Remove,
		Update,
		NoAction
	}
}
