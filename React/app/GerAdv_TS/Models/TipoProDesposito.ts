import { ITipoProDesposito } from '../TipoProDesposito/Interfaces/interface.TipoProDesposito';
export interface TipoProDesposito
{
    id: number;
	nome : string;

}


export function TipoProDespositoEmpty(): ITipoProDesposito {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function TipoProDespositoTestEmpty(): ITipoProDesposito {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


