import { IRegimeTributacao } from '../RegimeTributacao/Interfaces/interface.RegimeTributacao';
export interface RegimeTributacao
{
    id: number;
	nome : string;

}


export function RegimeTributacaoEmpty(): IRegimeTributacao {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function RegimeTributacaoTestEmpty(): IRegimeTributacao {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


