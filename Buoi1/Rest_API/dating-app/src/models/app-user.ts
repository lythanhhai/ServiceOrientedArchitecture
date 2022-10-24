class User {
    id?: number;
    username?: string;
    email?: string;
    // PasswordHash? : any[];
    // PasswordSalt? : any[];
    constructor(id: number, name: string, email: string)
    {
        this.id = id;
        this.username = name;
        this.email = email;
    }
}
export { User }