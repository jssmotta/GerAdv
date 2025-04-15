import { ITribEnderecos } from "../TribEnderecos/Interfaces/interface.TribEnderecos";
export interface TribEnderecos
{
    id: number;
	tribunal : number;
	cidade : number;
	endereco : string;
	cep : string;
	fone : string;
	fax : string;
	obs : string;
}

export function TribEnderecosEmpty(): ITribEnderecos {
// 20250125
    return {
        id: 0,
		tribunal: 0,
		cidade: 0,
		endereco: '',
		cep: '',
		fone: '',
		fax: '',
		obs: '',
    };
}
