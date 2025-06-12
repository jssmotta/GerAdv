import { IPoderJudiciarioAssociado } from '../PoderJudiciarioAssociado/Interfaces/interface.PoderJudiciarioAssociado';
export interface PoderJudiciarioAssociado
{
    id: number;
	justica : number;
	area : number;
	tribunal : number;
	foro : number;
	cidade : number;
	justicanome : string;
	areanome : string;
	tribunalnome : string;
	foronome : string;
	subdivisaonome : string;
	cidadenome : string;
	subdivisao : number;
	tipo : number;
	nomejustica?: string;
	descricaoarea?: string;
	nometribunal?: string;
	nomeforo?: string;
	nomecidade?: string;

}


export function PoderJudiciarioAssociadoEmpty(): IPoderJudiciarioAssociado {
// 20250604
    
    return {
        id: 0,
		justica: 0,
		area: 0,
		tribunal: 0,
		foro: 0,
		cidade: 0,
		justicanome: '',
		areanome: '',
		tribunalnome: '',
		foronome: '',
		subdivisaonome: '',
		cidadenome: '',
		subdivisao: 0,
		tipo: 0,
    };
}

export function PoderJudiciarioAssociadoTestEmpty(): IPoderJudiciarioAssociado {
// 20250604
    
    return {
        id: 1,
		justica: 1,
		area: 1,
		tribunal: 1,
		foro: 1,
		cidade: 1,
		justicanome: 'X',
		areanome: 'X',
		tribunalnome: 'X',
		foronome: 'X',
		subdivisaonome: 'X',
		cidadenome: 'X',
		subdivisao: 1,
		tipo: 1,
    };
}


