using System;
using System.Collections.Generic;
using System.Text;

public interface ICategory
{
    string Name { get; }

    ICategory Parent { get; }

    IList<IUser> Users { get; }

    IList<ICategory> ChildCategories { get; }

    void AddChild(ICategory child);

    void MoveUsersToParent();

    void RemoveChild(string name);

    void AddUser(IUser user);

    void SetParent(ICategory category);
}