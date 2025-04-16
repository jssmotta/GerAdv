import { Auditor } from "./Auditor";

import { IDivisaoTribunal } from "../DivisaoTribunal/Interfaces/interface.DivisaoTribunal";
export interface DivisaoTribunal
{
    id: number;
	justica : number;
	area : number;
	cidade : number;
	foro : number;
	tribunal : number;
	numcodigo : number;
	nomeespecial : string;
	codigodiv : string;
	endereco : string;
	fone : string;
	fax : string;
	cep : string;
	obs : string;
	email : string;
	andar : string;
	etiqueta : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function DivisaoTribunalEmpty(): IDivisaoTribunal {
// 20250125
    return {
        id: 0,
		justica: 0,
		area: 0,
		cidade: 0,
		foro: 0,
		tribunal: 0,
		numcodigo: 0,
		nomeespecial: '',
		codigodiv: '',
		endereco: '',
		fone: '',
		fax: '',
		cep: '',
		obs: '',
		email: '',
		andar: '',
		etiqueta: false,
		bold: false,
		auditor: null
    };
}
