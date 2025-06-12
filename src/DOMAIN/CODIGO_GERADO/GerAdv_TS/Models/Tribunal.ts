import { ITribunal } from '../Tribunal/Interfaces/interface.Tribunal';
export interface Tribunal
{
    id: number;
	area : number;
	justica : number;
	instancia : number;
	nome : string;
	descricao : string;
	sigla : string;
	web : string;
	etiqueta : boolean;
	bold : boolean;
	descricaoarea?: string;
	nomejustica?: string;
	nroprocessoinstancia?: string;

}


export function TribunalEmpty(): ITribunal {
// 20250604
    
    return {
        id: 0,
		area: 0,
		justica: 0,
		instancia: 0,
		nome: '',
		descricao: '',
		sigla: '',
		web: '',
		etiqueta: false,
		bold: false,
    };
}

export function TribunalTestEmpty(): ITribunal {
// 20250604
    
    return {
        id: 1,
		area: 1,
		justica: 1,
		instancia: 1,
		nome: 'X',
		descricao: 'X',
		sigla: 'X',
		web: 'X',
		etiqueta: true,
		bold: true,
    };
}


