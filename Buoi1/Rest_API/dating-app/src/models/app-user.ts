class User {
  id?: number;
  username?: string;
  email?: string;
  // PasswordHash? : any[];
  // PasswordSalt? : any[];
  constructor(id: number, name: string, email: string) {
    this.id = id;
    this.username = name;
    this.email = email;
  }
}
class UserToken {
  username: string = '';
  token: string = '';
}
class AuthUser 
{
    username: string = "";
    password: string = "";
}
export { User, UserToken, AuthUser };
