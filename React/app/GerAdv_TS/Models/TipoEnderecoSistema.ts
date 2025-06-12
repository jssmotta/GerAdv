import { ITipoEnderecoSistema } from '../TipoEnderecoSistema/Interfaces/interface.TipoEnderecoSistema';
export interface TipoEnderecoSistema
{
    id: number;
	nome : string;

}


export function TipoEnderecoSistemaEmpty(): ITipoEnderecoSistema {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function TipoEnderecoSistemaTestEmpty(): ITipoEnderecoSistema {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


