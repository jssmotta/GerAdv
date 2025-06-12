import { ITipoEndereco } from '../TipoEndereco/Interfaces/interface.TipoEndereco';
export interface TipoEndereco
{
    id: number;
	descricao : string;

}


export function TipoEnderecoEmpty(): ITipoEndereco {
// 20250604
    
    return {
        id: 0,
		descricao: '',
    };
}

export function TipoEnderecoTestEmpty(): ITipoEndereco {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
    };
}


