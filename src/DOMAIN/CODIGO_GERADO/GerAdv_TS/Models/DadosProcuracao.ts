import { Auditor } from "./Auditor";

import { IDadosProcuracao } from "../DadosProcuracao/Interfaces/interface.DadosProcuracao";
export interface DadosProcuracao
{
    id: number;
	cliente : number;
	estadocivil : string;
	nacionalidade : string;
	profissao : string;
	ctps : string;
	pispasep : string;
	remuneracao : string;
	objeto : string;
	auditor?: Auditor | null;
}

export function DadosProcuracaoEmpty(): IDadosProcuracao {
// 20250125
    return {
        id: 0,
		cliente: 0,
		estadocivil: '',
		nacionalidade: '',
		profissao: '',
		ctps: '',
		pispasep: '',
		remuneracao: '',
		objeto: '',
		auditor: null
    };
}
