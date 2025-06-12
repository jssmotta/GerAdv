import { ITribEnderecos } from '../TribEnderecos/Interfaces/interface.TribEnderecos';
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
	nometribunal?: string;
	nomecidade?: string;

}


export function TribEnderecosEmpty(): ITribEnderecos {
// 20250604
    
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

export function TribEnderecosTestEmpty(): ITribEnderecos {
// 20250604
    
    return {
        id: 1,
		tribunal: 1,
		cidade: 1,
		endereco: 'X',
		cep: 'X',
		fone: 'X',
		fax: 'X',
		obs: 'X',
    };
}


