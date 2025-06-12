import { IRamal } from '../Ramal/Interfaces/interface.Ramal';
export interface Ramal
{
    id: number;
	nome : string;
	obs : string;

}


export function RamalEmpty(): IRamal {
// 20250604
    
    return {
        id: 0,
		nome: '',
		obs: '',
    };
}

export function RamalTestEmpty(): IRamal {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		obs: 'X',
    };
}


