import { IViaRecebimento } from '../ViaRecebimento/Interfaces/interface.ViaRecebimento';
export interface ViaRecebimento
{
    id: number;
	nome : string;

}


export function ViaRecebimentoEmpty(): IViaRecebimento {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function ViaRecebimentoTestEmpty(): IViaRecebimento {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


