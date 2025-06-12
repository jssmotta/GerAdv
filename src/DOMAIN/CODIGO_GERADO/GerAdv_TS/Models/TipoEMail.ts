import { ITipoEMail } from '../TipoEMail/Interfaces/interface.TipoEMail';
export interface TipoEMail
{
    id: number;
	nome : string;

}


export function TipoEMailEmpty(): ITipoEMail {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function TipoEMailTestEmpty(): ITipoEMail {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


