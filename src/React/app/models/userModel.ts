export interface UserModel {
  Id: number;
  FirstName: string;
  Username: string;
  Tipo: string;
  Token: string;
  TenantApp: string;
  IsMaster?: boolean;  
  IdProfissional: number;
  IdFunc: number;
}

export interface ValidaUserModel {
  Id: number;
  Username: string;
  TenantApp: string;
}
