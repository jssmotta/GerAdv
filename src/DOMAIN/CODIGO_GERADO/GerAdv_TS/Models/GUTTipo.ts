import { IGUTTipo } from '../GUTTipo/Interfaces/interface.GUTTipo';
export interface GUTTipo
{
    id: number;
	nome : string;
	ordem : number;

}


export function GUTTipoEmpty(): IGUTTipo {
// 20250604
    
    return {
        id: 0,
		nome: '',
		ordem: 0,
    };
}

export function GUTTipoTestEmpty(): IGUTTipo {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		ordem: 1,
    };
}


