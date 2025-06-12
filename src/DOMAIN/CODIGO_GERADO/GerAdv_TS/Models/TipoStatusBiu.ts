import { ITipoStatusBiu } from '../TipoStatusBiu/Interfaces/interface.TipoStatusBiu';
export interface TipoStatusBiu
{
    id: number;
	nome : string;

}


export function TipoStatusBiuEmpty(): ITipoStatusBiu {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function TipoStatusBiuTestEmpty(): ITipoStatusBiu {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


