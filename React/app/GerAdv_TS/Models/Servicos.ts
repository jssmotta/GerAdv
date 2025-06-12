import { IServicos } from '../Servicos/Interfaces/interface.Servicos';
export interface Servicos
{
    id: number;
	cobrar : boolean;
	descricao : string;
	basico : boolean;

}


export function ServicosEmpty(): IServicos {
// 20250604
    
    return {
        id: 0,
		cobrar: false,
		descricao: '',
		basico: false,
    };
}

export function ServicosTestEmpty(): IServicos {
// 20250604
    
    return {
        id: 1,
		cobrar: true,
		descricao: 'X',
		basico: true,
    };
}


