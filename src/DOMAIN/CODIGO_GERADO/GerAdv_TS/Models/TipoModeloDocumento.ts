import { ITipoModeloDocumento } from '../TipoModeloDocumento/Interfaces/interface.TipoModeloDocumento';
export interface TipoModeloDocumento
{
    id: number;
	nome : string;

}


export function TipoModeloDocumentoEmpty(): ITipoModeloDocumento {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function TipoModeloDocumentoTestEmpty(): ITipoModeloDocumento {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


