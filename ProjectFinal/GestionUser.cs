using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal
{
  
        public class GestionUser
        {
            private static GestionUser instance;
            private List<User> users;

            private GestionUser()
            {
                users = new List<User>();
            }
            public static GestionUser Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new GestionUser();
                    }
                    return instance;
                }
            }

            /// <summary>
            /// Ajoute un utilisateur à la liste des utilisateurs.
            /// </summary>
            /// <param name="user">L'utilisateur à ajouter</param>
            public void AddUser(User user)
            {
                users.Add(user);
            }

            /// <summary>
            /// Supprime un utilisateur de la liste des utilisateurs.
            /// </summary>
            /// <param name="user">L'utilisateur à supprimer</param>
            public void RemoveUser(User user)
            {
                users.Remove(user);
            }
            public void SetUsers(List<User> users)
        {
            this.users = users;
        }

        /// <summary>
        /// Obtient la liste des utilisateurs.
        /// </summary>
        /// <returns>La liste des utilisateurs</returns>
        public List<User> GetUsers()
            {
                return users;
            }
            /// <summary>
            /// Recherche un utilisateur dans la liste des utilisateurs.
            /// </summary>
            /// <param name="login">Le nom d'utilisateur</param>
            /// <param name="password">Le mot de passe de l'utilisateur</param>
            /// <returns>L'utilisateur trouvé, ou null si l'utilisateur n'existe pas</returns>
            public User FindUser(string login, string password)
            {
                foreach (User user in users)
                {
                    if (user.Login == login && user.Password == password)
                    {
                        return user;
                    }
                }
                return null;
            }

        }
    }


